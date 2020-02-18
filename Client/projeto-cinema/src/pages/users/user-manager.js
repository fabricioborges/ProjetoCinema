import React, { useState, useLayoutEffect } from 'react';
import api from '../../services/api';
import './user-manager.css'

export default function UserManager({ history }) {

    const [username, setUserName] = useState('')
    const [useremail, setUserEmail] = useState('')
    const [userpassword, setUserPassword] = useState('')

    async function handleSubmit(event) {
        event.preventDefault();

        const user = {
            name: username,
            email: useremail,
            password: userpassword
        }

        const response = await api.post('api/user', user);

        const codeResponse = 200;

        if (response.status === codeResponse) {
            history.push(``)
        }
    }

    function handleLogin(event) {

        history.push(``);
    }

    async function handleToManager(path){
        localStorage.setItem('Manager', true)
        history.push(path);
    }

    return (
        <div className="user-manager-container">
            <h1>Escolha uma das opções de gerenciamento</h1>
            <ul>
                <li onClick={() => handleToManager('/movie/')}><strong>Filmes</strong></li>
                <li onClick={() => handleToManager('/user/')}><strong>Usuários</strong></li>
                <li onClick={() => handleToManager('/session/')}><strong>Sessões</strong></li>
                <li onClick={() => handleToManager('/snack/')}><strong>Snacks</strong></li>
            </ul>

        </div>
    );

}