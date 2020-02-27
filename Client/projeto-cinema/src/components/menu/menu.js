import React from 'react';
import { bubble as Menu } from 'react-burger-menu';

export default props => {
    var mostrar = true;

    return (
        <Menu>
            <a className="menu-item" href="/user/">
                Usuários
      </a>

            {mostrar && <a className="menu-item" href="/movietheater/" hidden={false}>
                Salas
      </a>}

            <a className="menu-item" href="/movie/">
                Filmes
      </a>

            <a className="menu-item" href="/session/">
                Sessões
      </a>

            <a className="menu-item" href="/snack">
                Snacks
      </a>      
      
            <a className="menu-item" href="/snack">
                Relatório clientes
      </a> 

            <a className="menu-item" href="/snack">
                Relatório filmes
      </a>       
             
        </Menu>
    );
};


