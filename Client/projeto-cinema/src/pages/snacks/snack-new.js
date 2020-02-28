import React, { useEffect, useRef } from "react";
import api from '../../services/api';
import './snack-new.css'
import logo from '../../assets/logo.png'
import Input from '../../components/inputs/input';
import { Form } from '@unform/web';
import Menu from '../../components/menu/menu';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const MsgSuccess = ({ closeToast }) => (
    <div>
        Snack cadastrado com sucesso!
        </div>
)

const MsgError = ({ closeToast }) => (
    <div>
        Ocorreu um error ao gravar o registro
    </div>
)

export default function SnackNew({ history, match }) {

    const formRef = useRef(null);

    useEffect(() => {

        if (match.params.id) {
            async function loadSnacks() {

                const response = await api.get(`api/snack/${match.params.id}`, {
                    headers: {
                        token: sessionStorage.getItem('token')
                    }
                });

                setTimeout(() => {
                    formRef.current.setData({
                        name: response.data.Name,
                        price: response.data.Price,
                        image: response.data.Image,
                    })
                }, 500)
            }
            loadSnacks();
        }
    });

    async function handleSubmit(snack) {
        try {
            var response;
            const codeResponse = 200;

            if (match.params.id) {
                snack.id = match.params.id;
                response = await api.put('api/snack', snack);

                if (response.status === codeResponse) {
                    toast.success(<MsgSuccess />, { autoClose: 5000 });
                }
            }
            else {
                response = await api.post('api/snack', snack);
                toast.success(<MsgSuccess />, { autoClose: 5000 });
            }

            history.push(`/snack/`);
        }
        catch (err) {
            toast.error(<MsgError />);
        }
    }

    return (
        <div id="App">
            <Menu />
            <div className="login-container">
                <Form ref={formRef} onSubmit={handleSubmit}>
                    <img src={logo} alt="logo" />
                    <Input placeholder="Digite nome do snack" name="name" />
                    <Input placeholder="Insira o preço do snack" name="price" type="number" />
                    <Input placeholder="Insira a url da imagem" name="image" type="text" />
                    <button className="login" type="submit">Cadastrar</button>
                </Form>
            </div>
        </div>
    );
}