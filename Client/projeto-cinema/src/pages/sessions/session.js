import React, { useEffect, useRef, useState } from 'react';
import api from '../../services/api';
import logo from '../../assets/logo.png';
import './session.css';
import Input from '../../components/inputs/input';
import Select from 'react-select';
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

    const formRef = useRef(null);
    const [movieTheaters, setmovieTheaters] = useState([]);
    const [movies, setMovies] = useState([]);
    var movieId = 0;
    var movieTheaterId = 0;
    var movieIdDb = 0;
    var movieTheaterIdDb = 0;

    useEffect(() => {

        if (match.params.id) {
            async function loadSessions() {

                const response = await api.get(`api/session/${match.params.id}`, {
                    headers: {
                        token: sessionStorage.getItem('token')
                    }
                });


                setTimeout(() => {
                    formRef.current.setData({
                        valueOfSeats: response.data.ValueOfSeats,
                        hour: response.data.Hour.slice(11, 16),
                        dateInitial: response.data.DateInitial.slice(0, 10)
                    })
                }, 500)

                movieIdDb = response.data.Movie.Id;
                movieTheaterIdDb = response.data.MovieTheater.Id;
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

    async function handleSubmit(session) {
        try {
            var response;
            debugger;
            if (match.params.id) {
                session.id = match.params.id;
                debugger
                session.movieId = movieId != 0 ? movieId : movieIdDb;
                session.movieTheaterId = movieTheaterId != 0 ? movieTheaterId : movieTheaterIdDb;
                response = await api.put('api/session', session);

            }
            else {
                response = await api.post('api/session', session);
            }
            const codeResponse = 200;

            if (response.status === codeResponse) {
                toast.success(<MsgSuccess />, { autoClose: 5000 });

                history.push(`/sessionview/`)

            }
        }
        catch (err) {
            toast.success(<MsgError />, { autoClose: 5000 });
        }
    }

    function handleMovie(option) {
        movieId = JSON.parse(option);
    }

    function handleMovieTheater(option) {
        movieTheaterId = JSON.parse(option);
    }

    return (
        <div id="App">
            <Menu />
            <div className="session-container">
                <Form ref={formRef} onSubmit={handleSubmit}>
                    <img src={logo} alt="logo" />

                    <Input placeholder="Digite o valor dos assentos" name="valueOfSeats" type="number" />
                    <select onChange={e => handleMovie(e.target.value)} >
                        <option selected disabled>Selecione um filme</option>
                        {movies.map(option => (
                            <option value={option.Id}>{option.Title}</option>
                        ))}
                    </select>

                    <select onChange={e => handleMovieTheater(e.target.value)}>
                        <option selected disabled>Selecione um filme</option>
                        {movieTheaters.map(option => (
                            <option value={option.Id} >{option.Name}</option>
                        ))}
                    </select>

                    <label>Digite a hora inicial da sessão</label>
                    <Input name="hour" type="time" />

                    <label>Digite a data de início da sessão</label>
                    <Input name="dateInitial" type="date" />

                    <button className="session" type="submit">Cadastrar</button>
                </Form>


            </div>
        </div>
    )
}