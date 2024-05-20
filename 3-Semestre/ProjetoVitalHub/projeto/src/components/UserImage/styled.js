import styled from "styled-components";

export const UserImage = styled.Image`
    border-radius: 5px;
`

export const UserImageHeader = styled(UserImage)`
    width: 60px;
    height: 60px;
`

export const UserImageContent = styled(UserImage)`
    width: 80px;
    height: 80px;
`

export const UserImageCart = styled(UserImage)`
    height: 80px;
    width: 77px;
`

export const UserImagePerfil = styled.Image`
    width: 100%;
    height: 100%;
`

export const UserImageModal = styled(UserImage)`
    width: 100%;
    height: 180px;
    margin-bottom: 20px;
`