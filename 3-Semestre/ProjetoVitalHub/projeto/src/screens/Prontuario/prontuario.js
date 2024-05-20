import { useCallback, useEffect, useState } from "react";
import { LoadProfile } from "../../utils/Auth";
import { api } from "../../services/service";
import moment from "moment";
import { ContainerImagePerfil, ContainerProntuario, LoadingContainer } from "../../components/Container/style";
import { UserImagePerfil } from "../../components/UserImage/styled";
import { ApointmentFormBox, ButtonImageSubmit, ButtonImageSubmitContent, ButtonImageSubmitText, CancelImageSubmit, EditProntuarioButton, ImageInputBox, ImageInputBoxField, ImageInputBoxText, ImageSubmitBox, NenhumaImagemBox, ProntuarioBox, ResultadosOCRText, SendImageOCRBox, UserDataApointment } from "./style";
import { AgeUserText, ButtonTitle, EmailUserText, InputLabel, TextRegular, UserNamePerfilText } from "../../components/Text/style";
import { BoxInputField } from "../../components/Box";
import { Button } from "../../components/Button/styled";
import { LinkCancel } from "../../components/Link";
import MaterialCommunityIcons from '@expo/vector-icons/MaterialCommunityIcons';
import { ActivityIndicator, Image, View } from "react-native";
import { Input } from "../../components/Input";
import { ErrorModal, ModalCamera } from "../../components/Modal";
import { ObjetoEstaVazio, verificarCamposFormulario } from "../../utils/funcoesUteis";
import { useFocusEffect } from "@react-navigation/native";
import codegenNativeCommands from "react-native/Libraries/Utilities/codegenNativeCommands";

