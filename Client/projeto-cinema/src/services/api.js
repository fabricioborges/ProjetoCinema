import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:9870/'
});

export default api;