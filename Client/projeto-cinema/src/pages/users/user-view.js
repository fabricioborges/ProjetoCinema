import React, { useState, useEffect } from 'react';
import './user-view.css';
import api from '../../services/api';
import Menu from '../../components/menu/menu';
import { confirmAlert } from 'react-confirm-alert';
import 'react-confirm-alert/src/react-confirm-alert.css'
import { ToastContainer, toast } from 'react-toastify';
import Pagination from "@material-ui/lab/Pagination";
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

export default function UserView({ history }) {

    const [users, setUsers] = useState([]);
    const [page, setPage] = useState(1);
    const [count, setCount] = useState(0)

    useEffect(() => {
        async function loadusers() {

            const params = getRequestParams();

            const response = await api.get(`api/user${params}`, {
                headers: {
                    token: sessionStorage.getItem('token')
                },
            });

            setUsers(response.data.Items.slice(0, 10));           
        }
        loadusers();
    }, [page]);

    useEffect(() => {
        async function loadCount(){
            const response = await api.get(`api/user?$count=true&$top=0`, {
                headers: {
                    token: sessionStorage.getItem('token')
                },
            });
            console.log(response);
            const getCount = Math.ceil(response.data.Count / 10);
            setCount(getCount)
        }

        loadCount();
    }, [])

    function getRequestParams() {
               
        if (page != 1 ) {
            const skip = (page * 10) - 10;
            const params = `?$skip=${skip}&$top=10`
            return params;
        }
        return '';
    };

    const handlePageChange = (event, value) => {
        setPage(value);
    };

    function handleToEdit(id) {
        history.push(`/user/${id}`)
    }

    function handleToNew() {
        history.push(`/user/`)
    }

    function handleToDelete(user) {
        const options = {
            title: 'Excluir registro',
            message: 'Deseja excluir o usuário selecionado?',
            buttons: [
                {
                    label: 'Sim',
                    onClick: () => removeUser(user)
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

    async function removeUser(user) {
        try {
            const id = user.Id;

            await api.delete(`api/user`, { data: { id } }, {
                headers: {
                    token: sessionStorage.getItem('token'),
                    contenttype: 'application/json'
                }
            });

            const index = users.indexOf(user);
            var usersRefresh = [];

            if (index > -1) {
                delete users[index];

                users.map(x => usersRefresh.push(x));
            }

            setUsers(usersRefresh);
            toast.success(<MsgSuccess />);

        }
        catch (err) {
            toast.error(<MsgError />);
        }
    }

    return (
        <div id="App">
            <Menu {...history} />
            <ToastContainer />
            <div className="user-container-view">
                <button className="new" onClick={() => handleToNew()}>Adicionar</button>                
                {users.length > 0 ?
                    (<ul>
                        {users.map(user => (
                            <li key={user.Id}>
                                <footer>
                                    <strong>{user.Name}</strong>
                                    <p>{user.Email}</p>
                                    <button className="edit" onClick={() => handleToEdit(user.Id)}>Editar</button>
                                    <button className="delete" onClick={() => handleToDelete(user)}>Excluir</button>
                                </footer>
                            </li>
                        ))}
                    </ul>) : <div></div>
                }
                <Pagination
                    className="my-3"
                    count={count}
                    page={page}
                    siblingCount={1}
                    boundaryCount={1}
                    variant="outlined"
                    shape="rounded"
                    onChange={handlePageChange}
                />

            </div>
        </div>
    )
}