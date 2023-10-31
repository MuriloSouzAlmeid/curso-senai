//quando não colocamos o './' no import ele busca direto da pasta node_modules
import React from 'react';

//import das configurações do router-dom
import {BrowserRouter, Routes, Route} from 'react-router-dom';

//import das páginas
import HomePage from './pages/HomePage/HomePage';
import EventosPage from './pages/EventosPage/EventosPage';
import LoginPage from './pages/LoginPage/LoginPage';
import TiposEventos from './pages/TiposEventosPage/TiposEventos';
import TestePage from './pages/TestePage/TestePage';

const Rotas = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route element={<HomePage />} path='/' exact />
                <Route element={<LoginPage />} path='/login' />
                <Route element={<EventosPage />} path='/eventos' />
                <Route element={<TiposEventos />} path='/tipos-eventos' />
                <Route element={<TestePage />} path='/teste' />
            </Routes>
        </BrowserRouter>
    );
};

export default Rotas;