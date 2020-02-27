import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';

import Login from './pages/login/login.js';
import User from './pages/users/user.js';
import Session from './pages/sessions/session.js';
import Ticket from './pages/tickets/ticket.js'
import Seat from './pages/seats/seat.js'
import Snack from './pages/snacks/snack.js'
import TicketBuy from './pages/tickets/ticket-buy.js'
import UserManager from './pages/users/user-manager.js'
import Movie from './pages/movies/movie.js'
import MovieView from './pages/movies/movie-view.js'
import SnackNew from './pages/snacks/snack-new.js'

export default function Routes() {
    return (
        <BrowserRouter>
            <Route path="/" exact component={Login} />
            <Route path="/user/" exact component={User} />
            <Route path="/session/" exact component={Session} />
            <Route path="/ticket/:id" exact component={Ticket} />
            <Route path="/seat/:movieTheaterId" exact component={Seat} />
            <Route path="/snack/" exact component={Snack} />
            <Route path="/ticket-buy/" exact component={TicketBuy} />
            <Route path="/usermanager/:id" exact component={UserManager} />
            <Route path="/movie/" exact component={Movie} />
            <Route path="/movie/:id" exact component={Movie} />
            <Route path="/movieview/" exact component={MovieView} />
            <Route path="/snack-new/" exact component={SnackNew} />
        </BrowserRouter>
    );
}