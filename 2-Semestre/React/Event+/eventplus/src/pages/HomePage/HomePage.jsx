import React from 'react';
import './HomePage.css';

//import dos componentes
import Titulo from '../../components/Titulo/Titulo';
import Header from '../../components/Header/Header';

const HomePage = () => {
    return (
        <div>
            <Titulo titulo='Página Home' />
        </div>
    );
};

export default HomePage;