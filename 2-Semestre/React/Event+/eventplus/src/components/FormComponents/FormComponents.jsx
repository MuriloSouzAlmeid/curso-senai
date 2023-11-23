import React from "react";
import "./FormComponents.css";

export const Input = ({
  type,
  id,
  value,
  required,
  additionalClass = "",
  name,
  placeholder,
  manipulationFunction,
}) => {
  return (
    <input
      type={type}
      id={id}
      required={required ? "required" : ""}
      name={name}
      value={value}
      placeholder={placeholder}
      className={`input-component ${additionalClass}`}
      onChange={manipulationFunction}
      autoComplete="off"
    />
  );
};

export const Button = ({
  id,
  name,
  type,
  textButton,
  additionalClass = "",
  manipulationFunction,
}) => {
  return (
    <button
      id={id}
      name={name}
      type={type}
      className={`button-component ${additionalClass}`}
      onClick={manipulationFunction}
    >
      {textButton}
    </button>
  );
};

export const Select = ({dados, defaultOptionText='Tipo Evento', mudaOpcao, selectValue}) => {
  return (
    <select name="tipos-de-eventos" id="tipos-de-eventos" value={selectValue} onChange={mudaOpcao}>
      <option value="">{defaultOptionText}</option>
      {dados.map((tipoEvento) => {
        return (<option value={tipoEvento.idTipoEvento}>{tipoEvento.titulo}</option>)
      })}
    </select>
  );
};
