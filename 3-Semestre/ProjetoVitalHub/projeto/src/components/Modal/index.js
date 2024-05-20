import { ActivityIndicator, Modal, StyleSheet, TouchableOpacity, View } from "react-native"
import { BoxInputConsulta, CameraContent, ConsultaModal, DadosConsultaBox, DadosConsultaText, DadosConsultaTitle, ImageContent, ImagemRecebida, LastPhoto, LinhaDadosConsulta, ModalConsultaForm, ModalContent, ModalSubtitle, ModalText, ModalTextRow, PatientModal, ResumoConsultaBox, SwitchCameraTypeButton, SwitchCameraTypeIcon } from "./style"
import { ButtonTitle, SemiBoldText, TextRegular, Title } from "../Text/style"
import { Button, ButtonCamera, ButtonModal } from "../Button/styled"
import { LinkCancel } from "../Link"
import { UserImageModal } from "../UserImage/styled"
import { useEffect, useRef, useState } from "react"
import { ButtonModalConsulta } from "../Button"
import { BoxButtonRow } from "../Box/style"
import { ButtonContinuarBox } from "../Box"
import { ApointmentInputField } from "../Input/style"
import { Input } from "../Input"
import { AntDesign } from '@expo/vector-icons';

import * as MediaLibrary from 'expo-media-library'
import * as ImagePicker from 'expo-image-picker'

import { Camera, CameraView } from 'expo-camera'
import moment from "moment"
import { api } from "../../services/service"
import { LoadProfile, UserDecodeToken } from "../../utils/Auth"
import { TextAge } from "../Card/style"
import { verificarCamposFormulario } from "../../utils/funcoesUteis"

export const CancelattionModal = ({ infoConsulta, visible, setShowModalCancel, ListarConsultas = null, ...rest }) => {
    const [mostrarLoading, setMostrarLoading] = useState(false)

    const CancelarConsulta = async () => {
        setMostrarLoading(true)
        await api.put(`/Consultas/Status?idConsulta=${infoConsulta.id}&status=Cancelada`)
            .then(() => {

                ListarConsultas()
                setShowModalCancel(false)
            }).catch(error => {
                alert(`Erro ao cancelar consult. Erro: ${error}`)
                console.log(`/Consultas/Status?idConsulta=${infoConsulta.id}&status=Cancelada`);
            })
        setMostrarLoading(false)
    }

    return (
        <Modal {...rest}
            visible={visible}
            transparent={true}
            animationType="fade"
        >
            <PatientModal>
                <ModalContent>
                    <Title>Cancelar Consulta</Title>
                    <ModalText>Ao cancelar essa consulta, abrirá uma possível disponibilidade no seu horário, deseja mesmo cancelar essa consulta?</ModalText>



                    <ButtonModal onPress={() => CancelarConsulta()}>
                        {mostrarLoading ?
                            <ActivityIndicator color={"#FBFBFB"} />
                            :
                            <ButtonTitle onPress={() => CancelarConsulta()}>Confirmar</ButtonTitle>
                        }
                    </ButtonModal>

                    <LinkCancel onPress={() => setShowModalCancel(false)}>Cancelar</LinkCancel>
                </ModalContent>
            </PatientModal>
        </Modal>
    )
}

