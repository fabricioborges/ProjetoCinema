import React, { useState, useEffect } from "react";
import api from '../../services/api';
import './snack-new.css'
import logo from '../../assets/logo.png'

export default function SnackNew({history}){

    const [name, setName] = useState('')
    const [price, setPrice] = useState('')
    const [image, setImage] = useState('')    

    async function handleSubmit(event) {
        event.preventDefault();

        const snack = {
            name: name,
            price: price,
            image: image          
        }

        const response = await api.post('api/snack', snack);

        const codeResponse = 200;

        if (response.status === codeResponse) {
            history.push(``)
        }
    }

    return (
        <div className="login-container">
            <form onSubmit={handleSubmit}>
                <img src={logo} alt="logo" />
                <input placeholder="Digite nome do snack"
                    value={name}
                    onChange={e => setName(e.target.value)}
                />
                <input placeholder="Insira o preço do snack"
                    type="number"
                    value={price}
                    onChange={e => setPrice(e.target.value)}
                />
                <input placeholder="Insira a url da imagem"
                    type="text"
                    value={image}
                    onChange={e => setImage(e.target.value)}
                />
                <button className="login" type="submit">Cadastrar</button>                
            </form>
        </div>
    );
}