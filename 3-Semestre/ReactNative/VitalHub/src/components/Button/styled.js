import styled from "styled-components";

export const Button = styled.TouchableOpacity`
    padding: 12px 8px;
    border: 1px solid #496bba;
    width: 100%;
    background-color: #496BBA;
    align-items: center;
    justify-content: center;
    border-radius: 5px;
`

export const ButtonGoogle = styled(Button)`
    background-color: white;
    flex-direction: row;
    gap: 27px;
`