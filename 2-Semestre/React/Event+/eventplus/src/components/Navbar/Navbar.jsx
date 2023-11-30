import React from 'react';
import {Link} from 'react-router-dom';
import './Navbar.css';

import logoMobile from '../../assets/images/logo-white.svg';
import logoDesktop from '../../assets/images/logo-pink.svg';

const Navbar = ( {setExibeNavbar, exibeNavbar} ) => {
    return (
        <nav className= {`navbar ${exibeNavbar ? 'exibeNavbar' : ''}`}>
            <span 
                className='navbar__close' 
                onClick={() =>  { 
                    setExibeNavbar(false) 
                }}>
                x
            </span>

            <Link to='/' exact>
                <img 
                    className='eventlogo__logo-image'
                    src={window.innerWidth >= 992 ? logoDesktop : logoMobile} 
                    alt="Event Plus Logo" 
                />
            </Link>

            <div className='navbar__items-box'>
                <Link to='/' exact>Home</Link>
                <Link to='/eventos'>Eventos</Link>
                <Link to='/tipos-eventos'>Tipos de Eventos</Link>
            </div>
        </nav>
    );
};

export default Navbar;