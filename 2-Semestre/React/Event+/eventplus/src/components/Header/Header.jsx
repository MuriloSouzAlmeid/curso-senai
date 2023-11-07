import React, { useState } from 'react';
import './Header.css';

import Container from '../Container/Container';
import Navbar from '../Navbar/Navbar';
import PerfilUsuario from '../PerfilUsuario/PerfilUsuario';

import menubar from '../../assets/images/menubar.png'

const Header = () => {
    // cria o estado para o botao com o valor inicial de falso (não exibe)
    //eu posso compartilhar todos os estados criados em componentes pai com seus componentes filhos e até mesmo configurar quando compartilhar (condição) como um onClick
    const [exibeNavbar, setExibeNavbar] = useState(false);

    return (
        <header className='headerpage'>
            <Container>
                <div className='header-flex'>
                    <img 
                        className='headerpage__menubar'
                        src={menubar}
                        alt="Imagem menu de barras. Serve para exibir ou escorder o menu no smartphone" 
                        onClick={() => {
                            //muda o estado do botao para true (vai exibir)
                            setExibeNavbar(true);
                        }}
                    />

                    {/* passando a variável que define o estado do nav assim como sua função para alterar seu valor para o componente filho */}
                    <Navbar setExibeNavbar={setExibeNavbar} exibeNavbar={exibeNavbar}/>

                    <PerfilUsuario/>
                </div>
            </Container>
        </header>
    );
};

export default Header;