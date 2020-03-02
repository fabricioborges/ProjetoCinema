import React from 'react';
import { bubble as Menu } from 'react-burger-menu';

export default props => {
    var manager = localStorage.getItem('Manager');
    console.log(manager)
    return (
        <Menu>
            {manager && <a className="menu-item" href="/userview/">
                Usuários
      </a>}

            {manager && <a className="menu-item" href="/movietheaterview/" hidden={false}>
                Salas
      </a>}

            {manager && <a className="menu-item" href="/movieview/"> 
                Filmes
      </a>}

            <a className="menu-item" href="/sessionview/">
                Sessões
      </a>

            {manager &&  <a className="menu-item" href="/snack">
                Snacks
    </a>     } 
      
        
             
        </Menu>
    );
};


