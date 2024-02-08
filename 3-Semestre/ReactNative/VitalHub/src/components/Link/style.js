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
    font-size: 14px;
`

export const LinkSemiBoldCancel = styled(LinkSemiBold)`
    margin-top: 30px;
`

