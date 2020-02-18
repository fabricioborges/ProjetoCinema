import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';

import Login from './pages/login/login.js';
import User from './pages/users/user.js';
import Session from './pages/sessions/session.js';
import Ticket from './pages/tickets/ticket.js'
import Seat from './pages/seats/seat.js'
import Snack from './pages/snacks/snack.js'
import TicketBuy from './pages/tickets/ticket-buy.js'

export default function Routes() {
    return (
        <BrowserRouter>
            <Route path="/" exact component={Login} />
            <Route path="/user/" component={User} />
            <Route path="/session/" component={Session} />
            <Route path="/ticket/:id" component={Ticket} />
            <Route path="/seat/:movieTheaterId" component={Seat} />
            <Route path="/snack/" component={Snack} />
            <Route path="/ticket-buy/" component={TicketBuy} />
        </BrowserRouter>
    );
}