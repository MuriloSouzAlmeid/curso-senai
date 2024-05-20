import styled from "styled-components";
import { ContainerApp } from "../../components/Container/style";
import { CardTextCancelApointment } from "../../components/Card/style";
import { InputContentBox } from "../../components/Box/style";

export const ProntuarioBox = styled(ContainerApp)`
    margin: 20px 0 30px;
`

export const UserDataApointment = styled.View`
    margin-top: 10px;
    flex-direction: row;
    width: 100%;
    justify-content: center;
    align-items: center;
    gap: 20px;
`

export const ApointmentFormBox = styled.View`
    margin: 25px 0 30px;
    width: 100%;
    gap: 20px;
`

export const SendImageOCRBox = styled.View`
    width: 100%;
    gap: 20px;
`

export const ButtonImageSubmit = styled.TouchableOpacity`
    width: 50%;
    background-color: #49B3BA;
    border: 1px solid #49B3BA;
    border-radius: 5px;
    align-items: center;
    justify-content: center;
`

export const ImageSubmitBox = styled.View`
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
    width: 100%;
`

export const CancelImageSubmit = styled(CardTextCancelApointment)`
    color: #C81D25;
    margin-right: 32px;
`

export const ButtonImageSubmitContent = styled.View`
    flex-direction: row;
    justify-content: center;
    align-items: center;
    padding: 10px;
    gap: 10px;
`

export const ButtonImageSubmitText = styled.Text`
    font-size: 14px;
    font-family: "MontserratAlternates_700Bold";
    color: white;
`

export const ImageInputBox = styled(InputContentBox)`
    width: 100%;
`

export const ImageInputBoxField = styled.View`
    padding: 10px;
    height: auto;
    justify-content: center;
    align-items: center;
    border-color: #F5F3F3;
    background-color: #F5F3F3;
    color: #4E4B59;
`

export const ResultadosOCRText = styled.Text`
    color: #4E4B59;
    text-align: justify;
    font-size: 14px;
    font-family: "MontserratAlternates_500Medium";
`

export const NenhumaImagemBox = styled.View`
    justify-content: center;
    align-items: center;
    flex-direction: row;
    gap: 5px;
    width: 100%;
    padding: 40px 0;
`

export const ImageInputBoxText = styled.Text`
    font-size: 14px;
    color: #4E4B59;
    font-family: "MontserratAlternates_500Medium"; 
    text-align: center;
`

export const EditProntuarioButton = styled.View`
    width:100%;
    margin: 0px 0 30px;
`