export const ApointmentModal = ({
    visible,
    setShowModalApointment,
    informacoes,
    navigation,
    idUsuario,
    botaoAtivado = true,
    ...resto
}) => {

    const [enableButton, setEnableButton] = useState(true)

    const NavegarPaginaDeProntuario = () => {
        navigation.replace("PaginaDeProntuario", { consulta: informacoes, idUsuario: idUsuario });
        setShowModalApointment(false);
    };

    const [idadePaciente, setIdadePaciente] = useState(moment.duration(moment().diff(moment(informacoes.paciente.dataNascimento))).asYears());

    useEffect(() => {
        const data = moment(informacoes.dataConsulta, "YYYY-MM-DD HH:mm")

        // if(moment() > data){    
        //     setEnableButton(true)
        // }else{
        //     setEnableButton(false)
        // }

    }, [informacoes.dataConsulta])

    return (
        <Modal {...resto} visible={visible} transparent={true} animationType="fade">
            <PatientModal>
                <ModalContent>
                    <UserImageModal
                        source={{ uri: informacoes.paciente.idNavigation.foto }}
                    />

                    <Title>
                        {informacoes.paciente.idNavigation.nome}
                    </Title>

                    <ModalTextRow>
                        <ModalText>
                            {Math.round(idadePaciente)} anos
                        </ModalText>
                        <ModalText>
                            {informacoes.paciente.idNavigation.email}
                        </ModalText>
                    </ModalTextRow>

                    <ButtonModal
                        disable={!enableButton}
                        onPress={enableButton ? (() => NavegarPaginaDeProntuario()) : null}
                    >
                        <ButtonTitle
                            onPress={enableButton ? (() => NavegarPaginaDeProntuario()) : null}
                        >
                            Inserir Prontuário
                        </ButtonTitle>
                    </ButtonModal>

                    <LinkCancel onPress={() => setShowModalApointment(false)}>
                        Cancelar
                    </LinkCancel>
                </ModalContent>
            </PatientModal>
        </Modal>
    );
};

export const AgendarConsultaModal = ({ visible, setShowModal, navigation, ...resto }) => {

    // state para o nível de consulta
    const [nivelConsulta, setNivelConsulta] = useState("")
    const [agendamento, setAgendamento] = useState({
        localizacao: "",
        prioridadeId: "",
        prioridadeLabel: ""
    });

    const [enableButton, setEnableButton] = useState(false)

    //Casa:
    // const idRotina = "CFFD0762-BE13-4615-9D23-111467A1C50C"
    const idRotina = "41D4F148-8757-439A-859F-F505B51B5CCD"

    //Casa
    // const idExame = "AB926C59-CC1B-4DDF-9409-2D600654D5F6"
    const idExame = "1EC174BF-389B-418A-88FA-9D475178905F"

    //Casa:
    // const idUrgencia = "A958B6ED-9FAF-4592-B1BF-7E5A16249904"
    const idUrgencia = "3F8EA35F-31FB-43D6-A67D-11536CB33DF9"

    const handleContinue = async () => {
        await setShowModal(false)
        navigation.replace("SelecionarClinica", { agendamento: agendamento })
    }

    const IncluirNivelPrioridade = (id, label) => {
        setAgendamento({
            ...agendamento,
            prioridadeId: id,
            prioridadeLabel: label
        })
    }

    useEffect(() => {
        setEnableButton(verificarCamposFormulario(agendamento))
    }, [agendamento])

    return (
        <Modal
            visible={visible}
            transparent
            animationType="fade"
            {...resto}
        >
            <PatientModal>
                <ConsultaModal>
                    <Title>Agendar Consulta</Title>
                    <ModalConsultaForm>
                        <BoxInputConsulta>
                            <ModalSubtitle>Qual o nível da consulta</ModalSubtitle>
                            <BoxButtonRow>
                                <ButtonModalConsulta
                                    buttonText={"Rotina"}
                                    situacao={"rotina"}
                                    actived={nivelConsulta === "rotina"}
                                    manipulationFunction={setNivelConsulta}
                                    idPrioridade={idRotina}
                                    labelPrioridade="Rotina"
                                    manipularAgendamento={IncluirNivelPrioridade}
                                />
                                <ButtonModalConsulta
                                    buttonText={"Exame"}
                                    situacao={"exame"}
                                    actived={nivelConsulta === "exame"}
                                    manipulationFunction={setNivelConsulta}
                                    idPrioridade={idExame}
                                    labelPrioridade="Exame"
                                    manipularAgendamento={IncluirNivelPrioridade}
                                />
                                <ButtonModalConsulta
                                    buttonText={"Urgência"}
                                    situacao={"urgencia"}
                                    actived={nivelConsulta === "urgencia"}
                                    manipulationFunction={setNivelConsulta}
                                    idPrioridade={idUrgencia}
                                    labelPrioridade="Urgência"
                                    manipularAgendamento={IncluirNivelPrioridade}
                                />
                            </BoxButtonRow>
                        </BoxInputConsulta>
                        <BoxInputConsulta>
                            <ModalSubtitle>Informe a localizaçào desejada</ModalSubtitle>
                            <Input
                                placeholderText={"Informe a localização"}
                                apointment
                                editable
                                center
                                onChangeText={text => setAgendamento({
                                    ...agendamento,
                                    localizacao: text
                                })}
                                fieldvalue={agendamento ? agendamento.localizacao : null}
                            />
                        </BoxInputConsulta>
                    </ModalConsultaForm>
                    <ButtonModal disable={!enableButton} onPress={enableButton ? () => handleContinue() : null}>
                        <ButtonTitle>Continuar</ButtonTitle>
                    </ButtonModal>
                    <LinkCancel onPress={() => setShowModal(false)}>Cancelar</LinkCancel>
                </ConsultaModal>
            </PatientModal>
        </Modal>
    )
}

