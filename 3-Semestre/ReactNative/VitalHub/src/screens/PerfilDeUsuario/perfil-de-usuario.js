import { Title } from "../../components/Text/style";
import { ContainerApp, ContainerPerfilPage } from "../../components/Container/style";
import { UserImagePerfil } from "../../components/UserImage/styled";
import { UserContentBox } from "../../components/Box/style";

export const PerfilDeUsuario = () =>
    <>

        <ContainerPerfilPage>
            <UserImagePerfil
                source={require("../../assets/images/user1-image.png")}
            />
            <UserContentBox>

            </UserContentBox>
        </ContainerPerfilPage>
        <ContainerApp>
            <Title>Perfil de Usuário</Title>
        </ContainerApp>
    </>