import styled from "styled-components";
import { CardTextCancelApointment } from "../../components/Card/style";
import { PerfilInputField } from "../../components/Input/style";
import { InputContentBox } from "../../components/Box/style";

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
    padding: 46px 60px;
    justify-content: center;
    align-items: center;
    flex-direction: row;
    gap: 5px;
    border-color: #F5F3F3;
    background-color: #F5F3F3;
    color: #4E4B59;
`

export const ImageInputBoxText = styled.Text`
    font-size: 14px;
    color: #4E4B59;
    font-family: "MontserratAlternates_500Medium"; 
    text-align: center;
`