import React from 'react';
import './login.css';
import api from '../../services/api';
import Input from '../../components/inputs/input'
import logo from '../../assets/logo.png'
import { Form } from '@unform/web';

export default function Login({ history }) {

    async function handleSubmit(user) {

        const response = await api.post('api/login', user);

        if (response.status === 200) {
            sessionStorage.setItem('token', response.data)
            const userAuthenticated = await api.get(`api/user?$filter=Email eq '${user.email}'`);
            localStorage.setItem('User', JSON.stringify(userAuthenticated))
            if (userAuthenticated.data.Items[0].AccessLevel === 3)
                history.push(`/usermanager/${userAuthenticated.data.Items[0].Id}`);
            else
                history.push(`/session/`);
        }
    }

    function handleCreateAccount(event) {
        history.push(`/user/`);
    }

    return (
        <div className="login-container">
            <Form className="form" onSubmit={handleSubmit}>
                <img src={logo} alt="logo" />
                <Input name="email" placeholder="E-mail" />
                <Input name="password" type="password" placeholder="Digite sua senha" />
                <button className="login" type="submit">Logar</button>
                <button className="createAccount" onClick={handleCreateAccount}>Criar conta</button>
            </Form>
        </div>
    )
}