import { BoxInputRow } from "../../components/Box/style";
import { Button } from "../../components/Button/styled";
import { ContainerApp } from "../../components/Container/style";
import { Input } from "../../components/Input";
import { LinkReenviarEmail, LinkVerifyEmail } from "../../components/Link";
import { LogoVitalHub } from "../../components/Logo";
import { ButtonTitle, TextRegular, TitleVerificarEmail } from "../../components/Text/style"

export const VerificarEmail = () =>
    <ContainerApp>
        <LogoVitalHub />
        <TitleVerificarEmail>
            Verifique seu email
        </TitleVerificarEmail>
        <TextRegular>Digite o código de 4 dígitos enviado para</TextRegular>
        <LinkVerifyEmail url={"https://www.google.com/intl/pt-BR/gmail/about/"}>username@email.com</LinkVerifyEmail>
        <BoxInputRow>
            <Input
                placeholderText={"0"}
                fieldWidth={"20"}
                verifyEmail={true}
                maxLength={1}
                keyType="numeric"
            />
            <Input
                placeholderText={"0"}
                fieldWidth={"20"}
                verifyEmail={true}
                maxLength={1}
                keyType="numeric"
            />
            <Input
                placeholderText={"0"}
                fieldWidth={"20"}
                verifyEmail={true}
                maxLength={1}
                keyType="numeric"
            />
            <Input
                placeholderText={"0"}
                fieldWidth={"20"}
                verifyEmail={true}
                maxLength={1}
                keyType="numeric"
            /> 
        </BoxInputRow>
        <Button>
            <ButtonTitle>Entrar</ButtonTitle>
        </Button>
        <LinkReenviarEmail url={"https://www.google.com/intl/pt-BR/gmail/about/"}>Reenviar Código</LinkReenviarEmail>
    </ContainerApp>