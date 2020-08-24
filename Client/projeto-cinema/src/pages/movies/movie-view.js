import React, { useState, useEffect } from 'react';
import api from '../../services/api';
import './movie-view.css'
import Menu from '../../components/menu/menu';
import { confirmAlert } from 'react-confirm-alert';
import 'react-confirm-alert/src/react-confirm-alert.css'
import { ToastContainer, toast } from 'react-toastify';
import Pagination from "@material-ui/lab/Pagination";
import 'react-toastify/dist/ReactToastify.css';

const MsgSuccess = ({ closeToast }) => (
    <div>
        Registro excluído com sucesso!
    </div>
)

const MsgError = ({ closeToast }) => (
    <div>
        Não foi possível excluir o registro!
    </div>
)

export default function MovieView({ history }) {

    var [movies, setMovies] = useState([]);
    const [page, setPage] = useState(0);
    const [count, setCount] = useState(0)
    const [refresh, setRefresh] = useState(true);

    useEffect(() => {
        async function loadCount() {
            const response = await api.get(`api/movie?$count=true&$top=0`, {
                headers: {
                    token: sessionStorage.getItem('token')
                },
            });

            const getCount = Math.ceil(response.data.Count / 10);
            setCount(getCount)
            setRefresh(false);
            if (count < page) {
                setPage(count);
            }
        }

        loadCount();
    }, [refresh])

    useEffect(() => {
        async function loadMovies() {
            const params = getRequestParams();
            const response = await api.get(`api/movie${params}`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            });

            setMovies(response.data.Items);
        }
        loadMovies();
    }, [page]);

    function getRequestParams() {

        if (page > 1) {
            const skip = (page * 10) - 10;
            const params = `?$skip=${skip}&$top=10`
            return params;
        }

        return '?$top=10';
    };

    const handlePageChange = (event, value) => {
        setPage(value);
    };

    function handleToEdit(id) {
        history.push(`/movie/${id}`)
    }

    function handleToNew() {
        history.push(`/movie/`)
    }

    function handleToDelete(movie) {
        const options = {
            title: 'Excluir registro',
            message: 'Deseja excluir o filme selecionado?',
            buttons: [
                {
                    label: 'Sim',
                    onClick: () => removeMovie(movie)
                },
                {
                    label: 'Não',
                    onClick: () => onclose
                }
            ],
            childrenElement: () => <div />,
            closeOnEscape: true,
            closeOnClickOutside: true,
            onClickOutside: () => { },
            onKeypressEscape: () => { }
        };

        confirmAlert(options);
    }

    async function removeMovie(movie) {
        try {
            const id = movie.Id;

            await api.delete(`api/movie`, { data: { id } }, {
                headers: {
                    token: sessionStorage.getItem('token'),
                    contenttype: 'application/json'
                }
            });

            const index = movies.indexOf(movie);
            var moviesRefresh = [];

            if (index > -1) {
                delete movies[index];

                movies.map(x => moviesRefresh.push(x));
            }

            setMovies(moviesRefresh);
            toast.success(<MsgSuccess />);
            setRefresh(true);
        }
        catch (err) {
            toast.error(<MsgError />);
        }
    }

    return (
        <div id="App">
            <Menu  {...history} />
            <ToastContainer />
            <div className="movie-container-view">
                <button className="new" onClick={() => handleToNew()}>Adicionar</button>
                {movies.length > 0 ?
                    (<>
                        <ul>
                            {movies.map(movie => (
                                <li key={movie.Id}>
                                    <img src={movie.Image} alt="image" />
                                    <footer>
                                        <strong>{movie.Title}</strong>
                                        <p>{movie.Description}</p>
                                        <p>{movie.Duration}</p>
                                        <p>{movie.AnimationType == 1 ? '3D' : '2D'}</p>
                                        <p>{movie.TypeAudio == 1 ? 'Dublado' : 'Legendado'}</p>
                                        <p>Data de estreia: {movie.DebutDate}</p>

                                        <button className="edit" onClick={() => handleToEdit(movie.Id)}>Editar</button>
                                        <button className="delete" onClick={() => handleToDelete(movie)}>Excluir</button>
                                    </footer>
                                </li>
                            ))}
                        </ul>
                        <Pagination
                            className="my-3"
                            count={count}
                            page={page}
                            siblingCount={1}
                            boundaryCount={1}
                            onChange={handlePageChange}
                        />
                    </>) : 'Não há filmes cadastrados :('
                }
            </div>
        </div>
    )
}