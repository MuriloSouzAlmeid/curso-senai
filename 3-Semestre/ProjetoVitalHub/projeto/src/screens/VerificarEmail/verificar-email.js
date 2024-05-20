import { ActivityIndicator, TouchableOpacity } from "react-native";
import { BoxInputRow } from "../../components/Box/style";
import { Button } from "../../components/Button/styled";
import { ContainerProfile } from "../../components/Container/style";
import { Input } from "../../components/Input";
import { LinkReenviarEmail, LinkVerifyEmail } from "../../components/Link";
import { LogoVitalHub } from "../../components/Logo";
import { ButtonTitle, TextRegular, TitleVerificarEmail } from "../../components/Text/style"
import { IconCntainer, IconImage } from "../../components/NavigationIcons/style";
import { IconContainer } from "../../components/NavigationIcons/style";
import { useEffect, useState } from "react";
import { api } from "../../services/service";
import { ErrorModal } from "../../components/Modal";

export const VerificarEmail = ({ navigation, route }) => {

    const [primeiroCodigo, setPrimeiroCodigo] = useState("")
    const [segundoCodigo, setSegundoCodigo] = useState("")
    const [terceiroCodigo, setTerceiroCodigo] = useState("")
    const [quartoCodigo, setQuartoCodigo] = useState("")

    const [email, setEmail] = useState("")

    const [mostrarLoading, setMostrarLoading] = useState(false)

    const [mostrarLoadingEmail, setMostrarLoadingEmail] = useState(false)

    const [enableButton, setEnableButton] = useState(false)

    const [showModalError, setShowModalError] = useState(false)
    const [inputError, setInputError] = useState(false)

    const [textModal, setTextModal] = useState({
        title: "",
        content: ""
    })

    const HandlePress = async () => {
        const codigoCompleto = `${primeiroCodigo}${segundoCodigo}${terceiroCodigo}${quartoCodigo}`
        setEnableButton(false)
        setMostrarLoading(true)
        await api.post(`/RecuperarSenha/ValidarCodigoRecuperacaoSenha?email=${email}&codigo=${codigoCompleto}`)
            .then(() => {
                navigation.replace("RedefinirSenha", { userEmail: email })
            }).catch(erro => {

                setInputError(true)
                ChamarModalErro("Código inválido", "O código informado é inválido, tente novamente com o código correto ou requisite um novo código por email")
            })
        setMostrarLoading(false)
        setEnableButton(true)
    }

    const ReenviarEmail = async (email) => {
        setMostrarLoadingEmail(true)
        await api.post(`/RecuperarSenha?email=${email}`)
            .then(() => {
                ChamarModalErro("Email Reenviado", "Verifique sua caixa de email e insira o novo código nos campos indicados")
            }).catch(error => {
                ChamarModalErro("Erro ao Reenviar Email", "Ocorreu um erro ao tentar reenviar um novo código ao email informado, tente novamente mais tarde")
            })
        setMostrarLoading(false)
    }

    useEffect(() => {
        setEmail(route.params.userEmail)
    }, [route])

    useEffect(() => {
        if(primeiroCodigo === "" || segundoCodigo === "" || terceiroCodigo === "" || quartoCodigo === ""){
            setEnableButton(false)
        }else{
            setEnableButton(true)
        }
    }, [primeiroCodigo, segundoCodigo, terceiroCodigo, quartoCodigo])

    useEffect(() => {

    })

    const ChamarModalErro = (titulo, descricao) => {
        setTextModal({
          title: titulo,
          content: descricao
        })
        setShowModalError(true)
      }

    return (
        <ContainerProfile>
            <IconContainer
                onPress={() => navigation.replace("Login")}
            >
                <IconImage
                    source={require("../../assets/images/fechar_icon.png")}
                />
            </IconContainer>
            <LogoVitalHub />
            <TitleVerificarEmail>
                Verifique seu email
            </TitleVerificarEmail>
            <TextRegular>Digite o código de 4 dígitos enviado para</TextRegular>
            <LinkVerifyEmail url={"https://www.google.com/intl/pt-BR/gmail/about/"}>{route.params.userEmail}</LinkVerifyEmail>
            <BoxInputRow>
                <Input
                    placeholderText={"0"}
                    fieldWidth={"20"}
                    verifyEmail
                    error={inputError}
                    maxLength={1}
                    fieldvalue={primeiroCodigo}
                    editable
                    onChangeText={text => setPrimeiroCodigo(text)}
                />
                <Input
                    placeholderText={"0"}
                    fieldWidth={"20"}
                    error={inputError}
                    verifyEmail
                    maxLength={1}
                    fieldvalue={segundoCodigo}
                    editable
                    onChangeText={text => setSegundoCodigo(text)}
                />
                <Input
                    placeholderText={"0"}
                    fieldWidth={"20"}
                    error={inputError}
                    verifyEmail
                    maxLength={1}
                    fieldvalue={terceiroCodigo}
                    editable
                    onChangeText={text => setTerceiroCodigo(text)}
                />
                <Input
                    placeholderText={"0"}
                    fieldWidth={"20"}
                    error={inputError}
                    verifyEmail
                    maxLength={1}
                    fieldvalue={quartoCodigo}
                    editable
                    onChangeText={text => setQuartoCodigo(text)}
                />
            </BoxInputRow>
            <Button disable={!enableButton} onPress={enableButton ? () => HandlePress() : null}>
                {mostrarLoading ?
                    <ActivityIndicator color={"#FBFBFB"} />
                    :
                    <ButtonTitle onPress={enableButton ? () => HandlePress() : null}>Confirmar</ButtonTitle>
                }

            </Button>
            {mostrarLoadingEmail ?
            <ActivityIndicator/>
            : 
            <LinkReenviarEmail onPress={() => ReenviarEmail(route.params.userEmail)}>Reenviar Código</LinkReenviarEmail>
            }
            

            <ErrorModal
                visible={showModalError}
                setShowModalError={setShowModalError}
                textModal={textModal}
            />
        </ContainerProfile>
    )
}