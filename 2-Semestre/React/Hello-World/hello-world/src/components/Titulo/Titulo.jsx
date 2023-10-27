//importa a biblioteca react para utilizar outros componentes ou usar html nas funções
import React from "react";

//importa as configurações de css para o componente
import './Titulo.css'

//como um construtor de uma classe
const Titulo = (props) => { //eu passo o objeto props que cada componente deve ter
    return(
        <h1 className="titulo">Olá {props.texto}</h1> //acesso o elemento dentro da props passado ao chamar o elemento em uma página qualquer
    );
}

//publica o elemento para ser utilizado em outros locais do programa
export default Titulo;