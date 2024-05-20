import styled, { css } from "styled-components";

export const Title = styled.Text`
    font-family: "MontserratAlternates_600SemiBold";
    font-size: 20px;
    color: #33303E;
    text-align: center;
`

export const TitleLogin = styled(Title)`
    margin-top: 25px;
`

export const TitleCadastro = styled(Title)`
    margin: 25px 0 15px;
`

export const TitleRedefinirSenha = styled(Title)`
    margin: 25px 0 15px;
`

export const TitleVerificarEmail = styled(Title)`
    margin: 25px 0 15px;
`

export const SemiBoldText = styled.Text`
    font-size: 16px;
    font-family: "MontserratAlternates_600SemiBold";
    color: #33303E;
`

export const UserNameTextHeader = styled(SemiBoldText)`
    color: #FBFBFB;
`

export const MediumText = styled.Text`
    font-size: 14px;
    font-family: 'MontserratAlternates_700Bold';
`

export const WelcomeText = styled(MediumText)`
    color: #4E4B59;
`

export const ButtonTitle = styled(MediumText)`
    color: white;
    text-transform: uppercase;
`

export const ButtonTitleLight = styled(ButtonTitle)`
    color: #496BBA;
`

export const ButtonSemiBoldTitle = styled.Text`
    color: white;
    font-size: 12px;
    font-family: "MontserratAlternates_600SemiBold";
`

export const ButtonSemiBoldTitleLight = styled(ButtonSemiBoldTitle)`
    color: ${props => props.modal ? "#34898F" : "#496BBA"};
`

export const TextAccount = styled(MediumText)`
    color: #4E4B59;
`

export const TextRegular = styled.Text`
    font-family: "Quicksand_500Medium";
    font-size: 16px;
    text-align: center;
`

export const EmailUserText = styled(TextRegular)`
    font-size: ${props => props.editavel ? `16px` : `14px`};
    ${props => props.editavel && css`text-align: left;`}
`

export const AgeUserText = styled(TextRegular)`
    
`

export const InputLabel = styled.Text`
    font-size: 16px;
    color: black;
    font-family: "Quicksand_600SemiBold";
`

export const UserNamePerfilText = styled(SemiBoldText)`
    font-size: ${props => props.editavel ? `20px` : `16px`};
`

export const TextLight = styled.Text`
    font-family: "Quicksand_400Regular";
    font-size: 14px;
`