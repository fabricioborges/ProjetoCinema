import React, { useState, useEffect } from 'react';
import api from '../../services/api';
import { ToastContainer, toast } from 'react-toastify';
import './seat.css';
import MenuCustomer from '../../components/menu/menu-customer';

const MsgInvalid = ({ closeToast }) => (
    <div>
        Necessário selecionar pelo menos um assento!
    </div>
)


export default function Seat({ match, history }) {

    var [seats, setSeats] = useState([]);
    const [value, setValue] = useState();
    const [seatSelected, setSeatSelected] = useState([]);

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

        setSeatSelected(selected);
        setValue(selected.length * 10);

    }

    async function handleConfirmed() {

        if (seatSelected.length === 0) {
            toast.error(<MsgInvalid />, { autoClose: 5000 });
            return;
        }

        localStorage.setItem('seats', JSON.stringify(seatSelected));
        localStorage.setItem('seatsToPersist', JSON.stringify(seats))
        localStorage.setItem('seatsValue', JSON.stringify(value));
        history.push(`/snack/`)
    }

    return (
        <div className="App">
            <MenuCustomer  {...history} />
            <ToastContainer />
            <div className="seat-container">
                <h1>Selecionar assentos</h1>
                {seats.length > 0 ?
                    (<div>
                        <ul>
                            {seats.map(seat => (
                                <li style={{ background: seat.IsAvailable === true ? 'rgb(17, 182, 91)' : seat.IsSelected === true ? 'blue' : 'red' }} onChange={handleSeatsSelected} key={seat.Id}>
                                    {seat.IsAvailable}
                                    <footer>
                                        <button disabled={!seat.IsAvailable && !seat.IsSelected} style={{
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
                    ) : ''}
            </div>
        </div>
    )
}