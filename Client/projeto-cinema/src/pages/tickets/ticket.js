import React, { useState, useEffect } from 'react';
import api from '../../services/api';
import './ticket.css';
import MenuCustomer from '../../components/menu/menu-customer';

export default function Ticket({ match, history }) {

    const [sessions, setSessions] = useState({});

    useEffect(() => {
        async function loadSessions() {

            const response = await api.get(`api/session?$Filter=Id eq ${match.params.id}`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            })
            setSessions(response.data.Items);
        }
        loadSessions();

    }, []);

    async function handleToSeat(movieTheaterid, sessionId) {
        localStorage.setItem('session', sessionId);
        history.push(`/seat/${movieTheaterid}`);
    }

    return (
        <div id="App">
            <MenuCustomer  {...history}/>           
            <div className="ticket-container">              
                {sessions.length > 0 ?
                    (<ul>
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
                                    <button className="confirmed" onClick={() => handleToSeat(session.MovieTheater.Id, session.Id)}>Confirmar</button>
                                </footer>
                            </li>
                        ))}
                    </ul>) : (
                        <div>
                            <div className="empty"> Não há sessões cadastradas para esse dia :(</div>
                        </div>)}
            </div>
        </div>
    )

}