import { useEffect, useState } from "react";
import { BoxInput } from "../../components/Box/style";
import { Button } from "../../components/Button/styled";
import { ContainerProfile } from "../../components/Container/style";
import { Input } from "../../components/Input";
import { LogoVitalHub } from "../../components/Logo";
import { IconContainer, IconImage } from "../../components/NavigationIcons/style";
import { ButtonTitle, TextRegular, TitleRedefinirSenha } from "../../components/Text/style";
import { api } from "../../services/service";
import { ActivityIndicator } from "react-native";
import { ErrorModal } from "../../components/Modal";

export const ReceberEmail = ({ navigation }) => {

    const [mostrarLoading, setMostrarLoading] = useState(false)

    const [email, setEmail] = useState("")

    const [enableButton, setEnableButton] = useState(true)

    const [showModalError, setShowModalError] = useState(false)
    const [inputError, setInputError] = useState(false)


    const HandlePrees = async () => {
        setEnableButton(false)
        setMostrarLoading(true)
        await api.post(`/RecuperarSenha?email=${email}`)
            .then(() => {
                navigation.replace("VerificarEmail", { userEmail: email })
            }).catch(error => {
                setShowModalError(true)
                setInputError(true)
            })
        setMostrarLoading(false)
        setEnableButton(true)
    }

    useEffect(() => {
        if(email === ""){
            setEnableButton(false)
        }else{
            setEnableButton(true)
        }
    }, [email])

    return (
        <ContainerProfile>
            <IconContainer
                onPress={() => navigation.replace("Login")}
            >
                <IconImage
                    source={require("../../assets/images/voltar_icon.png")}
                />
            </IconContainer>
            <LogoVitalHub />
            <TitleRedefinirSenha>Recuperar senha</TitleRedefinirSenha>
            <TextRegular>Digite abaixo seu email cadastrado que enviaremos um link para recuperação de senha</TextRegular>
            <BoxInput>
                <Input
                    placeholderText={"Insira seu email aqui"}
                    editable
                    fieldvalue={email}
                    onChangeText={text => setEmail(text)}
                    error={inputError}
                />
            </BoxInput>
            <Button disable={!enableButton} onPress={enableButton ? () => HandlePrees() : null}>
                {mostrarLoading ?
                    <ActivityIndicator color={"#FBFBFB"} />
                    :
                    <ButtonTitle>Confirmar</ButtonTitle>
                }
            </Button>

            <ErrorModal
                visible={showModalError}
                setShowModalError={setShowModalError}
                textModal={{title: "Usuário não encontrado", content: "Não há usuário cadastrado em nossa plataforma com o email informado, tente novamente com um email cadastrado"}}
            />
        </ContainerProfile>
    )
}