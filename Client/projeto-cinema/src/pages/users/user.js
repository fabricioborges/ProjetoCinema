import React, { useEffect, useRef } from 'react';
import api from '../../services/api';
import logo from '../../assets/logo.png'
import Input from '../../components/inputs/input';
import { Form } from '@unform/web';
import Menu from '../../components/menu/menu';
import './user.css';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const MsgSuccess = ({ closeToast }) => (
    <div>
        Usuário cadastrado com sucesso!
        </div>
)

const options = [
    { value: 0, label: 'Cliente' },
    { value: 1, label: 'Atendente' },
    { value: 2, label: 'Gerente' }
]

const MsgError = ({ closeToast }) => (
    <div>
        Ocorreu um error ao gravar o registro
    </div>
)

export default function User({ history, match }) {

    var manager = localStorage.getItem('Manager');
    var permision = 0;
    const formRef = useRef(null);

    useEffect(() => {

        if (match.params.id) {
            async function loadMovies() {

                const response = await api.get(`api/user/${match.params.id}`, {
                    headers: {
                        token: sessionStorage.getItem('token')
                    }
                });

                setTimeout(() => {
                    formRef.current.setData({
                        name: response.data.Name,
                        email: response.data.Email,
                        password: response.data.Password,
                        confirmedPassword: response.data.Password,
                    })
                }, 500)
            }
            loadMovies();
        }
    });

    async function handleSubmit(user) {

        if (user.password != user.confirmedPassword) {
            alert("As senhas não são iguais!")
            return;
        }

        try {
            var response;
            const codeResponse = 200;

            if (match.params.id) {
                user.id = match.params.id;
                user.accessLevelEnum = permision;
                response = await api.put('api/user', user);

                if (response.status === codeResponse) {
                    toast.success(<MsgSuccess />, { autoClose: 5000 });
                    history.push(`/userview/`)
                }
            }
            else {
                user.accessLevelEnum = permision;
                response = await api.post('api/user', user);
                toast.success(<MsgSuccess />, { autoClose: 5000 });

                if (response.status === codeResponse) {
                    history.push(`/session/`)
                }
            }

        }
        catch (err) {
            toast.error(<MsgError />)
        }
    }

    function handleLogin() {
        history.push(``);
    }

    function handlePermision(option){
        permision = option;
    }

    return (
        <div id="App">
            {manager === true ? <Menu /> : ''}
            <div className="user-container">
                <Form ref={formRef} onSubmit={handleSubmit}>
                    <img src={logo} alt="logo" />
                    <Input placeholder="Digite seu nome" name="name" />
                    <Input placeholder="Digite seu e-mail" name="email" type="email" />
                    <select onChange={e => handlePermision(e.target.value)} >
                        <option selected disabled>Selecione um nível de permisionamento</option>
                       <option value={0}>Cliente</option>
                        <option value={1}>Atendente</option>
                        <option value={2}>Gerente</option>
                    </select>
                    <Input placeholder="Digite sua senha" name="password" type="password" />
                    <Input placeholder="Confirme sua senha" name="confirmedPassword" type="password" />
                    <button className="user" type="submit">Cadastrar</button>
                    <button className="accountExists" onClick={handleLogin}>Já tenho uma conta</button>
                </Form>
            </div>
        </div>
    );
}