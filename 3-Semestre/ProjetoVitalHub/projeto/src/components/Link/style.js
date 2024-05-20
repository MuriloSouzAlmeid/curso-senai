import styled from "styled-components";

export const Link = styled.Text`
    text-decoration: underline;
`

export const LinkMedium = styled(Link)`
    font-family: 'MontserratAlternates_400Regular';
    font-size: 14px;
`

export const LinkMediumLogin = styled(LinkMedium)`
    align-self: flex-start;
    color: #8C8A97;
`

export const LinkSemiBold = styled.Text`
    font-family: 'MontserratAlternates_600SemiBold';
    color: #4D659D;
    text-decoration: underline;
    font-size: 16px;
`

export const LinkSemiBoldCancel = styled(LinkSemiBold)`
    margin-top: 30px;
    font-size: 14px;
    text-align: center;
    /* border: 1px solid black; */
`

export const LinkSemiBoldVerifyEmail = styled(LinkSemiBold)`
    text-decoration: none;
    margin-bottom: 20px;
`

export const LinkSemiBoldReenviarEmail = styled(LinkSemiBoldCancel)`
`

export const LinkVoltar = styled(LinkSemiBoldCancel)`
    font-size: 16px;
`