import React, { useState, useEffect, useRef } from 'react';
import api from '../../services/api';
import './movie-theater.css';
import logo from '../../assets/logo.png';
import Input from '../../components/inputs/input';
import { Form } from '@unform/web';
import Menu from '../../components/menu/menu';
import 'react-confirm-alert/src/react-confirm-alert.css'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const MsgSuccess = ({ closeToast }) => (
    <div>
        Filme cadastrado com sucesso!
    </div>
)

const MsgError = ({ closeToast }) => (
    <div>
        Ocorreu um error ao gravar o registro
    </div>
)

const MsgValidator = ({ closeToast }) => (
    <div>
        Já existe uma sala cadastrada com esse nome!
    </div>
)

var quantityDb = 0;

export default function MovieTheater({ history, match }) {
    const formRef = useRef(null);
    const [seats, setSeat] = useState([]);
    const [movieTheaters, setMovieTheaters] = useState([]);
    var seatsToEdit = [];

    useEffect(() => {

        if (match.params.id) {
            async function loadMovieTheater() {

                const response = await api.get(`api/movietheater/${match.params.id}`, {
                    headers: {
                        token: sessionStorage.getItem('token')
                    }
                });

                setTimeout(() => {
                    formRef.current.setData({
                        name: response.data.Name,
                        quantityOfSeats: response.data.Seats.length
                    })

                    quantityDb = response.data.Seats.length;
                    setSeat(response.data.Seats);

                }, 500)

            }
            loadMovieTheater();
        }
    }, []);

    useEffect(() => {
        async function loadMoviesTheaters() {
            const response = await api.get('api/movietheater/', {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            });

            setMovieTheaters(response.data);
        }

        loadMoviesTheaters();
    }, [])

    async function handleSubmit(movie) {

        if (movieTheaters.Items.find(x => x.Name.toUpperCase() === movie.name.toUpperCase() && x.Id != match.params.id)){
            toast.error(<MsgValidator />, { autoClose: 5000 });
            return;
        }

        try {
            var response;
            const quantityOfSeats = JSON.parse(formRef.current.getFieldValue('quantityOfSeats'));
            if (match.params.id) {
                movie.id = match.params.id;

                if (quantityDb < quantityOfSeats) {
                    addSeats(quantityOfSeats)
                }
                else if (quantityDb > quantityOfSeats) {
                    removeSeats(quantityOfSeats)
                }

                movie.seats = seats.concat(seatsToEdit);

                response = await api.put('api/movietheater', movie);
            }
            else {
                response = await api.post('api/movietheater', movie);
            }
            const codeResponse = 200;

            if (response.status === codeResponse) {
                toast.success(<MsgSuccess />, { autoClose: 5000 });

                history.push(`/movietheaterview/`)

            }
        }
        catch (err) {
            toast.error(<MsgError />, { autoClose: 5000 });
        }
    }

    function addSeats(items) {
        const news = items - quantityDb;

        if (seats.length > 0) {
            for (var i = 1; i <= news; i++) {
                const lastNumber = seats[seats.length - 1].Number;
                const lastId = seats[seats.length - 1].Id;
                const newSeat = {
                    id: lastId + i,
                    number: lastNumber + i,
                    isAvailable: true
                }
                seatsToEdit.push(newSeat);
            }
        }
        else {
            for (var i = 1; i <= news; i++) {
                const newSeat = {
                    id: i,
                    number: i,
                    isAvailable: true
                }
                seatsToEdit.push(newSeat);
            }
        }
    }

    function removeSeats(items) {
        const removes = quantityDb - items;

        for (var i = 1; i <= removes; i++) {
            const lastIndex = seats[seats.length - i];
            seatsToEdit = seats;
            const index = seats.indexOf(lastIndex);

            delete seatsToEdit[index];
        }

        setSeat(seatsToEdit);
    }

    return (
        <div className="App">
            <Menu  {...history} />
            <ToastContainer />
            <div className="movie-theater-container">
                <Form ref={formRef} onSubmit={handleSubmit}>
                    <img src={logo} alt="logo" />
                    <Input placeholder="Digite o nome da sala" name="name" />
                    <Input placeholder="Quantidade de assentos" name="quantityOfSeats" type="number" min="20" max="100" />

                    <button className="movie-theater" type="submit">Cadastrar</button>
                </Form>
            </div>
        </div>
    )
}