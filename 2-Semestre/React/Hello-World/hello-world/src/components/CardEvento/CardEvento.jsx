import React from 'react';
import './CardEvento.css';

//estrutura do componente
//      objeto     propriedades     
const CardEvento = (props) => {
    //retorna uma estrutura de tags html
    return (
        <div className="card-evento">
            <h2 className="card-evento__titulo-evento">{props.titulo}</h2>
            <p className="card-evento__descricao-evento">{props.descricao}</p>
            <span className={props.disabled 
                ? "card-evento__conectar-evento card-evento__conectar-evento--disabled" 
                : "card-evento__conectar-evento"}>
                    Conectar
            </span>
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


//State React: valor armazenado em um componente, o valor possui um estado (state) e quando o valor armazenado altera o estado do componente (state) altera