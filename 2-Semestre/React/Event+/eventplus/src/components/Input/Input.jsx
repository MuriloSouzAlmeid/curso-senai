import React, { useState } from "react";
import "./Input.css";

//a const do elemento age como o construtor de um objeto da classe componente
const Input = (props) => {
    // const [valor, setValor] = useState("Valor Inicial"); /estado que só vale dentro deste componente instanciando um valor privado e ser acessor para alterar seu valor se necessário (state == um dado do componente)

  //função para alterar o valor do state
//   function alteraValor(valor) {
//     setValor(valor);
//   }

  return (
    <div>
      <input
        // Preenche as propriedades do objeto
        type={props.tipo}
        placeholder={props.dicaCampo}
        id={props.id}
        name={props.nome}
        value={props.valor}

        // quando o valor mudar ativa uma callback function
        onChange={(e) => {

          // ativa a função que vai alterar o valor que no caso está no elemento pai
          props.alteraValor(e.target.value); //pega o valor do elemento input
        }}
      />
      <span>{props.valor}</span>
    </div>
  );
};

export default Input;