export const ConfirmarConsultaModal = ({ agendamento, visible, setShowModal = null, navigation, ...resto }) => {
    const [idUsuario, setIdUsuario] = useState(null)

    const [mostrarLoading, setMostrarLoading] = useState(false)

    const [enableButton, setEnableButton] = useState(true)

    // const situacaoAgendada = "04609AD7-6EB2-465A-B5AC-A13DAEB56E5F"
    const situacaoAgendada = "558E9B82-71DD-46DC-A4C5-5B9D65B3D0A0"

    const HandleConfirm = async () => {
        setEnableButton(false)

        setMostrarLoading(true)
        await api.post(`/Consultas/Cadastrar`, {
            situacaoId: situacaoAgendada,
            pacienteId: idUsuario,
            medicoClinicaId: agendamento.medicoClinicaId,
            prioridadeId: agendamento.prioridadeId,
            dataConsulta: agendamento.dataConsulta
        }).then(() => {
            setShowModal(false)

            navigation.replace("Main")
        }).catch(erro => {
            console.log(erro);
            console.log(idUsuario);
        })
        setMostrarLoading(false)
        setEnableButton(true)
    }

    useEffect(() => {
        LoadProfile()
            .then(token => {
                setIdUsuario(token.idUsuario)
            })
    }, [])

    return (
        <Modal
            {...resto}
            visible={visible}
            transparent
            animationType="fade"
        >
            <PatientModal>
                {agendamento ?
                    <ModalContent>
                        <Title>Agendar consulta</Title>
                        <ResumoConsultaBox>
                            <TextRegular>Consulte os dados selecionados para a sua consulta</TextRegular>
                            <DadosConsultaBox>
                                <LinhaDadosConsulta>
                                    <DadosConsultaTitle>Data da consulta</DadosConsultaTitle>
                                    <DadosConsultaText>{moment(agendamento.dataConsulta).format("DD/MM/YYYY HH:mm")}</DadosConsultaText>
                                </LinhaDadosConsulta>
                                <LinhaDadosConsulta>
                                    <DadosConsultaTitle>Médico(a) da consulta</DadosConsultaTitle>
                                    <DadosConsultaText>{agendamento.medicoNome}</DadosConsultaText>
                                    <DadosConsultaText>{agendamento.medicoEspecialidade}</DadosConsultaText>
                                </LinhaDadosConsulta>
                                <LinhaDadosConsulta>
                                    <DadosConsultaTitle>Clínica da consulta</DadosConsultaTitle>
                                    <DadosConsultaText>{agendamento.nomeFantasia}</DadosConsultaText>
                                </LinhaDadosConsulta>
                                <LinhaDadosConsulta>
                                    <DadosConsultaTitle>Local da consulta</DadosConsultaTitle>
                                    <DadosConsultaText>{agendamento.localizacao}</DadosConsultaText>
                                </LinhaDadosConsulta>
                                <LinhaDadosConsulta>
                                    <DadosConsultaTitle>Tipo da consulta</DadosConsultaTitle>
                                    <DadosConsultaText>{agendamento.prioridadeLabel}</DadosConsultaText>
                                </LinhaDadosConsulta>
                            </DadosConsultaBox>
                        </ResumoConsultaBox>

                        <Button disable={!enableButton} onPress={enableButton ? () => HandleConfirm() : null}>
                            {mostrarLoading ?
                                <ActivityIndicator color={"#FBFBFB"} />
                                :
                                <ButtonTitle>Confirmar</ButtonTitle>
                            }
                        </Button>
                        <LinkCancel onPress={() => setShowModal(false)}>Cancelar</LinkCancel>
                    </ModalContent>
                    : null}
            </PatientModal>
        </Modal>
    )
}

