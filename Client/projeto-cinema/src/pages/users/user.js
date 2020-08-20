import React, { useEffect, useState } from 'react';
import api from '../../services/api';
import logo from '../../assets/logo.png';
import Menu from '../../components/menu/menu';
import MenuCustomer from '../../components/menu/menu-customer';
import './user.css';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const MsgSuccess = ({ closeToast }) => (
    <div>
        Usuário cadastrado com sucesso!
    </div>
)

const MsgError = ({ closeToast }) => (
    <div>
        Ocorreu um error ao gravar o registro
    </div>
)

export default function User({ history, match }) {

    var manager = localStorage.getItem('Manager');
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmedPassword, setConfirmedPAssword] = useState('');
    const [accessLevel, setAccessLevel] = useState(0);

    useEffect(() => {

        if (match.params.id) {
            async function loadUser() {

                const response = await api.get(`api/user/${match.params.id}`, {
                    headers: {
                        token: sessionStorage.getItem('token')
                    }
                });
                setAccessLevel(response.data.AccessLevel);  
                setName(response.data.Name);
                setPassword(response.data.Password);
                setEmail(response.data.Email);  
                setConfirmedPAssword(response.data.Password);                       
            }
            loadUser();
        }
    }, []);

    async function handleSubmit(e) {
        e.preventDefault();

        if (password != confirmedPassword) {
            alert("As senhas não são iguais!")
            return;
        }

        try {
            var response;
            const codeResponse = 200;

            if (match.params.id) {
                const id = match.params.id;
                response = await api.put('api/user', {
                    id,                    
                    name,
                    email,
                    accessLevel,
                    password
                });

                if (response.status === codeResponse) {
                    toast.success(<MsgSuccess />, { autoClose: 5000 });
                    history.push(`/userview/`)
                }
            }
            else {
                debugger
               
                response = await api.post('api/user', {
                    name,
                    email,
                    accessLevel,
                    password
                });
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

    function handlePermision(option) {
        setAccessLevel(option);
    }

    return (
        <div id="App">
            {manager === 'true' ? <Menu {...history} /> : manager === 'false' ? <MenuCustomer {...history} /> : ''}
            <div className="user-container">
                <form onSubmit={handleSubmit}>
                    <img src={logo} alt="logo" />
                    <input placeholder="Digite seu nome" name="name"
                        value={name}
                        onChange={e => setName(e.target.value)} />
                    <input placeholder="Digite seu e-mail" name="email" 
                        type="email" 
                        value={email}
                        onChange={e => setEmail(e.target.value)} />
                    {manager === 'true' ?
                        <select value={accessLevel} onChange={e => handlePermision(e.target.value)} >
                            <option>Selecione um nível de permisionamento</option>
                            <option value={1}>Cliente</option>
                            <option value={2}>Atendente</option>
                            <option value={3}>Gerente</option>
                        </select> : ''}
                    <input placeholder="Digite sua senha" name="password" 
                        type="password" 
                        value={password}
                        onChange={e => setPassword(e.target.value)} />
                    <input placeholder="Confirme sua senha" name="confirmedPassword" 
                        type="password" 
                        value={confirmedPassword}
                        onChange={e => setConfirmedPAssword(e.target.value)}/>
                    <button className="user" type="submit">Cadastrar</button>
                    {match.params.id ? '' : <button className="accountExists" onClick={handleLogin}>Já tenho uma conta</button>}
                </form>
            </div>
        </div>
    );
}