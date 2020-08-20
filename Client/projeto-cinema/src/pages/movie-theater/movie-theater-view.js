import React, { useState, useEffect } from 'react';
import api from '../../services/api';
import './movie-theater-view.css';
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


export default function MovieTheaterView({history}) {
    const [movieTheaters, setmovieTheaters] = useState([]);

    useEffect(() => {
        async function loadMoviesTheaters() {

            const response = await api.get(`api/movietheater/`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            });
            console.log(response.data[0].Seats)
            setmovieTheaters(response.data);
        }
        loadMoviesTheaters();
    }, []);
    

    function handleToEdit(id) {
        history.push(`/movietheater/${id}`)
    }

    function handleToNew() {
        history.push(`/movietheater/`)
    }

    function handleToDelete(movieTheater) {
        const options = {
            title: 'Excluir registro',
            message: 'Deseja excluir a sala de cinema selecionada?',
            buttons: [
                {
                    label: 'Sim',
                    onClick: () => removeMovieTheater(movieTheater)
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

    async function removeMovieTheater(movieTheater) {
        try {
            const id = movieTheater.Id;

            await api.delete(`api/movietheater`, { data: { id } }, {
                headers: {
                    token: sessionStorage.getItem('token'),
                    contenttype: 'application/json'
                }
            });

            const index = movieTheaters.indexOf(movieTheater);
            var moviesTheatersRefresh = [];

            if (index > -1) {
                delete movieTheaters[index];

                movieTheaters.map(x => moviesTheatersRefresh.push(x));
            }

            setmovieTheaters(moviesTheatersRefresh);
            toast.success(<MsgSuccess />);

        }
        catch (err) {
            toast.error(<MsgError />);
        }
    }

    return(
        <div id="App">
            <Menu  {...history}/>
            <ToastContainer />
            <div className="movie-theater-container-view">
                <button className="new" onClick={() => handleToNew()}>Adicionar</button>
                {movieTheaters.length > 0 ?
                    (<ul>
                        {movieTheaters.map(movieTheater => (
                            <li key={movieTheater.Id}>                               
                                <footer>
                                    <strong>{movieTheater.Name}</strong>      
                                    <p>Quantidade de assentos: {movieTheater.Seats.length}</p>  
                                                                                              
                                    <button className="edit" onClick={() => handleToEdit(movieTheater.Id)}>Editar</button>
                                    <button className="delete" onClick={() => handleToDelete(movieTheater)}>Excluir</button>
                                </footer>
                            </li>
                        ))}
                    </ul>) : <div></div>
                }
            </div>
        </div>
    )
}