export const ConsultaModalCard = ({ perfilUsuario, consulta, visible, setShowModal = null, navigation, ...resto }) => {

    const [idadePaciente, setIdadePaciente] = useState(null)

    const HandlePress = () => {
        setShowModal(false)
        navigation.replace("LocalConsulta", { clinicaId: consulta.medicoClinica.clinicaId });
    }

    useEffect(() => {

        if (perfilUsuario === "Medico") {
            const diferenca = moment().diff(moment(consulta.paciente.dataNascimento))
            setIdadePaciente(moment.duration(diferenca).asYears());
        }

    }, [])

    return (consulta !== null ?
        <Modal
            {...resto}
            visible={visible}
            transparent
            animationType="fade"
        >
            <PatientModal>
                <ModalContent>
                    <UserImageModal
                        source={{
                            uri: perfilUsuario === "Paciente" ? consulta.medicoClinica.medico.idNavigation.foto
                                : consulta.paciente.idNavigation.foto
                        }}
                    />

                    <Title>{perfilUsuario === "Paciente" ? consulta.medicoClinica.medico.idNavigation.nome
                        : consulta.paciente.idNavigation.nome}</Title>

                    <ModalTextRow>
                        {perfilUsuario === "Paciente" ? (
                            <>
                                <ModalText>{consulta.medicoClinica.medico.especialidade.especialidade1}</ModalText>
                                <ModalText>CRM-{consulta.medicoClinica.medico.crm}</ModalText>
                            </>
                        ) : (
                            <>
                                <TextAge>{idadePaciente} anos</TextAge>
                                <ModalText>{consulta.paciente.idNavigation.email}</ModalText>
                            </>
                        )
                        }
                    </ModalTextRow>

                    <ButtonModal onPress={HandlePress}>
                        <ButtonTitle onPress={HandlePress}>Ver Local da Consulta</ButtonTitle>
                    </ButtonModal>

                    <LinkCancel onPress={() => setShowModal(false)}>Cancelar</LinkCancel>
                </ModalContent>
            </PatientModal>
        </Modal>
        : null)
}

