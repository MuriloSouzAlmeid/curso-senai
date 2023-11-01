import React from 'react';
import './Container.css';

const Container = ( { children } ) => {
    return (
        <div className='container'>
            {/* tudo que eu colocar dentro de um componente container será seu componente filho */}
            {children} 
        </div>
    );
};

export default Container;