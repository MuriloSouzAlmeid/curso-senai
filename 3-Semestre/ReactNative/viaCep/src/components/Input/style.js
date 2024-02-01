import styled, { css } from "styled-components";

export const InputForm = styled.TextInput`
    border: 2px solid #A1A1A1;
    border-radius: 10px;
    text-align: left;
    padding: 20px; 
    margin-top: 10px;
    width: 100%;
    font-size: 18px;
    font-family: 'Roboto_500Medium';

    ${props => !props.editable && css`
        background-color: #f6f6f6;
    `}
`

