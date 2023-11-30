//quando não colocamos o './' no import ele busca direto da pasta node_modules
import React from 'react';

//import das configurações do router-dom
import {BrowserRouter, Routes, Route} from 'react-router-dom';

//import das páginas
import HomePage from '../pages/HomePage/HomePage';
import EventosPage from '../pages/EventosPage/EventosPage';
import LoginPage from '../pages/LoginPage/LoginPage';
import TiposEventos from '../pages/TiposEventosPage/TiposEventos';
import TestePage from '../pages/TestePage/TestePage';

//import dos componentes
import Header from '../components/Header/Header';
import Footer from '../components/Footer/Footer';

const Rotas = () => {
    return (
        //lida com as representações do navegador que possui uma coleção de páginas, casa Route é uma página e o routes é lido como o conjunto de páginas/componentes
        <BrowserRouter>
            <Header />
            <Routes>
                <Route element={<HomePage />} path='/'/>
                <Route element={<LoginPage />} path='/login' />
                <Route element={<EventosPage />} path='/eventos' />
                <Route element={<TiposEventos />} path='/tipos-eventos' />
                <Route element={<TestePage />} path='/testes' />
            </Routes>
            <Footer/>
        </BrowserRouter>
    );
};

export default Rotas;



//este arquivo representa os componentes em cada página