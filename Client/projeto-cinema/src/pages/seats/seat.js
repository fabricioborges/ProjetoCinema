import React, { useState, useEffect, useImperativeHandle } from 'react';
import api from '../../services/api';
import './seat.css';

export default function Seat({ match, history }) {

    var [seats, setSeats] = useState([]);
    const [value, setValue] = useState();

    useEffect(() => {
        async function loadSeats() {

            const response = await api.get(`api/movieTheater/${match.params.movieTheaterId}`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            })
            setSeats(response.data.Seats);
            setValue(0);
        }
        loadSeats();
    }, []);

    async function handleSeatsSelected(seat) {
        const index = seats.indexOf(seat);
        seat.IsAvailable = !seat.IsAvailable;
        seat.IsSelected = !seat.IsSelected;
        var seatSeatsSelected = [];
        seats[index] = seat;

        seats.map(x => seatSeatsSelected.push(x))

        setSeats(seatSeatsSelected);

        var selected = seatSeatsSelected.filter(x => x.IsSelected === true);
        localStorage.setItem('seats', JSON.stringify(selected));
        setValue(selected.length * 10);
       
    }

    async function handleConfirmed() {
        const response = await api.put(`api/seat/`, seats, {
            headers: {
                token: sessionStorage.getItem('token')
            }
        })

        if (response.data === true) {
            localStorage.setItem('seatsValue', JSON.stringify(value));
            history.push(`/snack/`)
        }
    }

    return (
        <div className="seat-container">
            <h1>Selecionar assentos</h1>
            {seats.length > 0 ?
                (<div>
                    <ul>
                        {seats.map(seat => (
                            <li style={{ background: seat.IsAvailable === true ? 'rgb(17, 182, 91)' : seat.IsSelected === true ? 'blue' : 'red' }} onChange={handleSeatsSelected} key={seat.Id}>
                                {seat.IsAvailable}
                                <footer>
                                    <button style={{
                                        background: seat.IsAvailable === true ? 'rgb(17, 182, 91)'
                                            : seat.IsSelected === true ? 'blue' : 'red'
                                    }} onClick={() => handleSeatsSelected(seat)}>{seat.Number}</button>
                                </footer>
                            </li>
                        ))}
                    </ul>
                    <p value={value}>Preço: R${value}</p>
                    <button className="confirmed" onClick={handleConfirmed}> Confirmar</button>
                </div>
                ) : (
                    <div>
                        <div className="empty"> Não há sessões cadastradas para esse dia :(</div>
                    </div>)}
        </div>
    )
}