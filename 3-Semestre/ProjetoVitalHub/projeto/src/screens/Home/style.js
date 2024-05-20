import styled from "styled-components";
import { ContainerApp } from "../../components/Container/style";

export const AgendarConsultaButton = styled.TouchableHighlight.attrs({
    activeOpacity: 1,
    underlayColor: "#496BBA"
})`
    width: 60px;
    height: 60px;
    border-radius: 7px;
    background-color: #49B3BA;
    position: absolute;
    right: 40px;
    /* right: 21px; */
    bottom: 40px;
    /* bottom: 21px; */
    justify-content: center;
    align-items: center;
`

export const HomeContent = styled(ContainerApp)`
    gap: 32px;
`