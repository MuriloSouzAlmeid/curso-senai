import styled from "styled-components";
import { LinearGradient } from "expo-linear-gradient";

export const ContainerApp = styled.SafeAreaView`
    align-items: center;
    flex: 1;
    background-color: #FAFAFA;
    width: 100%;
    padding: 0 5% 15px;
    /* justify-content: center; */
`

export const ContainerProfile = styled(ContainerApp)`
    justify-content: center;
`

export const ContainerHeader = styled(LinearGradient).attrs({
    colors: ["#60BFC5", "#496BBA"],
    start: {x: -0.05, y: 1.08},
    end: {x: 1, y: 0}
})`
    width: 100%;
    padding: 50px 0 22px;
    border-radius: 0 0 15px 15px;
`

export const ContainerPerfilPage = styled.ScrollView`
    position: relative;
    background-color: #FBFBFB;
    padding-bottom: 40px;
    flex: 1;
    margin-top: 30px;
`

export const ContainerForm = styled.View`
    flex: 1;
    margin-top: ${props => `${props.marginTop}px`};
    width: 100%;
    gap: 25px;
    justify-content: center;
    align-items: center;
    padding: 0 5%;
`

export const ContainerHome = styled.View`
    position: relative;
    flex: 1;
    width: 100%;
`

export const ContainerProntuario = styled(ContainerPerfilPage)``

export const LoadingContainer = styled(ContainerApp)`
    height: 100%;
    justify-content: center;
    gap: 10px;
`

export const ContainerImagePerfil = styled.SafeAreaView`
    width: 100%;
    height: 280px;
`