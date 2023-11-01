import React, { useState } from "react";
import Input from "../../components/Input/Input";
import Button from "../../components/Button/Button";

const TestePage = () => {
  const [total, setTotal] = useState();
  const [n1, setN1] = useState();
  const [n2, setN2] = useState();

  function handleSomar(e) {
    //passa o event automaticamente
    e.preventDefault();
    setTotal(parseFloat(n1) + parseFloat(n2));
  }

  return (
    <>
      <h1>Página de Testes</h1>
      <h2>Calculadora de Soma</h2>
      <form onSubmit={handleSomar}>
        {/* ao criar o elemento é como se eu estivesse instanciando um objeto da classe do elemento */}
        <Input
          // é como se fossem os parâmetros para construir o objeto
          tipo="number"
          nome="numero1"
          id="numero1"
          dicaCampo="Digite o 1º número"
          valor={n1}
          //função que altera o valor do campo passando por herança
          alteraValor={setN1}
        />
        <br />
        <Input
          tipo="number"
          nome="numero2"
          id="numero2"
          dicaCampo="Digite o 2º número"
          valor={n2}
          alteraValor={setN2}
        />
        <br />
        <Button tipo="submit" texto="Somar" />
        <p>
          Resultado: <strong>{total}</strong>
        </p>
      </form>
    </>
  );
};

export default TestePage;
