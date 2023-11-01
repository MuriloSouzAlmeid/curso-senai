import React from 'react';
import './Header.css';

import Container from './Container/Container';
import Navbar from '../Navbar/Navbar';
import PerfilUsuario from '../PerfilUsuario/PerfilUsuario';

const Header = () => {
    return (
        <header className='headerpage'>
            <Container>
                <div className='header-flex'>
                    <img 
                        src="" 
                        alt="Imagem menu de barras. Serve para exibir ou escorder o menu no smartphone" 
                    />

                    <Navbar/>

                    <PerfilUsuario/>
                </div>
            </Container>
        </header>
    );
};

export default Header;