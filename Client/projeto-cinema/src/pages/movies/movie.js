import React, { useState, useEffect } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import api from '../../services/api';
import './movie.css';
import { addDays } from "date-fns";

export default function Movie() {

    const [movies, setMovies] = useState([]);
    const [startDate, setStartDate] = useState(new Date());
        
    useEffect(() => {
        var paramDate = new Date(Date.UTC(startDate.getFullYear(), startDate.getMonth(), startDate.getDate()));
        const dateExhibition = paramDate.toJSON();    
        
        async function loadMovies() {
            const response = await api.get(`api/movie?$filter=EndDate ge ${dateExhibition}`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            })
            setMovies(response.data.Items);            
        }
        loadMovies();
        
    }, [startDate]);

    return (
        <div className="main-container">
            <DatePicker
                className="date"
                selected={startDate}
                onChange={date => setStartDate(date)}
                minDate={new Date()}
                maxDate={addDays(new Date(), 5)}
                dateFormat="dd/MM"
            />
            <ul>
                {movies.map(movie => (
                    <li key={movie.Id}>
                        <img src={movie.Image} alt="image" />
                        <footer>
                            <strong>{movie.Title}</strong>
                            <p>{movie.Description}</p>
                            <p>{movie.Duration}</p>
                            <p>{movie.AnimationType == 1 ? '3D' : '2D'}</p>
                            <p>{movie.TypeAudio == 1 ? 'Dublado' : 'Legendado'}</p>
                        </footer>
                    </li>
                ))}
            </ul>
        </div>

    );
}