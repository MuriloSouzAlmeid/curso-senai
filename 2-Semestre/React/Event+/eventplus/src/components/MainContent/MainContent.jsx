import React from 'react';
import './MainContent.css'

const MainContent = ({children}) => {
    return (
        <main className='main-content'>
            {/* como vamos colocar outros html por fora deste componente dentro da tag usamos o children */}
            {children}
        </main>
    );
};

export default MainContent;