export const ModalCamera = ({ visible, setShowModal = null, enviarFoto, getMediaLibrary = false, ...resto }) => {
    const cameraRef = useRef(null)

    const [tipoCamera, setTipoCamera] = useState("back")

    const [lastPhoto, setLastPhoto] = useState(null)
    const [photo, setPhoto] = useState(null)

    const [showModalImage, setShowModalImage] = useState(false)

    const GetLatestPhoto = async () => {
        //ordena a lista de fotos da galeria do maior ao menor e pega o primeiro item
        const { assets } = await MediaLibrary.getAssetsAsync({ sortBy: [[MediaLibrary.SortBy.creationTime, false]], first: 1 })


        console.log(assets);

        if (assets.length > 0) {
            setLastPhoto(assets[0].uri)
        }
    }

    useEffect(() => {
        (async () => {
            const { status: cameraStatus } = Camera.requestCameraPermissionsAsync()
            const { status: mediaStatus } = MediaLibrary.requestPermissionsAsync()
        })()

        //verificar se tem a necessidade de mostrar a galeria
        if (getMediaLibrary) {
            GetLatestPhoto()
        }
    }, [])

    const CapturarFoto = async () => {
        if (cameraRef) {
            const captura = await cameraRef.current.takePictureAsync()

            setPhoto(captura.uri)
            setShowModalImage(true)
        }
    }

    const SelectImageGalery = async () => {
        const result = await ImagePicker.launchImageLibraryAsync({
            mediaTypes: ImagePicker.MediaTypeOptions.Images,
            quality: 1
        })

        if (!result.canceled) {
            setPhoto(result.assets[0].uri)
            setShowModalImage(true)
        }
    }

    return (
        <>
            <Modal {...resto}
                visible={visible}
                transparent
                animationType="fade"

            >
                <PatientModal>

                    <CameraContent>
                        <SwitchCameraTypeButton
                            onPress={() => setTipoCamera(tipoCamera === "front" ? "back" : "front")}
                        >
                            <SwitchCameraTypeIcon
                                source={require("../../assets/images/switch_image_icon.png")}
                            />
                        </SwitchCameraTypeButton>
                        <View style={{ height: "90%", width: "100%", borderRadius: 15 }}>
                            <CameraView
                                ref={cameraRef}
                                ratio='15:9'
                                facing={tipoCamera}
                                style={styles.camera}
                            />
                        </View>
                        <View style={{ width: "100%", flexDirection: "row", alignItems: "center", justifyContent: "center", gap: 30 }}>
                            <ButtonCamera onPress={() => CapturarFoto()}>
                                <AntDesign name="camera" size={24} color="white" />
                            </ButtonCamera>
                            <ButtonCamera
                                onPress={() => setShowModal(false)}
                                close
                            >
                                <AntDesign name="close" size={24} color="white" />
                            </ButtonCamera>

                            <TouchableOpacity onPress={() => SelectImageGalery()}>
                                {
                                    lastPhoto !== null ?
                                        <LastPhoto
                                            source={{ uri: lastPhoto }}
                                        />
                                        : (
                                            null
                                        )
                                }
                            </TouchableOpacity>
                        </View>
                    </CameraContent>

                </PatientModal>
            </Modal>

            <ModalImageCamera
                visible={showModalImage}
                setShowModalImage={setShowModalImage}
                setShowModalCamera={setShowModal}
                setFotoFinal={enviarFoto}
                image={photo}
            />
        </>
    )
}


export const ModalImageCamera = ({ visible, setShowModalImage, setShowModalCamera, image, setFotoFinal, ...resto }) => {
    const RetornarFoto = (foto) => {
        setFotoFinal(foto)
        setShowModalImage(false)
        setShowModalCamera(false)
    }

    return (
        <Modal {...resto}
            visible={visible}
            transparent
            animationType="fade"

        >
            <PatientModal>
                <ImageContent>
                    <ImagemRecebida
                        source={{ uri: image }}
                    />
                    <Button onPress={() => RetornarFoto(image)}>
                        <ButtonTitle>Confirmar</ButtonTitle>
                    </Button>
                    {/* <TextRegular>{image}</TextRegular> */}
                    <LinkCancel onPress={() => setShowModalImage(false)}>Voltar</LinkCancel>
                </ImageContent>

            </PatientModal>
        </Modal>
    )
}

export const ErrorModal = ({ textModal, visible, setShowModalError, ...rest }) => {
    return (
        <Modal {...rest}
            visible={visible}
            transparent={true}
            animationType="fade"
        >
            <PatientModal>
                <ModalContent>
                    {/* <Title>Email ou senha incorretos</Title> */}
                    <Title>{textModal.title}</Title>
                    {/* <ModalText>email ou senha icorretos, digite novamente</ModalText> */}
                    <ModalText>{textModal.content}</ModalText>



                    <ButtonModal onPress={() => setShowModalError(false)}>
                        <ButtonTitle onPress={() => setShowModalError(false)}>Voltar</ButtonTitle>
                    </ButtonModal>
                </ModalContent>
            </PatientModal>
        </Modal>
    )
}

const styles = StyleSheet.create({
    camera: {
        width: "100%",
        height: "100%"
    }
})