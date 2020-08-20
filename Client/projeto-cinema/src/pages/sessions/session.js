import React, { useEffect, useState } from 'react';
import api from '../../services/api';
import logo from '../../assets/logo.png';
import './session.css';
import input from '../../components/inputs/input';
import { Form } from '@unform/web';
import Menu from '../../components/menu/menu';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const MsgSuccess = ({ closeToast }) => (
    <div>
        Sessão cadastrada com sucesso!
    </div>
)

const MsgError = ({ closeToast }) => (
    <div>
        Ocorreu um error ao gravar o registro
    </div>
)

export default function Session({ history, match }) {
    const [movieId, setmovieId] = useState();
    const [movieTheaterId, setMovieTheaterId] = useState();
    const [movieTheaters, setmovieTheaters] = useState([]);
    const [movies, setMovies] = useState([]);
    const [valueOfSeats, setValue] = useState(0);
    const [hour, setHour] = useState();
    const [dateInitial, setInitialDate] = useState();
    
    useEffect(() => {

        if (match.params.id) {
            async function loadSessions() {

                const response = await api.get(`api/session/${match.params.id}`, {
                    headers: {
                        token: sessionStorage.getItem('token')
                    }
                });
                setmovieId(response.data.Movie.Id);
                setValue(response.data.ValueOfSeats);
                setHour(response.data.Hour.slice(11, 16));
                setInitialDate(response.data.DateInitial.slice(0, 10));
                setMovieTheaterId(response.data.MovieTheater.Id);                    
            }
            loadSessions();
        }
    }, []);

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
    }, [])

    useEffect(() => {
        async function loadMoviesTheaters() {

            const response = await api.get(`api/movietheater/`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            });
            setmovieTheaters(response.data);
        }
        loadMoviesTheaters();
    }, []);

    async function handleSubmit(e) {
        e.preventDefault();
        try {
            var response;

            if (match.params.id) {
                const id = match.params.id;
                response = await api.put('api/session', {
                    id,
                    valueOfSeats,
                    hour, 
                    dateInitial,
                    movieId,
                    movieTheaterId
                });

            }
            else {
                response = await api.post('api/session', {
                    valueOfSeats,
                    hour,
                    dateInitial,
                    movieId,
                    movieTheaterId
                });
            }
            const codeResponse = 200;

            if (response.status === codeResponse) {
                toast.success(<MsgSuccess />, { autoClose: 5000 });

                history.push(`/sessionview/`)
            } else {
                toast.error(<MsgError />, { autoClose: 5000 });
            }
        }
        catch (err) {
            toast.success(<MsgError />, { autoClose: 5000 });
        }
    }

    function handleMovie(option) {
        setmovieId(option);
    }

    function handleMovieTheater(option) {
        setMovieTheaterId(option);
    }

    return (
        <div id="App">
            <Menu {...history}/>
            <div className="session-container">
                <form onSubmit={handleSubmit}>
                    <img src={logo} alt="logo" />

                    <input placeholder="Digite o valor dos assentos" name="valueOfSeats" 
                        type="number"
                        value={valueOfSeats} 
                        onChange={e => setValue(e.target.value)}/>
                    <select value={movieId}  onChange={e => handleMovie(e.target.value)} >
                        <option value={0}>Selecione um filme</option>
                        {movies.map(option => (
                            <option key={option.Id} value={option.Id}>{option.Title}</option>
                        ))}
                    </select>
                    <select value={movieTheaterId} onChange={e => handleMovieTheater(e.target.value)}>
                        <option value={0}>Selecione uma sala</option>
                        {movieTheaters.map(option => (
                            <option key={option.Id} value={option.Id} >{option.Name}</option>
                        ))}
                    </select>

                    <label>Digite a hora inicial da sessão</label>
                    <input name="hour" type="time" 
                        value={hour}
                        onChange={e => setHour(e.target.value)}/>

                    <label>Digite a data de início da sessão</label>
                    <input name="dateInitial" type="date" 
                        value={dateInitial}
                        onChange={e => setInitialDate(e.target.value)}/>

                    <button className="session" type="submit">Cadastrar</button>
                </form>


            </div>
        </div>
    )
}