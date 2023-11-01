import React, { createFactory } from 'react';

import { Link } from 'react-router-dom';

import './Header.css';

const Header = () => {
    return (
        // caso eu tente escrever a tag em maiúsculo ele fica chamando um elemento React e dá erro. Prestar atenção nisso
        // <header></header> -> certo (tag)
        // <Header></Header> -> errado (componente)
        <header>
            <nav>
                {/* href não rola pq vai recarregar a página 
                <a href="/">Home</a>*/}
                <Link to='/'>Home</Link>
                <br />
                <Link to='/eventos'>Eventos</Link>
                <br />
                <Link to='/tipos-eventos'>Tipos de Eventos</Link>
                <br />
                <Link to='/login'>Login</Link>
                <br />
                <Link to='/testes'>Teste</Link>
            </nav>
        </header>
    );
};

export default Header;