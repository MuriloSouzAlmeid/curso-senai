import React from 'react';
import './Titulo.css';

//eu posso adicionar valores diretamente no destructuring do props
const Titulo = ({titleText, additionalClass = "", color = ""}) => {
    return (
        <div>
            <h1 className={`title ${additionalClass}`}

            //para criarmos style em React(javascript) passamos como se fosse um pbjeto'
            style={
                {
                    //a chave é a propriedade de css e o valor é simplesmente seu valor
                    //converte automaticamente em escrita css
                    color: color
                }
            }
            >
                {titleText}
            </h1>
            <hr 
                className='title__underscore'
                style={
                    {
                        borderColor: color
                    }
                }
            />
        </div>
    );
};

export default Titulo;