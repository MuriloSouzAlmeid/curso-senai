import { Button } from "react-native";
import { ContainerApp, ContainerLogin } from "../../components/Container/style";
import { Title, TitleLogin } from "../../components/Text/style";
import { LogoVitalHub } from "../../components/Logo";
import { BoxInput } from "../../components/Box/style";
import { Input } from "../../components/Input";

export const Login = () =>
    <ContainerApp>
        <ContainerLogin>
            <LogoVitalHub />
            <TitleLogin>Entrar ou criar conta</TitleLogin>
            <BoxInput>
                <Input
                    placeholderText={"Usuário ou email"}

                />
                <Input
                    placeholderText={"Senha"}

                />
            </BoxInput>

            {/*

            <Input/>
            <Input/>
            <LinkMedium>Esqueceu sua senha?</LinkMedium>
            <Button>
                <ButtonTitle>Entrar</ButtonTitle>
            </Button>
            <ButtonGoogle>
                <ButtonTitleGoogle>Entrar com Google</ButtonTitleGoogle>
            </ButtonGoogle>
            <ContentAccount>
                <TextAccount>Não tem conta? Crie uma conta agora</TextAccount>
            </ContentAccount> */}
        </ContainerLogin>
    </ContainerApp>