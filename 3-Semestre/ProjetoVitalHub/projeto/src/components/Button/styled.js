import styled, { css } from "styled-components";

export const Button = styled.TouchableOpacity`
    padding: 12px 8px;
    border: 1px solid ${props => props.modal ? "#60BFC5" : ( props.disable ? "#A9A9A9" : "#496bba")};
    width: ${props => (props.width != null) ? `${props.width}%` : `100%`};
    background-color: ${props => props.modal ? "#60BFC5" : ( props.disable ? "#A9A9A9" : "#496bba")};
    align-items: center;
    justify-content: center;
    border-radius: 5px;
`

export const ButtonLight = styled(Button)`
    background-color: #FBFBFB;
    ${(props) => props.modal && css`
        border-color: #60BFC5;
    `}
`   

export const ButtonGoogle = styled(ButtonLight)`
    flex-direction: row;
    gap: 27px;
`

export const ButtonModal = styled(Button)`
    width: 95%;
` 

export const ButtonCamera = styled(Button)`
    width: auto;
    padding: 12px 30px;
    align-items: center;
    justify-content: center;
    ${props => props.close && css`
        background-color: #E35B5B;
        border: 1px solid #E35B5B;
    `}
`

export const ButtonEditPhoto = styled(Button)`
    width: 45px;
    height: 45px;
    border: 1px solid #FBFBFB;
    background-color: #496BBA;
    align-items: center;
    justify-content: center;
    position: absolute;
    right: 20px;
    bottom: -20px;
    z-index: 1000;
`