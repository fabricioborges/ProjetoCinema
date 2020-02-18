import React, { useState, useEffect } from "react";
import api from '../../services/api';
import './ticket-buy.css';

export default function TicketBuy({ history }) {

    const [sessions, setSessions] = useState([]);
    const [snacksConcat, setSnack] = useState([]);
    const [seatsConcat, setSeat] = useState([]);
    const [seatValue, setSeatValue] = useState(0);
    const [snackValue, setSnackValue] = useState([]);
    const [valueTotal, setValue] = useState(0);
    var id;
    useEffect(() => {
        async function loadSessions() {

            id = localStorage.getItem('session')
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

        }
        loadSessions();

    }, []);

    async function handleConfirmed(movieTheaterid) {

        var ticketAdd = {
            userId: 1,
            sessionId: sessions[0].Id,
            movieId: sessions[0].Movie.Id,
            movieTheaterid: sessions[0].MovieTheater.Id,
            snacksIds: snacksConcat.map(x => x.Id).filter(x => x.Quantity > 0),             
            value: valueTotal
        }

        const response = await api.post(`api/ticket`, ticketAdd )

        if(response.status === 200)
            alert("compra efetuada com sucesso");
    }

    return (
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
    )

}