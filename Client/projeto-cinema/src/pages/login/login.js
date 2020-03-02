import React from 'react';
import './login.css';
import api from '../../services/api';
import Input from '../../components/inputs/input'
import logo from '../../assets/logo.png'
import { Form } from '@unform/web';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const MsgError = ({ closeToast }) => (
    <div>
        Login e senha incorretos!
    </div>
)

export default function Login({ history }) {

    async function handleSubmit(user) {
        try{
            const response = await api.post('api/login', user);

            if (response.status === 200) {
                sessionStorage.setItem('token', response.data)
                const userAuthenticated = await api.get(`api/user?$filter=Email eq '${user.email}'`);
                localStorage.setItem('User', JSON.stringify(userAuthenticated))
                if (userAuthenticated.data.Items[0].AccessLevel === 3) {
                    localStorage.setItem('Manager', JSON.parse(true));
                    history.push(`/userview/`);
                }
                else {
                    localStorage.setItem('Manager', JSON.parse(false));
                    history.push(`/sessionview/`);
                }
            }
        }
        catch(err){
            toast.error(<MsgError />)
        }
    }

    function handleCreateAccount(event) {
        history.push(`/user/`);
    }

    return (
        <div className="login-container">
            <ToastContainer />
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