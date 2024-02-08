import { BoxInput } from "../../components/Box/style";
import { Button } from "../../components/Button/styled";
import { ContainerApp } from "../../components/Container/style";
import { Input } from "../../components/Input";
import { LinkCancel } from "../../components/Link";
import { LogoVitalHub } from "../../components/Logo";
import { ButtonTitle, TextRegular, TitleCadastro } from "../../components/Text/style";

export const Cadastro = () =>
    <ContainerApp>
        <LogoVitalHub />
        <TitleCadastro>Criar conta</TitleCadastro>
        <TextRegular>Insira seu endereço de e-mail e senha para realizar seu cadastro.</TextRegular>
        <BoxInput>
            <Input
                placeholderText={"Usuário ou email"}
            />
            <Input
                placeholderText={"Senha"}
            />
            <Input
                placeholderText={"Confirmar senha"}
            />
        </BoxInput>
        <Button>
            <ButtonTitle>Cadastrar</ButtonTitle>
        </Button>
        <LinkCancel url={"https://term.ooo/"} >Cancelar</LinkCancel>
    </ContainerApp>