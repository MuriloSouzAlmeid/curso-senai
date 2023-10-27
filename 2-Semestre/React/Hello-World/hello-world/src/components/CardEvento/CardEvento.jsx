import React from 'react';
import './CardEvento.css';

const CardEvento = (props) => {
    return (
        <div className="card-evento">
            <h2 className="card-evento__titulo-evento">{props.titulo}</h2>
            <p className="card-evento__descricao-evento">{props.descricao}</p>
            <span className={props.disabled 
                ? "card-evento__conectar-evento card-evento__conectar-evento--disabled" 
                : "card-evento__conectar-evento"}>
                    Conectar</span>
        </div>

        // conceito de fragmento JSX que cria um container invisível para podermos utilizar elementos da mesma hierarquia no código
        // uiliza-se:
        // <>
        //     <h1></h1>
        //     <h2></h2>
        // </>
    );
}

export default CardEvento;