import React from 'react';
import { bubble as Menu } from 'react-burger-menu';

export default props => {
    var mostrar = true;

    return (
        <Menu>
            <a className="menu-item" href="/userview/">
                Usuários
      </a>

            {mostrar && <a className="menu-item" href="/movietheaterview/" hidden={false}>
                Salas
      </a>}

            <a className="menu-item" href="/movieview/">
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


