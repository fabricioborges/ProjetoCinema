import React, { useState, useEffect } from "react";
import api from '../../services/api';
import './snack.css'

export default function Snack({history}) {

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

    async function handleConfirmed(){
        localStorage.setItem('snacks', JSON.stringify(snacks));
        localStorage.setItem('snacksValue', value);
        history.push('/ticket-buy/');
    }

    async function handleNew(){
        history.push('/snack-new/');
    }

    return (
        <div className="snack-container">
            {snacks.length > 0 ?
                (<div><ul>
                    {snacks.map(snack => (
                        <li key={snack.Id}>
                            <img src={snack.Image} alt="image" />
                            <footer>
                                <strong>{snack.Name}</strong>
                                <p>Preço: R${snack.Price}</p>
                                <p>Quantidade: {snack.Quantity}</p>
                                {manager === 'true' ? '' : <button onClick={() => handlePlus(snack)}>Adicionar +</button>}
                                {manager === 'true' ? '' : <button onClick={() => handleRemove(snack)}>Remover -</button>}
                            </footer>
                        </li>
                    ))}
                </ul>
                    <p>Preço: R${value}</p>
                    {manager === 'true' ? '' : <button className="confirmed" onClick={handleConfirmed}> Adicionar Itens</button>}
                </div>)                
                : (
                    <div>
                        <div className="empty"> Não há snacks disponíveis :(</div>
                    </div>)}
            {manager === 'true' ? <button className="createSnack" onClick={handleNew}> Novo Snack</button> : ''} 
        </div>
    );
}