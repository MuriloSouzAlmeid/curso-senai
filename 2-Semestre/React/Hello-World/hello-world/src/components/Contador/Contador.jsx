//podemos importar vários elementos diferentes da mesma biblioteca usando "," entre os elementos
import React, { useState } from "react";
import "./Contador.css";

const Contador = (props) => {
    //a variável que irá alterar o estado do valor de um componente 
    //contador é a variável a ser criada
    //setContador é o nome da função que altera o valor do contador
    //como parâmetro para useState devemos adicionar um valor inicial à variável que será manipulada
    const [contador, setContador] = useState(0);

    // função incrementadora que será chamada no botão
    function handleIncrementar(incremento){
        //chama a função que manipula o contador e passa o novo valor como parâmetro
        setContador(contador + incremento);
    }

    // função decrementadora que será chamada no botão
    function handleDecrementar(decremento){
        // meu jeito
        if(contador === 0){
            alert("Não é possível decrementar mais!");    
        }
        else{
            setContador(contador - decremento);
        }

        // jeito do professor
        // setContador (contador === 0 ? 0 : contador -1)
    }

    return(
     //encapsulando um elemento pois não podemos colocar 2 tags como irmãs no react
     <>
        {/* variável de estado que será alterada  */}
        <p>{contador}</p>
        {/* Se eu colocar a chamada da função ela executará antes da criação da estrutura do react por causa do js */}
        {/* se tiver que passar parâmetros devemos encapsular a função em uma arrow function */}
        <button onClick={
            () => {
                //passo como argumento o valor que quero incrementar
                handleIncrementar(1);
            }}>Incrementar</button>
        <button onClick={
            () => {
                handleDecrementar(1);
            }
        }>Decrementar</button>
     </>
    );
}

export default Contador;