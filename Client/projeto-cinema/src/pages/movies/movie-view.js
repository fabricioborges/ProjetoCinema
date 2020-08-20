import React, { useState, useEffect } from 'react';
import api from '../../services/api';
import './movie-view.css'
import Menu from '../../components/menu/menu';
import { confirmAlert } from 'react-confirm-alert';
import 'react-confirm-alert/src/react-confirm-alert.css'
import { ToastContainer, toast } from 'react-toastify';
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

    useEffect(() => {
        async function loadMovies() {

            const response = await api.get(`api/movie/`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            });

            setMovies(response.data.Items);
        }
        loadMovies();
    }, []);

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

        }
        catch (err) {
            toast.error(<MsgError />);
        }
    }

    return (
        <div id="App">
            <Menu  {...history}/>
            <ToastContainer />
            <div className="movie-container-view">
                <button className="new" onClick={() => handleToNew()}>Adicionar</button>
                {movies.length > 0 ?
                    (<ul>
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
                    </ul>) : <div></div>
                }
            </div>
        </div>
    )
}