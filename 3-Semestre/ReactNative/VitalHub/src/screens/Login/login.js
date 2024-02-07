import { ContainerApp } from "../../components/Container/style";
import { ButtonTitle, ButtonTitleGoogle, TextAccount, TitleLogin } from "../../components/Text/style";
import { LogoVitalHub } from "../../components/Logo";
import { BoxButton, BoxInputLogin, ContentAccount } from "../../components/Box/style";
import { Input } from "../../components/Input";
import { LinkAccount, LinkRedefinirSenha } from "../../components/Link";
import { Button, ButtonGoogle } from "../../components/Button";
import { AntDesign } from '@expo/vector-icons';

export const Login = () =>
    <ContainerApp>
        <LogoVitalHub />
        <TitleLogin>Entrar ou criar conta</TitleLogin>
        <BoxInputLogin>
            <Input
                placeholderText={"Usuário ou email"}

            />
            <Input
                placeholderText={"Senha"}

            />
            <LinkRedefinirSenha url={"https://www.google.com.br/?hl=pt-BR"}>Esqueceu sua senha?</LinkRedefinirSenha>
        </BoxInputLogin>
        <BoxButton>
            <Button>
                <ButtonTitle>Entrar</ButtonTitle>
            </Button>
            <ButtonGoogle>
                <AntDesign name="google" size={20} color={"#4D659D"} />
                <ButtonTitleGoogle>Entrar com Google</ButtonTitleGoogle>
            </ButtonGoogle>
        </BoxButton>
        <ContentAccount>
            <TextAccount>Não tem conta? </TextAccount>
            <LinkAccount url={"https://sig.ufabc.edu.br/sigaa/verTelaLogin.do"} >Crie sua conta aqui</LinkAccount>
        </ContentAccount>
    </ContainerApp>