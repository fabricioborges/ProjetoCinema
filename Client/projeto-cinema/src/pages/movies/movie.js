import React from 'react';
import api from '../../services/api';
import logo from '../../assets/logo.png';
import './movie.css';
import Input from '../../components/inputs/input';
import { Form } from '@unform/web';
import Menu from '../../components/menu/menu';

export default function Movie({ history }) {

    async function handleSubmit(movie) {

        const response = await api.post('api/movie', movie);

        const codeResponse = 200;

        if (response.status === codeResponse) {
            history.push(``)
        }
    }

    return (
        <div id="App">
            <Menu />
            <div className="movie-container">
                <Form onSubmit={handleSubmit}>
                    <img src={logo} alt="logo" />
                    <Input placeholder="Digite o título" name="title" />
                    <Input placeholder="Digite a descrição" name="description" type="text" />
                    <Input placeholder="Digite a url da imagem" name="image" type="text" />
                    
                    <label>Insira a duração do filme</label>
                    <Input name="duration" type="time" />
                    
                    <label>Digite a data de estreia</label>
                    <Input type="date" name="debutDate"/>
                    
                    <label>Digite a data de final</label>
                    <Input name="endDate" type="date"/>
                    
                    <button className="movie" type="submit">Cadastrar</button>
                </Form>
            </div>
        </div>
    );
}