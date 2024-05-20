import styled from "styled-components";
import { TextLight, TextRegular } from "../Text/style";

export const PatientModal = styled.View`
    flex: 1;
    align-items: center;
    justify-content: center;
    background-color: rgba(0,0,0,.6);
`

export const ModalContent = styled.View`
    padding: 30px 30px 23px;
    width: 90%;
    border-radius: 10px;
    background-color: white;
    align-items: center;
`

export const ModalConsultaForm = styled.View`
    width: 100%;
    margin: 35px 0 100px;
    gap: 20px;
`

export const ModalSubtitle = styled.Text`
    font-family: "Quicksand_600SemiBold";
    font-size: 14px;
`

export const ModalTextRow = styled.View`
    flex-direction: row;
    justify-content: space-around;
    align-items: center;
    width: 270px;
`

export const ModalText = styled(TextRegular)`
    /* width: 270px; */
    color: #5f5c6b;
    line-height: 22px;
    font-size: 14px;
    margin: 10px 0 30px;
`

export const ConsultaModal = styled(ModalContent)`
    position: absolute;
    width: 99%;
    bottom: 0;
    height: 550px;
`

export const DadosConsultaText = styled(TextLight)``

export const DadosConsultaTitle = styled(TextRegular)`
    text-align: left;
`

export const BoxInputConsulta = styled.View`
    gap: 10px;
`

export const ResumoConsultaBox = styled.View`
    width: 90%;
    margin-top: 16px;
`

export const DadosConsultaBox = styled.View`
    width: 100%;
    margin-bottom: 30px;
    gap: 20px;
    margin-top: 30px;
`

export const LinhaDadosConsulta = styled.View`
    width: 100%;
    gap: 8px;
`

export const CameraContent = styled.View`
    width: 90%;
    height: 80%;
    align-items: center;
    justify-content: space-between;
    position: relative;
`

export const SwitchCameraTypeButton = styled.TouchableOpacity`
    height: 30px;
    height: 30px;
    display: flex;
    align-items: center;
    justify-content: center;
    position: absolute;
    right: 5%;
    bottom: 15%;
    z-index: 100000000000000;
`

export const SwitchCameraTypeIcon = styled.Image`
    width: 30px;
    height: 30px;
`

export const LastPhoto = styled.Image`
    width: 40px;
    height: 40px;
    border-radius: 5px;
`

export const ImageContent = styled(ModalContent)`
    gap: 30px;
`

export const ImagemRecebida = styled.Image`
    height: 80%;
    width: 80%;
    border-radius: 5px;
`