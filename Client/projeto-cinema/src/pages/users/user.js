import React, { useState } from 'react';
import api from '../../services/api';
import logo from '../../assets/logo.png'
import { func } from 'prop-types';

export default function User({ history }) {

    const [username, setUserName] = useState('')
    const [useremail, setUserEmail] = useState('')
    const [userpassword, setUserPassword] = useState('')
    const [accessLevel, setAccessLevel] = useState(0);
    var manager = localStorage.getItem('Manager');
    async function handleSubmit(event) {
        event.preventDefault();

        const user = {
            name: username,
            email: useremail,
            password: userpassword,
            accessLevel: accessLevel
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

    async function handleUser(access) {
        console.log(access)
        setAccessLevel(access)
    }

    return (
        <div className="login-container">
            <form onSubmit={handleSubmit}>
                <img src={logo} alt="logo" />
                <input placeholder="Digite seu nome"
                    value={username}
                    onChange={e => setUserName(e.target.value)}
                />
                <input placeholder="Digite seu e-mail"
                    type="email"
                    value={useremail}
                    onChange={e => setUserEmail(e.target.value)}
                />
                <input placeholder="Digite sua senha"
                    type="password"
                    value={userpassword}
                    onChange={e => setUserPassword(e.target.value)}
                />
                <button className="login" type="submit">Cadastrar</button>
                {manager === 'true' ? ''
                    : <button className="createAccount" onClick={handleLogin}>Já tenho uma conta</button>}

            </form>
        </div>
    );
}