export const PaginaDeProntuario = ({ navigation, route }) => {
  const [openModalCamera, setOpenModalCamera] = useState(false);

  const [descricaoExame, setDescricaoExame] = useState(PreencherDescricaoExame);

  const [foto, setFoto] = useState("");

  const [editavel, setEditavel] = useState(false);

  const [perfilUsuario, setPerfilUsuario] = useState("");

  const [frmEditData, setFrmEditData] = useState(null);

  const [nome, setNome] = useState("");

  const [email, setEmail] = useState("");

  const [consulta, setConsulta] = useState(null);

  const [medicamento, setMedicamento] = useState(null);

  const [idadePaciente, setIdadePaciente] = useState(null);

  const [crm, setCrm] = useState("")

  const [especialidade, setEspecialidade] = useState("")

  const [fotoProntuario, setFotoProntuario] = useState("")

  const [listaDeExames, setListaDeExames] = useState([])

  const [resultadosOCR, setResultadosOCR] = useState("")

  const [mostrarLoading, setMostrarLoading] = useState(false)

  const [mostrarLoadingOCR, setMostrarLoadingOCR] = useState(false)

  const [enableButton, setEnableButton] = useState(true)

  const [enableButtonOCR, setEnableButtonOCR] = useState(true)



  
  const [textModal, setTextModal] = useState({title: "", content: ""})
  const [showModalError, setShowModalError] = useState(false)

  useEffect(() => {
    setConsulta(route.params.consulta);

    if (route.params.consulta.receita !== undefined) {
      setMedicamento(route.params.consulta.receita.medicamento);
    }

    LoadProfile().then((token) => {
      setPerfilUsuario(token.perfil);
      ProntuarioInfo(token.perfil)
    });
  }, []);

  const ProntuarioInfo = async (perfil) => {
    try {
      // const id = "8E942765-8128-4948-966B-45550C15962E"
      const retornoGet = await api.get(
        `/${perfil === "Paciente" ? "Medicos" : "Pacientes"}/BuscarPorId?id=${route.params.idUsuario}`
      );
      setNome(retornoGet.data.idNavigation.nome);
      setFotoProntuario(retornoGet.data.idNavigation.foto)

      if (perfil === "Paciente") {
        setCrm(retornoGet.data.crm)
        setEspecialidade(retornoGet.data.especialidade.especialidade1)
      }
      else {
        setEmail(retornoGet.data.idNavigation.email)
        setIdadePaciente(
          moment
            .duration(moment().diff(moment(retornoGet.data.dataNascimento)))
            .asYears()
        );
      }



    } catch (error) {
      console.log(error);
    }
  };

  function showUpdateForm(consulta) {
    setFrmEditData({
      ...consulta,
      medicamento: medicamento
    });
    setEditavel(true);
    // setFrmEdit(true);
  }

  const AbortarEdicaoProntuario = () => {
    setFrmEditData({});
    setEditavel(false);
  };

  // const [descricao, setDescricao] = useState({})
  // const [diagnostico, setDiagnostico] = useState({})
  const EditProntuario = async () => {
    setEnableButton(false)
    setMostrarLoading(true)
    try {
      await api.put("/Consultas/Prontuario", {
        consultaId: route.params.consulta.id,
        descricao: frmEditData.descricao,
        diagnostico: frmEditData.diagnostico,
        medicamento: frmEditData.medicamento,
      });

      setConsulta({
        ...consulta,
        descricao: frmEditData.descricao,
        diagnostico: frmEditData.diagnostico
      })

      setMedicamento(frmEditData.medicamento)

      await api.put(`/Consultas/Status?idConsulta=${route.params.consulta.id}&status=Realizada`)
      .then(() => {

      }).catch(erro => {
        console.log(erro);
      })
    } catch (error) {
      ChamarModalErro("Erro ao editar!" ,"tente novamente mais tarde" )
    }
    setMostrarLoading(false)
    setEnableButton(true)
    setEditavel(false);
  };

  useEffect(() => {
    setFrmEditData(route.params.consulta);
    if (route.params) {
      ProntuarioInfo(perfilUsuario);
    }
  }, [route.params]);

  const InserirExame = async () => {
    const formData = new FormData();
    formData.append("Imagem", {
      uri: foto,
      name: `image.${foto.split(".").pop()}`,
      type: `image/${foto.split(".").pop()}`,
    });

    await api.post(`/Exame/TranscreverTextoOCR`, formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    }).then((retornoApi) => {
      //vai somando todos os arquivos enviados
      setResultadosOCR(
        resultadosOCR + "\n" + retornoApi.data
      )
    })
      .catch((error) => {
        console.log(error);
      });
  };

  useEffect(() => {
    if (foto !== "") {
      InserirExame();
    }
  }, [foto]);


  useEffect(() => {
    ProntuarioInfo(perfilUsuario);
  }, [route.params])

  const CadastrarExame = async () => {
    setEnableButtonOCR(false)
    setMostrarLoadingOCR(true)
    await api.post(`/Exame?idConsulta=${route.params.consulta.id}&descricaoExame=${resultadosOCR}`).then(() => {
      setDescricaoExame(descricaoExame + "\n" + resultadosOCR)
      alert("Exame cadastrado")
    }).catch(erro => {
      console.log(erro);
    })
    setMostrarLoadingOCR(false)
    setEnableButtonOCR(true)
    setResultadosOCR("")
  }

  const CancelarEnvioExame = () => {
    setFoto("")
    setResultadosOCR("")
  }

  function PreencherDescricaoExame() {
    let resultadoForEach = ""

    route.params.consulta.exames.forEach(exame => {
      resultadoForEach = resultadoForEach + "\n" + exame.descricao
    })

    return resultadoForEach
  }

  useEffect(() => {
    const examesConsulta = PreencherDescricaoExame()
    if (examesConsulta !== descricaoExame) {

      setDescricaoExame(descricaoExame + "\n" + examesConsulta)
    }
  }, [])

  useEffect(() => {
    if(frmEditData !== null){
      setEnableButton(verificarCamposFormulario(frmEditData))
    }
  }, [frmEditData])


  const ChamarModalErro = (titulo, descricao) => {
    setTextModal({
      title: titulo,
      content: descricao
    })
    setShowModalError(true)
  }


  return consulta !== null ? (
    <>
      <ContainerProntuario>

        <ContainerImagePerfil>
          {fotoProntuario !== "" ?
            <UserImagePerfil
              source={{ uri: fotoProntuario }}
            />
            : null}

        </ContainerImagePerfil>
        <ProntuarioBox>
          <UserNamePerfilText editavel={true}>{
            `${(perfilUsuario === "Medico" ? "" : "Dr(a)")} ${nome}`
          }</UserNamePerfilText>
          <UserDataApointment>
            <AgeUserText>{perfilUsuario == "Medico" ?
              Math.round(idadePaciente) + " anos"
              :
              especialidade
            }
            </AgeUserText>
            <EmailUserText editavel={true}>
              {
                perfilUsuario == "Medico" ?
                  email
                  :
                  "CRM-" + crm

              }
            </EmailUserText>
          </UserDataApointment>

          <ApointmentFormBox>
            <BoxInputField
              apointment={perfilUsuario === "Medico" && editavel ? true : false}
              inputPerfil={!editavel ? true : false}
              fieldHeight="84"
              placeholderText={"Ainda não há descrição para esta consulta"}
              labelText={"Descrição da consulta"}
              fieldValue={editavel ? frmEditData.descricao : consulta.descricao}
              onChangeText={(txt) =>
                setFrmEditData({ ...frmEditData, descricao: txt })
              }
              editable={editavel}
            />
            <BoxInputField
              apointment={perfilUsuario === "Medico" && editavel ? true : false}
              inputPerfil={!editavel ? true : false}
              fieldHeight="84"
              placeholderText={"Ainda não há diagnósticos para esta consulta"}
              labelText={"Diagnóstico do paciente"}
              fieldValue={
                editavel ? frmEditData.diagnostico : consulta.diagnostico
              }
              onChangeText={(txt) =>
                setFrmEditData({ ...frmEditData, diagnostico: txt })
              }
              editable={editavel}
            />
            <BoxInputField
              apointment={perfilUsuario === "Medico" && editavel ? true : false}
              inputPerfil={!editavel ? true : false}
              fieldHeight="84"
              editable={editavel}
              placeholderText={"Ainda não há prescrições médicas para esta consulta"}
              labelText={"Prescrição médica"}
              fieldValue={editavel ? frmEditData.medicamento : medicamento}
              onChangeText={(text) => setFrmEditData({
                ...frmEditData,
                medicamento: text
              })}
            />
          </ApointmentFormBox>

          {/* Botões para alterar o usuário (só para médicos) */}
          {perfilUsuario === "Medico" ? (
            editavel ? (
              <EditProntuarioButton>
                <Button disable={!enableButton} onPress={enableButton ? () => EditProntuario() : null}>
                  {mostrarLoading ?
                    <ActivityIndicator color={"#FBFBFB"} />
                    :
                    <ButtonTitle>Salvar Edições</ButtonTitle>
                  }
                </Button>
                <LinkCancel onPress={() => AbortarEdicaoProntuario()}>
                  Cancelar
                </LinkCancel>
              </EditProntuarioButton>
            ) : (
              <EditProntuarioButton>
                <Button onPress={() => showUpdateForm(consulta)}>
                  <ButtonTitle>Editar</ButtonTitle>
                </Button>
              </EditProntuarioButton>
            )
          ) : null}

          {perfilUsuario === "Paciente" ? (
            <SendImageOCRBox>
              <ImageInputBox>
                <InputLabel>Exames médicos:</InputLabel>
                <ImageInputBoxField>
                  {resultadosOCR !== "" ?
                    <ResultadosOCRText>{resultadosOCR}</ResultadosOCRText>
                    :
                    <NenhumaImagemBox>
                      <MaterialCommunityIcons
                        name="file-upload-outline"
                        size={24}
                        color="#4E4B59"
                      />
                      <ImageInputBoxText>Nenhuma foto informada</ImageInputBoxText>
                    </NenhumaImagemBox>
                  }
                </ImageInputBoxField>
              </ImageInputBox>
              <ImageSubmitBox>
                <ButtonImageSubmit
                  underlayColor={"#496BBA"}
                  activeOpacity={1}
                  onPress={() => setOpenModalCamera(true)}
                >
                  <ButtonImageSubmitContent

                  >
                    <MaterialCommunityIcons
                      name="camera-plus-outline"
                      size={24}
                      color="white"
                    />
                    <ButtonImageSubmitText>Enviar</ButtonImageSubmitText>
                  </ButtonImageSubmitContent>
                </ButtonImageSubmit>
                <CancelImageSubmit onPress={() => CancelarEnvioExame()}>Cancelar</CancelImageSubmit>
              </ImageSubmitBox>

              {resultadosOCR != "" ? (
                <>
                  <Button disable={!enableButtonOCR} onPress={enableButtonOCR ? CadastrarExame : null}>
                    {mostrarLoadingOCR ?
                    <ActivityIndicator color={"#FBFBFB"} />
                    : 
                    <ButtonTitle onPress={CadastrarExame}>Enviar exames</ButtonTitle>
                    }
                  </Button>
                </>
              ) : null}
            </SendImageOCRBox>
          ) : null}

          <View
            style={{
              height: 2,
              backgroundColor: "#8C8A97",
              width: "100%",
              borderRadius: 5,
              marginBottom: 10,
              marginTop: 20
            }}
          ></View>

          <BoxInputField
            labelText={"Resultados dos Exames"}
            inputPerfil
            placeholderText={"Ainda não há resultados de exames submetidos"}
            fieldHeight="60"
            fieldValue={descricaoExame}
          />
          {/* Campos Para envio de Exames (só para pacientes) */}

          {/* Link Para voltar para a Home */}
          <LinkCancel onPress={() => navigation.replace("Main")}>
            Voltar Para a Home
          </LinkCancel>
        </ProntuarioBox>

        <ErrorModal
  visible={showModalError}
  setShowModalError={setShowModalError}
  textModal={textModal}
/>
      </ContainerProntuario>

      {/* Modal Para abrir a câmera (só para paciente) */}
      {perfilUsuario === "Paciente" ? (
        <ModalCamera
          visible={openModalCamera}
          setShowModal={setOpenModalCamera}
          enviarFoto={setFoto}
          getMediaLibrary
        />
      ) : null}
    </>
  ) : (
    <LoadingContainer />
  ); 
};

