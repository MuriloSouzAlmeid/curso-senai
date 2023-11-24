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

export const Select = ({
  dados,
  defaultOptionText = "Tipo Evento",
  mudaOpcao,
  id,
  name,
  selectValue = '',
  required,
  additionalClass = ''
}) => {
  return (
    <select
      className={`input-component ${additionalClass}`}
      name={name}
      id={id}
      value={selectValue}
      onChange={mudaOpcao}
      required={required ? 'required' : ''}
    >
      <option value="">{defaultOptionText}</option>
      {dados.map((opt) => {
        return (
          <option key={opt.idTipoEvento} value={opt.idTipoEvento}>{opt.titulo}</option>
        );
      })}
    </select>
  );
};
