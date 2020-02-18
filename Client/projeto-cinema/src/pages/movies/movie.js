import React, { useState } from 'react';
import api from '../../services/api';
import logo from '../../assets/logo.png'
import './movie.css'

export default function Movie({ history }) {

    const [title, setTitle] = useState('')
    const [description, setDescription] = useState('')
    const [image, setImage] = useState('')
    const [duration, setDuration] = useState('')
    const [debutDate, setDebutDate] = useState('')
    const [endDate, setEndDate] = useState('')

    async function handleSubmit(event) {
        event.preventDefault();

        const movie = {
            title: title,
            description: description,
            image: image,
            duration: duration,
            debutDate: debutDate,
            endDate: endDate
        }

        const response = await api.post('api/movie', movie);

        const codeResponse = 200;

        if (response.status === codeResponse) {
            history.push(``)
        }
    }

    return (
        <div className="movie-container">
            <form onSubmit={handleSubmit}>
                <img src={logo} alt="logo" />
                <input placeholder="Digite o título"
                    value={title}
                    onChange={e => setTitle(e.target.value)}
                />
                <input placeholder="Digite a descrição"
                    type="text"
                    value={description}
                    onChange={e => setDescription(e.target.value)}
                />
                <input placeholder="Digite a url da imagem"
                    type="text"
                    value={image}
                    onChange={e => setImage(e.target.value)}
                />
                <label>Insira a duração do filme</label>
                <input placeholder="Digite a url da imagem"
                    type="time"
                    value={duration}
                    onChange={e => setDuration(e.target.value)}
                />
                <label>Digite a date de estreia</label>
                <input placeholder="Digite a date de estreia"
                    type="date"
                    value={debutDate}
                    onChange={e => setDebutDate(e.target.value)}
                />
                <label>Digite a date de final</label>
                <input placeholder="Digite a date de final"
                    type="date"
                    value={endDate}
                    onChange={e => setEndDate(e.target.value)}
                />
                <button className="movie" type="submit">Cadastrar</button>

            </form>
        </div>
    );
}