import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import Login from './pages/login/login.js';
import User from './pages/users/user.js';
import UserView from './pages/users/user-view.js';
import SessionView from './pages/sessions/session-view.js';
import Session from './pages/sessions/session.js';
import Ticket from './pages/tickets/ticket.js'
import Seat from './pages/seats/seat.js'
import Snack from './pages/snacks/snack.js'
import TicketBuy from './pages/tickets/ticket-buy.js'
import Movie from './pages/movies/movie.js'
import MovieView from './pages/movies/movie-view.js'
import SnackNew from './pages/snacks/snack-new.js'
import MovieTheaterView from './pages/movie-theater/movie-theater-view'
import MovieTheater from './pages/movie-theater/movie-theater'
import CustomerStory from './pages/reports/customer-stories/customer-story.js';

export default function Routes() {
    return (
        <BrowserRouter>
            <Route path="/" exact component={Login} />
            <Route path="/user/" exact component={User} />
            <Route path="/user/:id" exact component={User} />
            <Route path="/userview/" exact component={UserView} />
            <Route path="/session/" exact component={Session} />
            <Route path="/session/:id" exact component={Session} />
            <Route path="/sessionview/" exact component={SessionView} />
            <Route path="/ticket/:id" exact component={Ticket} />
            <Route path="/seat/:movieTheaterId" exact component={Seat} />
            <Route path="/snack/" exact component={Snack} />
            <Route path="/ticket-buy/" exact component={TicketBuy} />
            <Route path="/movie/" exact component={Movie} />
            <Route path="/movie/:id" exact component={Movie} />
            <Route path="/movieview/" exact component={MovieView} />
            <Route path="/snack-new/" exact component={SnackNew} />
            <Route path="/snack-new/:id" exact component={SnackNew} />
            <Route path="/movietheaterview/" exact component={MovieTheaterView} />
            <Route path="/movietheater/" exact component={MovieTheater} />
            <Route path="/movietheater/:id" exact component={MovieTheater} />
            <Route path="/customerstory/" exact component={CustomerStory} />
        </BrowserRouter>
    );
}