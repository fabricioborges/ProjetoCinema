import React, { useState, useEffect } from "react";
import api from '../../services/api';
import './snack.css'
import Menu from '../../components/menu/menu';
import MenuCustomer from '../../components/menu/menu-customer';
import { confirmAlert } from 'react-confirm-alert';
import 'react-confirm-alert/src/react-confirm-alert.css'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const MsgSuccess = ({ closeToast }) => (
    <div>
        Registro excluído com sucesso!
    </div>
)

const MsgError = ({ closeToast }) => (
    <div>
        Não foi possível excluir o registro!
    </div>
)

export default function Snack({ history }) {

    var [snacks, setSnack] = useState([]);
    const [value, setValue] = useState(0);
    var valueOfSnacks = 0;
    var manager = localStorage.getItem('Manager');
  
    useEffect(() => {
        async function loadSnacks() {

            const response = await api.get(`api/snack/`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            })
            setSnack(response.data.Items);
        }
        loadSnacks();
    }, [])
   
    async function handlePlus(snack) {
        const index = snacks.indexOf(snack);
        snack.Quantity = snack.Quantity + 1;
        var snackQuantity = [];
        snacks[index] = snack;
        snacks.map(x => snackQuantity.push(x))

        setSnack(snackQuantity);

        valueOfSnacks = value + snackQuantity[index].Price;
        setValue(valueOfSnacks);
    }

    async function handleRemove(snack) {
        const index = snacks.indexOf(snack);
        if (snack.Quantity == 0)
            return;
        snack.Quantity = snack.Quantity - 1;
        var snackQuantity = [];
        snacks[index] = snack;
        snacks.map(x => snackQuantity.push(x))

        setSnack(snackQuantity);
        valueOfSnacks = value - snackQuantity[index].Price;
        setValue(valueOfSnacks);
    }

    async function handleConfirmed() {
        localStorage.setItem('snacks', JSON.stringify(snacks));
        localStorage.setItem('snacksValue', value);
        history.push('/ticket-buy/');
    }

    async function handleNew() {
        history.push('/snack-new/');
    }

    function handleToEdit(id) {
        history.push(`/snack-new/${id}`)
    }

    function handleToDelete(snack) {
        const options = {
            title: 'Excluir registro',
            message: 'Deseja excluir o snack selecionado?',
            buttons: [
                {
                    label: 'Sim',
                    onClick: () => removeSnack(snack)
                },
                {
                    label: 'Não',
                    onClick: () => onclose
                }
            ],
            childrenElement: () => <div />,
            closeOnEscape: true,
            closeOnClickOutside: true,
            onClickOutside: () => { },
            onKeypressEscape: () => { }
        };

        confirmAlert(options);
    }

    async function removeSnack(snack) {
        try {
            const id = snack.Id;

            await api.delete(`api/snack`, { data: { id } }, {
                headers: {
                    token: sessionStorage.getItem('token'),
                    contenttype: 'application/json'
                }
            });

            const index = snacks.indexOf(snack);
            var snacksRefresh = [];

            if (index > -1) {
                delete snacks[index];

                snacks.map(x => snacksRefresh.push(x));
            }

            setSnack(snacksRefresh);
            toast.success(<MsgSuccess />);

        }
        catch (err) {
            toast.error(<MsgError />);
        }
    }

    return (
        <div id="App">
            {manager === 'true' ? <Menu  {...history} /> : <MenuCustomer  {...history}/>}
            <ToastContainer />
            <div className="snack-container">
                {manager === 'true' ? <button className="new" onClick={handleNew}>Adicionar Snack</button> : ''}
                {snacks.length > 0 ?
                    (<div><ul>
                        {snacks.map(snack => (
                            <li key={snack.Id}>
                                <img src={snack.Image} alt="image" />
                                <footer>
                                    <strong>{snack.Name}</strong>
                                    <p>Preço: R${snack.Price}</p>
                                    {manager === 'true' ? '' : <p>Quantidade: {snack.Quantity}</p>}
                                    {manager === 'true' ? <button onClick={() => handleToEdit(snack.Id)}>Editar</button> : <button onClick={() => handlePlus(snack)}>Adicionar+</button>}
                                    {manager === 'true' ? <button onClick={() => handleToDelete(snack)}>Excluir</button> : <button className="remove" onClick={() => handleRemove(snack)}>Remover-</button>}
                                </footer>
                            </li>
                        ))}
                    </ul>
                        {manager === 'true' ? '' : <p>Preço: R${value}</p>}
                        {manager === 'true' ? '' : <button className="confirmed" onClick={handleConfirmed}> Adicionar Itens</button>}
                    </div>)
                    : (
                        <div>
                            <div className="empty"> Não há snacks disponíveis :(</div>
                        </div>)}
            </div>
        </div>
    );
}