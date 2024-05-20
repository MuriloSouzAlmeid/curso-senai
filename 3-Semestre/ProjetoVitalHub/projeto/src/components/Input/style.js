import styled, { css } from "styled-components";

export const InputField = styled.TextInput.attrs({
    placeholderTextColor: `${props => props.error ? "#EB483D" : '#49B3BA'}`
})`
    border: 2px solid ${props => props.error ? "#EB483D" : "#49B3BA"};
    /* border: 2px solid #49B3BA; */
    border-radius: 5px;
    width: ${props => `${props.inputWidth}%`};
    padding: 16px;
    ${props => props.center && css`
        justify-content: center;
        align-items: center;
    `}
    color: "#49B3BA";
`

export const InputVirifyEmail = styled(InputField)`
    align-items: center;
    justify-content: center;
    padding: 5px 20px;
    height: 70px;
    text-align: center;
    font-size: 40px;
    font-family: "Quicksand_600SemiBold";
    color: #34898F;
    width: 20%;
    margin-bottom: 30px;
`

export const PerfilInputField = styled(InputField).attrs({
    placeholderTextColor: "#33303E"
})
`
    border-color: #F5F3F3;
    background-color: #F5F3F3;
    padding-bottom: ${props => `${props.fieldHeight}px`};
    color: #4E4B59;
    font-size: 14px;
    font-family: "MontserratAlternates_500Medium";
`

export const ApointmentInputField = styled(InputField).attrs({
    placeholderTextColor: "#49B3BA"
})`
    background-color: transparent;
    border-color: #49B3BA;
    padding-bottom: ${props => `${props.fieldHeight}px`};
    ${props => props.center && css`
        justify-content: center;
        align-items: center;
    `}
`