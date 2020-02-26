import React, { useState } from 'react';
import api from '../../services/api';
import logo from '../../assets/logo.png'
import { func } from 'prop-types';
import Input from '../../components/inputs/input';
import { Form } from '@unform/web';


export default function User({ history }) {

    var manager = localStorage.getItem('Manager');

    async function handleSubmit(user) {

        if (user.password != user.confirmedPassword) {
            alert("As senhas não são iguais!")
            return;
        }

        const response = await api.post('api/user', user);

        const codeResponse = 200;

        if (response.status === codeResponse) {
            history.push(`/session/`)
        }
    }

    function handleLogin() {
        history.push(``);
    }

    return (
        <div className="login-container">           
            <Form onSubmit={handleSubmit}>
                <img src={logo} alt="logo" />
                <Input placeholder="Digite seu nome" name="name" />
                <Input placeholder="Digite seu e-mail" name="email" type="email" />
                <Input placeholder="Digite sua senha" name="password" type="password" />
                <Input placeholder="Confirme sua senha" name="confirmedPassword" type="password" />
                <button className="login" type="submit">Cadastrar</button>
                {manager === 'true' ? ''
                    : <button className="createAccount" onClick={handleLogin}>Já tenho uma conta</button>}
            </Form>
        </div>
    );
}