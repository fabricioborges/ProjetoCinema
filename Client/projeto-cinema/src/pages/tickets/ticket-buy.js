import React, { useState, useEffect } from "react";
import api from '../../services/api';
import { ToastContainer, toast } from 'react-toastify';
import MenuCustomer from '../../components/menu/menu-customer';
import './ticket-buy.css';

const MsgSuccess = ({ closeToast }) => (
    <div>
       Compra efetuada com sucesso!
    </div>
)

const MsgError = ({ closeToast }) => (
    <div>
        Ocorreu um erro ao comprar o ingresso
    </div>
)


export default function TicketBuy({ history }) {

    const [sessions, setSessions] = useState([]);
    const [snacksConcat, setSnack] = useState([]);
    const [seatsConcat, setSeat] = useState([]);
    const [seatValue, setSeatValue] = useState(0);
    const [snackValue, setSnackValue] = useState([]);
    const [valueTotal, setValue] = useState(0);
    const [user, setUser] = useState([]);
    var id;
    useEffect(() => {
        async function loadSessions() {

            id = localStorage.getItem('session')
            var userId = localStorage.getItem('customerId')
            const snacks = localStorage.getItem('snacks');
            const seats = localStorage.getItem('seats');
            var value = localStorage.getItem('seatsValue')
            var valueSnack = localStorage.getItem('snacksValue');
            const response = await api.get(`api/session?$Filter=Id eq ${id}`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            })
            setSessions(response.data.Items);
            setSnack(JSON.parse(snacks));
            setSeat(JSON.parse(seats));
            setSeatValue(value);
            setSnackValue(valueSnack);
            value = parseInt(value)
            valueSnack = parseInt(valueSnack)
            setValue(value + valueSnack);
            setUser(JSON.parse(userId));
        }
        loadSessions();

    }, []);

    async function handleConfirmed() {
        console.log(user);

        const seatsToPersist = localStorage.getItem('seatsToPersist');
        const seats = JSON.parse(seatsToPersist);

        await api.put(`api/seat/`, seats, {
            headers: {
                token: sessionStorage.getItem('token')
            }
        })

        var ticketAdd = {
            userId: user,
            sessionId: sessions[0].Id,
            movieId: sessions[0].Movie.Id,
            movieTheaterid: sessions[0].MovieTheater.Id,
            snacksIds: snacksConcat.map(x => x.Id).filter(x => x.Quantity > 0),
            value: valueTotal
        }

        const response = await api.post(`api/ticket`, ticketAdd)

        if (response.status === 200) {
            toast.success(<MsgSuccess />, { autoClose: 5000 });
            history.push('/sessionview/')
        } else {
            toast.error(<MsgError />, { autoClose: 5000 });
        }


    }

    return (

        <div className="app">
            <MenuCustomer {...history} />
            <div className="ticket-buy-container">
                <ul>
                    {sessions.map(session => (
                        <li key={session.Id}>
                            <img src={session.Movie.Image} alt="image" />
                            <footer>
                                <strong>{session.Movie.Title}</strong>
                                <p>{session.Movie.Description}</p>
                                <p>{session.Duration}</p>
                                <p>{session.AnimationType == 1 ? '3D' : '2D'}</p>
                                <p>{session.TypeAudio == 1 ? 'Dublado' : 'Legendado'}</p>
                                <p>{session.MovieTheater.Name}</p>
                                <p className="dateSession">{session.Hour}</p>
                                {snacksConcat.map(snack => (
                                    <li key={snack.Id}>
                                        <footer>
                                            <strong>{snack.Name}</strong>
                                            <p>Preço: R${snack.Price}</p>
                                            <p>Quantidade: {snack.Quantity}</p>
                                        </footer>
                                    </li>
                                ))}
                                {seatsConcat.map(seat => (
                                    <li key={seat.Id}>
                                        <footer>
                                            <strong>Assento: {seat.Number}</strong>
                                            <p>Preço: R${seatValue}</p>
                                        </footer>
                                    </li>
                                ))}
                                <strong>Total: R${valueTotal}</strong>
                                <button className="confirmed" onClick={handleConfirmed}>Confirmar</button>
                            </footer>
                        </li>))}
                </ul>
            </div>
        </div>
    )

}