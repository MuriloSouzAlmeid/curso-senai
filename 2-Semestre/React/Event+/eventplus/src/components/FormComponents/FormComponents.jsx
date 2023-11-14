import React from 'react';
import './FormComponents.css';

export const Input = ({
    type,
    id,
    value,
    required,
    additionalClass='',
    name,
    placeholder,
    manipulationFunction
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
            autoComplete='off'
        />
    )
};

export const Button = ({
    id,
    name,
    type,
    textButton,
    additionalClass = ''
}) => {
    return(
        <button
            id={id}
            name={name}
            type={type}
            className={`button-component ${additionalClass}`}
        >
            {textButton}
        </button>
    );
};