import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';

import Login from './pages/login/login.js';
import User from './pages/users/user.js';

export default function Routes() {
    return (
        <BrowserRouter>
            <Route path="/" exact component={Login} />
            <Route path="/user/" component={User} />
        </BrowserRouter>
    );
}