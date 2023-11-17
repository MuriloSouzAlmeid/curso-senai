import React from 'react';
import {BrowserRouter, Routes, Route} from 'react-router-dom';

import Swipper from './Pages/Swipper/Swipper';

const Rotas = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route element={<Swipper/>} path='/' exact/>
            </Routes>
        </BrowserRouter>
    );
};

export default Rotas;