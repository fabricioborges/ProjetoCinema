import React from 'react';
import { bubble as Menu } from 'react-burger-menu';

export default props => {
    return (
        <Menu>
            <a className="menu-item" href="/">
                Home
      </a>

            <a className="menu-item" href="/user/">
                Usuários
      </a>

            <a className="menu-item" href="/angular">
                Angular
      </a>

            <a className="menu-item" href="/react">
                React
      </a>

            <a className="menu-item" href="/vue">
                Vue
      </a>

            <a className="menu-item" href="/node">
                Node
      </a>
        </Menu>
    );
};