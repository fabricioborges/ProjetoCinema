import React, { useState, useEffect } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import api from '../../services/api';
import './session.css';
import { addDays } from "date-fns";

export default function Session() {

    const [sessions, setSessions] = useState([]);
    const [startDate, setStartDate] = useState(new Date());

    useEffect(() => {
        var paramDate = new Date(Date.UTC(startDate.getFullYear(), startDate.getMonth(), startDate.getDate()));
        const dateExhibition = paramDate.toJSON();

        async function loadSessions() {
            const response = await api.get(`api/session?$filter=EndDate ge ${dateExhibition}`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            })
            setSessions(response.data.Items);
        }
        loadSessions();

    }, [startDate]);

    return (
        <div className="main-container">
            <DatePicker
                className="date"
                selected={startDate}
                onChange={date => setStartDate(date)}
                minDate={new Date()}
                maxDate={addDays(new Date(), 7)}
                dateFormat="dd/MM"
            />
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
                                <p>{session.Hour}</p>
                            </footer>
                        </li>
                    ))}
                </ul>) :(
                <div>
                    <div className="empty"> Não há sessões cadastradas para esse dia :(</div>
                </div>)}
        </div>
    );
}