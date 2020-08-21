import React, { useEffect, useRef, useState } from 'react';
import api from '../../services/api';
import logo from '../../assets/logo.png';
import './movie.css';
import Input from '../../components/inputs/input';
import { Form } from '@unform/web';
import Menu from '../../components/menu/menu';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const MsgSuccess = ({ closeToast }) => (
    <div>
        Filme cadastrado com sucesso!
        </div>
)

const MsgError = ({ closeToast }) => (
    <div>
        Ocorreu um error ao gravar o registro
    </div>
)

const MsgValidator = ({ closeToast }) => (
    <div>
        Já existe um filme cadastrado com esse título!
    </div>
)

export default function Movie({ history, match }) {

    const formRef = useRef(null);
    const [movies, setMovies] = useState([]);

    useEffect(() => {

        if (match.params.id) {
            async function loadMovie() {

                const response = await api.get(`api/movie/${match.params.id}`, {
                    headers: {
                        token: sessionStorage.getItem('token')
                    }
                });

                setTimeout(() => {
                    formRef.current.setData({
                        title: response.data.Title,
                        description: response.data.Description,
                        image: response.data.Image,
                        duration: response.data.Duration,
                        debutDate: response.data.DebutDate.slice(0, 10),
                        endDate: response.data.EndDate.slice(0, 10)
                    })
                }, 500)
            }
            loadMovie();
        }
    });

    useEffect(() => {
        async function loadMovies(){
            const response = await api.get('api/movie/', {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            });

            setMovies(response.data.Items);
        }

        loadMovies();
    }, [])

    async function handleSubmit(movie) {
      
        if (movies.find(x => x.Title.toUpperCase() === movie.title.toUpperCase() && x.Id != match.params.id)){
            toast.error(<MsgValidator />, { autoClose: 5000 });
            return;
        }
        
        try {
            var response;

            if (match.params.id) {
                movie.id = match.params.id;
                response = await api.put('api/movie', movie);

            }
            else {
                response = await api.post('api/movie', movie);
            }
            const codeResponse = 200;

            if (response.status === codeResponse) {
                toast.success(<MsgSuccess />, { autoClose: 5000 });

                history.push(`/movieview/`)

            }
        }
        catch (err) {
            toast.error(<MsgError />, { autoClose: 5000 });
        }
    }

    return (
        <div id="App">
            <Menu  {...history}/>
            <ToastContainer />
            <div className="movie-container">
                <Form ref={formRef} onSubmit={handleSubmit}>
                    <img src={logo} alt="logo" />
                    <Input placeholder="Digite o título" name="title" />
                    <Input placeholder="Digite a descrição" name="description" type="text" />
                    <Input placeholder="Digite a url da imagem" name="image" type="text" />

                    <label>Insira a duração do filme</label>
                    <Input name="duration" type="time" />

                    <label>Digite a data de estreia</label>
                    <Input name="debutDate" type="date" />

                    <label>Digite a data de final</label>
                    <Input name="endDate" type="date" />

                    <button className="movie" type="submit">Cadastrar</button>
                </Form>
            </div>
        </div>
    );
}