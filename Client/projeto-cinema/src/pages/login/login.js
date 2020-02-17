import React, { useState } from 'react';
import './login.css';
import api from '../../services/api';

import logo from '../../assets/logo.png'

export default function Login({ history }) {

    const [useremail, setUserEmail] = useState('')
    const [userpassword, setUserPassword] = useState('')

    async function handleSubmit(event) {
        event.preventDefault();

        const user = {
            email: useremail,
            password: userpassword
        }

        const response = await api.post('api/login', user);

        if(response.status === 200){
            sessionStorage.setItem('token', response.data)
            history.push(`/movie/`);
        }
    }

    function handleCreateAccount(event){
        history.push(`/user/`);
    }

    return (
        <div className="login-container">
            <form onSubmit={handleSubmit}>
                <img src={logo} alt="logo" />
                <input placeholder="Digite seu e-mail"
                    value={useremail}
                    onChange={e => setUserEmail(e.target.value)}
                />
                <input placeholder="Digite sua senha"
                    type="password"
                    value={userpassword}
                    onChange={e => setUserPassword(e.target.value)}
                />                
                <button className="login" type="submit">Logar</button>
                <button className="createAccount" onClick={handleCreateAccount}>Criar conta</button>
            </form>
        </div>
    )
}