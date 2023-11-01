import React from 'react';
import {Link} from 'react-router-dom';
import './Navbar.css';

const Navbar = () => {
    return (
        <nav className='navbar'>
            <span className='navbar__close'></span>

            <Link to='/' exact>
                <img 
                    className='eventlogo__logo-image'
                    src="" 
                    alt="Event Plus Logo" 
                />
            </Link>

            <div className='navbar__items-box'>
                <Link to='/' exact>Home</Link>
                <Link to='/eventos'>Eventos</Link>
                <Link to='/tipos-eventos'>Tipos de Eventos</Link>
                <Link to='/login'>Login</Link>
            </div>
        </nav>
    );
};

export default Navbar;