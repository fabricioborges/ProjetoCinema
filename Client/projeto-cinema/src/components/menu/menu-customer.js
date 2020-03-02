import React from 'react';
import { bubble as MenuCustomer } from 'react-burger-menu';

export default props => {
    var manager = localStorage.getItem('Manager');
    console.log(manager)
    return (
        <MenuCustomer>
            <a className="menu-item" href="/sessionview/">
                Sessões
      </a>
        </MenuCustomer>
    );
};