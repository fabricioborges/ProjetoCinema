import React, { useState, useEffect } from 'react';
import api from '../../services/api';
import './movie-theater-view.css';

export default function MovieTheaterView() {
    const [movieTheaters, setmovieTheaters] = useState([]);

    useEffect(() => {
        async function loadMovies() {

            const response = await api.get(`api/movietheater/`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            });

            setmovieTheaters(response.data.Items);
        }
        loadMovies();
    }, []);
    

    function handleToEdit(id) {
        history.push(`/movieTheater/${id}`)
    }

    function handleToNew() {
        history.push(`/movieTheater/`)
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

            await api.delete(`api/movieTheater`, { data: { id } }, {
                headers: {
                    token: sessionStorage.getItem('token'),
                    contenttype: 'application/json'
                }
            });

            const index = movieTheaters.indexOf(movieTheater);
            var moviesTheatersRefresh = [];

            if (index > -1) {
                delete movieTheater[index];

                movieTheater.map(x => moviesTheatersRefresh.push(x));
            }

            setmovieTheaters(moviesRefresh);
            toast.success(<MsgSuccess />);

        }
        catch (err) {
            toast.error(<MsgError />);
        }
    }

    return(
        <div id="App">
            <Menu />
            <ToastContainer />
            <div className="movie-theater-container-view">
                <button className="new" onClick={() => handleToNew()}>Adicionar</button>
                {movieTheaters.length > 0 ?
                    (<ul>
                        {movieTheaters.map(movieTheater => (
                            <li key={movieTheater.Id}>                               
                                <footer>
                                    <strong>{movieTheater.Title}</strong>
                                    <p>{movieTheater.Description}</p>
                                    <p>{movieTheater.Duration}</p>
                                    <p>{movieTheater.AnimationType == 1 ? '3D' : '2D'}</p>
                                    <p>{movieTheater.TypeAudio == 1 ? 'Dublado' : 'Legendado'}</p>
                                  
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