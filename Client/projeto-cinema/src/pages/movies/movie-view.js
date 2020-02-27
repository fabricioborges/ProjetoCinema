import React, { useState, useEffect } from 'react';
import api from '../../services/api';
import logo from '../../assets/logo.png';

export default function MovieView(){
    
    const [movies, setMovies] = useState([]);
    
    useEffect(() => {
        async function loadMovies() {

            const response = await api.get(`api/movie/`, {
                headers: {
                    token: sessionStorage.getItem('token')
                }
            })

            setTimeout(() => {
                console.log(response.data.Items)
                setMovies(response.data.Items);
                console.log(movies);
            },2000)
                       
        }
        loadMovies();
    }, [])

    return(
        <div>
            {movies.length > 0 ?
            (<ul>
                {movies.map(movie => (
                    <li key={movie.Id}>
                        <img src={movie.Image} alt="image" />
                        <footer>
                            <strong>{movie.Title}</strong>
                            <p>{movie.Description}</p>
                            <p>{movie.Duration}</p>
                            <p>{movie.AnimationType == 1 ? '3D' : '2D'}</p>
                            <p>{movie.TypeAudio == 1 ? 'Dublado' : 'Legendado'}</p>                          
                        </footer>
                    </li>
                ))}
            </ul>) : <div></div>

            
            }
        </div>
    )
}