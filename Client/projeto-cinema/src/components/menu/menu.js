import React from 'react';
import { bubble as Menu } from 'react-burger-menu';
import logout from '../../utils/logout';

export default props => {
   
    function handleLogout(){
        logout(props);
    }

    return (
        <Menu>
            <a className="menu-item" href="/userview/">
                Usuários
            </a>

           <a className="menu-item" href="/movietheaterview/" hidden={false}>
                Salas
            </a>

            <a className="menu-item" href="/movieview/">
                Filmes
            </a>

            <a className="menu-item" href="/sessionview/">
                Sessões
            </a>

            <a className="menu-item" href="/snack">
                Snacks
            </a>

            <a className="menu-item" href="/moviereport">
                Relatório de Filmes
            </a>

            <a className="menu-item" href="/customerreport">
                Relatório de Clientes
            </a>

            <a className="menu-item" onClick={handleLogout}>
                Sair
            </a>
        </Menu>
    );
};


