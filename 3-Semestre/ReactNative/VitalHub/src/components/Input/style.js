import styled from "styled-components";

export const InputField = styled.TextInput.attrs({
    placeholderTextColor: '#34898F'
})`
    border: 2px solid #49B3BA;
    border-radius: 5px;
    width: 100%;
    padding: 16px;
    width: ${props => `${props.fieldWidth}%`};
`

export const InputVirifyEmail = styled(InputField)`
    align-items: center;
    justify-content: center;
    padding: 5px 20px;
    text-align: center;
    font-size: 40px;
    font-family: "Quicksand_600SemiBold";
    color: #34898F;
`