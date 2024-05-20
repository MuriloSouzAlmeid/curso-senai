import { View } from "react-native";
import { BoxInputField } from "../../components/Box";
import { UserContentBox } from "../../components/Box/style";
import { Button } from "../../components/Button/styled";
import { ContainerForm, ContainerPerfilPage } from "../../components/Container/style";
import { Input } from "../../components/Input";
import { ButtonTitle, EmailUserText, InputLabel, UserNamePerfilText } from "../../components/Text/style";
import { UserImagePerfil } from "../../components/UserImage/styled";
import { UserDataApointment } from "../Prontuario/style";
import { ButtonImageSubmit, ButtonImageSubmitContent, ButtonImageSubmitText, CancelImageSubmit, ImageInputBox, ImageInputBoxField, ImageInputBoxText, ImageSubmitBox } from "./style";
import { MaterialCommunityIcons } from '@expo/vector-icons';
import { LinkCancel } from "../../components/Link";
import { LinkSemiBoldCancel, LinkVoltar } from "../../components/Link/style";

import * as MediaLibrary from 'expo-media-library'

import { Camera, CameraType } from "expo-camera";
import { useEffect, useRef, useState } from "react";
import { ModalCamera } from "../../components/Modal";

export const VisualizarPrescricao = ({ navigation }) => {

    const [openModalCamera, setOpenModalCamera] = useState(false)
    
    const [descricaoExame, setDescricaoExame] = useState("")

    const [foto, setFoto] = useState("")

    const InserirExame = async () => {
        const idConsulta = "121C2076-6457-4253-9DA1-8B36E6B2A90C"


        const formData = new FormData()
        formData.append("ConsultaId", idConsulta)
        formData.append("Imagem", {
            uri: foto,
            name: `image.${foto.split(".").pop()}`,
            type: `image/${foto.split(".").pop()}`
        });


        await api.post(`/Exame`, formData, {
            headers: {
                "Content-Type": "multipart/form-data"
            }
        }).then(retornoApi => {
            //vai somando todos os arquivos enviados
            setDescricaoExame( descricaoExame + "\n" + retornoApi.data.descricao)
        }).catch(error => {
            console.log(error);
        })
    }

    useEffect(() => {
        if (foto !== "") {
            InserirExame()
        }

    }, [foto])

    return (
        <>
            <ContainerPerfilPage>
                <UserImagePerfil
                    source={require("../../assets/images/doctor_image_perfil.png")}
                />
                <UserContentBox
                    editavel
                >
                    <UserNamePerfilText editavel>Dr. Lucas</UserNamePerfilText>
                    <UserDataApointment>
                        <EmailUserText>Clínico geral</EmailUserText>
                        <EmailUserText editavel>CRM-18293</EmailUserText>
                    </UserDataApointment>
                </UserContentBox>
                <ContainerForm>
                    <BoxInputField
                        labelText={"Descrição da consulta"}
                        inputPerfil
                        fieldHeight="40"
                    />
                    <BoxInputField
                        labelText={"Diagnóstico do paciente:"}
                        placeholderText={"diagnóstico"}
                        inputPerfil
                    />
                    <BoxInputField
                        labelText={"Prescrição médica:"}
                        placeholderText={"prescrição"}
                        inputPerfil
                        fieldHeight="40"
                    />

                    <ImageInputBox>
                        <InputLabel>Exames médicos:</InputLabel>
                        <ImageInputBoxField>
                            {(foto === "") ? <MaterialCommunityIcons name="file-upload-outline" size={24} color="#4E4B59" /> : null}
                            
                            <ImageInputBoxText>
                                {(foto === "") ? "Nenhuma foto informada" : 
                                <Image
                                    style={{height: "100%", width: "100%"}}
                                    source={{uri: foto}}
                                />}
                            </ImageInputBoxText>
                        </ImageInputBoxField>
                    </ImageInputBox>
                    <ImageSubmitBox>
                        <ButtonImageSubmit
                            underlayColor={"#496BBA"}
                            activeOpacity={1}
                            onPress={() => setOpenModalCamera(true)}
                        >
                            <ButtonImageSubmitContent>
                                <MaterialCommunityIcons name="camera-plus-outline" size={24} color="white" />
                                <ButtonImageSubmitText>Enviar</ButtonImageSubmitText>
                            </ButtonImageSubmitContent>
                        </ButtonImageSubmit>
                        <CancelImageSubmit>Cancelar</CancelImageSubmit>
                    </ImageSubmitBox>

                    <View
                        style={{ height: 2, backgroundColor: "#8C8A97", width: "100%", borderRadius: 5 }}
                    >
                    </View>

                    <Input
                        inputPerfil
                        placeholderText={"Resultados..."}
                        fieldHeight="60"
                        fieldvalue={descricaoExame}
                    />

                    <LinkVoltar onPress={() => navigation.replace("Main")}>
                        Voltar
                    </LinkVoltar>
                </ContainerForm>
            </ContainerPerfilPage>

            <ModalCamera
                visible={openModalCamera}
                setShowModal={setOpenModalCamera}
                enviarFoto={setFoto}
                getMediaLibrary
            />
        </>
    )
}