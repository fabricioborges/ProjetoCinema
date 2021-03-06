import React from 'react';
import { bubble as MenuCustomer } from 'react-burger-menu';
import logout from '../../utils/logout';

export default props => {
    const id = localStorage.getItem('customerId');
    
    function handleLogout() {
        logout(props);
    }   

    return (
        <MenuCustomer>
            <a className="menu-item" href={`/user/${id}`}>
                Conta
            </a>
            <a className="menu-item" href="/sessionview/">
                Sessões
            </a>
            <a className="menu-item" href="/customerstory/">
                Histórico
            </a>
            <a className="menu-item" onClick={handleLogout}>
                Sair
            </a>
        </MenuCustomer>
    );
};