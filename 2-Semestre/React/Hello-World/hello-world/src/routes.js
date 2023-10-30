import React from 'react';

// import dos componentes de rota
import {BrowserRouter, Routes, Route} from 'react-router-dom';

// import das páginas
import HomePage from './pages/HomePage/HomePage';
import LoginPage from './pages/LoginPage/LoginPage';
import ProdutoPage from './pages/ProdutoPage/ProdutoPage';

const Rotas = () => {
    return (
        // criar as estrururas das rotas
        // o BrowserRouter faz todo o processamento que ocorre de trocar de rotas pelo projeto
        <BrowserRouter>
            {/* guarda todas as rotas existentes no projeto que serão gerenciadas pelo BrowserRouter */}
            <Routes>
                <Route element={<HomePage />} path = '/' exact />
                <Route element={<LoginPage />} path = '/login' />
                <Route element={<ProdutoPage />} path = '/produto' />
            </Routes>
        </BrowserRouter>
    );
};

export default Rotas;