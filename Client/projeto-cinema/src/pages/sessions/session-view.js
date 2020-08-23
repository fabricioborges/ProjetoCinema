import React, { useState, useEffect } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import api from '../../services/api';
import './session-view.css';
import { addDays } from "date-fns";
import Menu from '../../components/menu/menu';
import MenuCustomer from '../../components/menu/menu-customer';
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

export default function SessionView({ history }) {
    var manager = localStorage.getItem('Manager');
    const [sessions, setSessions] = useState([]);
    const [startDate, setStartDate] = useState(new Date());
    const [page, setPage] = useState(0);
    const [count, setCount] = useState(0);
    const [refresh, setRefresh] = useState(true);

    useEffect(() => {
        async function loadCount() {
            const paramDate = new Date(Date.UTC(startDate.getFullYear(), startDate.getMonth(), startDate.getDate()));
            const dateExhibition = paramDate.toJSON();
            const response = await api.get(`api/session?$count=true&$top=0&$filter=EndDate ge ${dateExhibition}`, {
                headers: {
                    token: sessionStorage.getItem('token')
                },
            });

            const getCount = Math.ceil(response.data.Count / 10);
            setCount(getCount)
            setRefresh(false);
            if (count < page) {
                setPage(count);
            }
        }

        loadCount();
    }, [refresh])

    useEffect(() => {
        const params = getRequestParams();
        const paramDate = new Date(Date.UTC(startDate.getFullYear(), startDate.getMonth(), startDate.getDate()));
        const dateExhibition = paramDate.toJSON();

        async function loadSessions() {
            const response = await api.get(`api/session${params}&$filter=EndDate ge ${dateExhibition}`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            })
            setSessions(response.data.Items);
        }
        loadSessions();

    }, [startDate, page]);

    function getRequestParams() {

        if (page > 1) {
            const skip = (page * 10) - 10;
            const params = `?$skip=${skip}&$top=10`
            return params;
        }

        return '?$top=10';
    };

    const handlePageChange = (event, value) => {
        setPage(value);
    };

    async function handleToTicket(item) {
        history.push(`/ticket/${item}`);
    }

    function handleToEdit(id) {
        history.push(`/session/${id}`)
    }

    function handleToDelete(session) {
        const options = {
            title: 'Excluir registro',
            message: 'Deseja excluir a sessão selecionado?',
            buttons: [
                {
                    label: 'Sim',
                    onClick: () => removeSession(session)
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

    async function removeSession(session) {
        try {
            const id = session.Id;

            await api.delete(`api/session`, { data: { id } }, {
                headers: {
                    token: sessionStorage.getItem('token'),
                    contenttype: 'application/json'
                }
            });

            const index = sessions.indexOf(session);
            var sessionsRefresh = [];

            if (index > -1) {
                delete sessions[index];

                sessions.map(x => sessionsRefresh.push(x));
            }

            setSessions(sessionsRefresh);
            toast.success(<MsgSuccess />);
            setRefresh(true);
        }
        catch (err) {
            toast.error(<MsgError />);
        }
    }

    function handleToNew() {
        history.push(`/session/`)
    }

    return (
        <div id="App">
            {manager === 'true' ? <Menu {...history} /> : <MenuCustomer {...history} />}
            <ToastContainer />
            <div className="session-container-view">
                <div>
                    {manager === 'true' ? <button className="new" onClick={() => handleToNew()}>Adicionar</button> : ''}
                </div>

                <DatePicker
                    className="date"
                    selected={startDate}
                    onChange={date => setStartDate(date)}
                    minDate={new Date()}
                    maxDate={addDays(new Date(), 7)}
                    dateFormat="dd/MM"
                />
                {sessions.length > 0 ?
                    (<>
                        <ul>
                            {sessions.map(session => (
                                <li key={session.Id}>
                                    <img src={session.Movie.Image} alt="image" />
                                    <footer>
                                        <strong>{session.Movie.Title}</strong>
                                        <p>{session.Movie.Description}</p>
                                        <p>{session.Duration}</p>
                                        <p>{session.AnimationType == 1 ? '3D' : '2D'}</p>
                                        <p>{session.TypeAudio == 1 ? 'Dublado' : 'Legendado'}</p>
                                        <p>{session.MovieTheater.Name}</p>
                                        <p className="dateSession">{session.Hour}</p>
                                        {manager === 'true' ? <div>
                                            <button className="edit" onClick={() => handleToEdit(session.Id)}>Editar</button>
                                            <button className="delete" onClick={() => handleToDelete(session)}>Excluir</button>
                                        </div>
                                            : <button className="buy" onClick={() => handleToTicket(session.Id)}>Comprar</button>}

                                    </footer>
                                </li>
                            ))}
                        </ul>
                        <Pagination
                            className="my-3"
                            count={count}
                            page={page}
                            siblingCount={1}
                            boundaryCount={1}
                            onChange={handlePageChange}
                        /></>) : (
                        <div>
                            <div className="empty"> Não há sessões cadastradas para esse dia :(</div>
                        </div>)}
            </div>

        </div>
    );
}