import { ButtonTitle, EmailUserText, SemiBoldText, TextRegular, Title, UserNamePerfilText } from "../../components/Text/style";
import { ContainerApp, ContainerForm, ContainerImagePerfil, ContainerPerfilPage, LoadingContainer } from "../../components/Container/style";
import { UserImagePerfil } from "../../components/UserImage/styled";
import { BoxInputRow, UserContentBox } from "../../components/Box/style";
import { BoxInputField } from "../../components/Box";
import { Button, ButtonCamera, ButtonEditPhoto } from "../../components/Button/styled";
import { useEffect, useState } from "react";
import { LinkCancel } from "../../components/Link";
import { ActivityIndicator, View } from "react-native";
import { LoadProfile, UserLogout } from "../../utils/Auth";
import { api, apiViaCep } from "../../services/service";
import { ObjetoEstaVazio, validarData, verificarCamposFormulario } from "../../utils/funcoesUteis";
import moment from "moment";
import { LoadingIndicator } from "../../components/LoadingIndicator";
import { MaterialCommunityIcons } from '@expo/vector-icons';

import * as MediaLibrary from 'expo-media-library'
import * as ImagePicker from 'expo-image-picker'
import { ErrorModal, ModalCamera } from "../../components/Modal";

import { mascararCep, mascararCpf, mascararRg, desmascararCep, desmascararRg, desmascararCpf, mascararData } from "../../utils/StringMask"

export const PerfilDeUsuario = ({ navigation }) => {
    const [editavel, setEditavel] = useState(false);
  
    const [cep, setCep] = useState("");
  
    const [perfilUsuario, setPerfilUsuario] = useState("");
    const [idUsuario, setIdUsurio] = useState("");
    const [dadosUsuario, setDadosUsuario] = useState({});
    const [dadosAtualizarUsuario, setDadosAtualizarUsuario] = useState({});
  
    const [showCamera, setShowCamera] = useState(false);
  
    const [fotoRecebida, setFotoRecebida] = useState("");
  
    const [logradouro, setLogradouro] = useState("");
    const [cidade, setCidade] = useState("");
  
    const [mostrarLoading, setMostrarLoading] = useState(false);
    const [enableButton, setEnableButton] = useState(true);
  
  
    const [textModal, setTextModal] = useState({title: "", content: ""})
    const [showModalError, setShowModalError] = useState(false)
  
  
    useEffect(() => {
      setEnableButton(verificarCamposFormulario(dadosAtualizarUsuario));
    }, [dadosAtualizarUsuario]);
  
    useEffect(() => {
      LoadProfile()
        .then((token) => {
          setPerfilUsuario(token.perfil);
          setIdUsurio(token.idUsuario);
          CarregarDadosUsuario(token.idUsuario, token.perfil);
        })
        .catch((erro) => {
          console.log(`Não foi possível buscar as informações do usuário`);
          console.log(`Erro: ${erro}`);
        });
  
      requestGaleria();
    }, []);
  
    const CarregarDadosUsuario = async (idUsuario, perfil) => {
      await api
        .get(`/${perfil}s/BuscarPorId?id=${idUsuario}`)
        .then((response) => {
          setDadosUsuario(response.data);
        })
        .catch((erro) => {
          console.log(erro);
          // alert(erro)
        });
    };
  
    useEffect(() => {
      if (idUsuario != "") {
        CarregarDadosUsuario(idUsuario, perfilUsuario);
      }
    }, [idUsuario]);
  
    const ModoEdicaoUsuario = () => {
      setDadosAtualizarUsuario({
        ...dadosUsuario,
        dataNascimento: moment(dadosUsuario.dataNascimento).format("DD/MM/YYYY"),
      });
      setEditavel(true);
      setCep(dadosUsuario.endereco.cep);
      setLogradouro(dadosUsuario.endereco.logradouro);
      setCidade(dadosUsuario.endereco.localidade);
    };
  
    const AbortarEdicaoUsuario = () => {
      setDadosAtualizarUsuario({});
      setEditavel(false);
    };
  
    const AtualizarUsuario = async (idUsuario) => {
      setEnableButton(false);
      setMostrarLoading(true);

      if(!validarData(dadosAtualizarUsuario.dataNascimento)){
        ChamarModalErro("Data de Nascimento Inválida", "Informe uma data de nascimento válida para os dias atuais")
        return
      }

      const arrayData = dadosAtualizarUsuario.dataNascimento.split("/");
      const dataAtalizada = `${arrayData[2]}-${arrayData[1]}-${arrayData[0]}`;
  
      const tipoUsuario = "2C48012E-32A6-4FC6-85D4-42C009E9F4D8";
  
      await api
        .put(`/Pacientes?idUsuario=${idUsuario}`, {
          rg: desmascararRg(dadosAtualizarUsuario.rg),
          cpf: desmascararCpf(dadosAtualizarUsuario.cpf),
          dataNascimento: dataAtalizada,
          cep: desmascararCep(cep),
          logradouro: logradouro,
          numero: parseInt(dadosAtualizarUsuario.endereco.numero),
          cidade: cidade,
          nome: dadosAtualizarUsuario.idNavigation.nome,
          idTipoUsuario: tipoUsuario,
        })
        .then(() => {
          CarregarDadosUsuario(idUsuario, perfilUsuario).then(() => {
            setEditavel(false);
          });
        })
        .catch((error) => {
          ChamarModalErro("Erro ao editar!" ,"tente novamente mais tarde" )
        });
      setMostrarLoading(false);
      setEnableButton(true);
  
      setEditavel(false);
    };
  
    const requestGaleria = async () => {
      await MediaLibrary.requestPermissionsAsync();
  
      await ImagePicker.requestMediaLibraryPermissionsAsync();
    };
  
    //função para alterar foto do uauário
    const AlterarFotoPerfil = async () => {
      const formData = new FormData();
      formData.append("Arquivo", {
        uri: fotoRecebida,
        name: `image.${fotoRecebida.split(".").pop()}`,
        type: `image/${fotoRecebida.split(".").pop()}`,
      });
  
      await api
        .put(`/Usuario/AlterarFotoPerfil?idUsuario=${idUsuario}`, formData, {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        })
        .then((response) => {})
        .catch((erro) => {
          console.log(erro);
        });
    };
  
    useEffect(() => {
      if (fotoRecebida !== null) {
        AlterarFotoPerfil();
        CarregarDadosUsuario(idUsuario, perfilUsuario);
      }
    }, [fotoRecebida]);
  
    const BuscarEnderecoPorCep = async () => {
      if (cep.length < 9) {
        return null;
      }
  
      await apiViaCep
        .get(`${desmascararCpf(cep)}/json/`)
        .then((retornoApi) => {
          setLogradouro(retornoApi.data.logradouro);
          setCidade(retornoApi.data.localidade);
        })
        .catch((error) => {
          console.log(error);
        });
    };
  
    useEffect(() => {
      BuscarEnderecoPorCep();
    }, [cep]);
  
  
  
    const ChamarModalErro = (titulo, descricao) => {
      setTextModal({
        title: titulo,
        content: descricao
      })
      setShowModalError(true)
    }
  
    return !ObjetoEstaVazio(dadosUsuario) ? (
      <>
        <ContainerPerfilPage>
          <ContainerImagePerfil>
            <UserImagePerfil
              source={{
                uri:
                  fotoRecebida === ""
                    ? dadosUsuario.idNavigation.foto
                    : fotoRecebida,
              }}
            />
  
            <ButtonEditPhoto onPress={() => setShowCamera(true)}>
              <MaterialCommunityIcons
                name="camera-plus"
                size={20}
                color={"#FBFBFB"}
              />
            </ButtonEditPhoto>
          </ContainerImagePerfil>
          {!editavel ? (
            <>
              <UserContentBox editavel={editavel}>
                <UserNamePerfilText editavel={editavel}>
                  {dadosUsuario.idNavigation.nome}
                </UserNamePerfilText>
                <EmailUserText editavel={editavel}>
                  {dadosUsuario.idNavigation.email}
                </EmailUserText>
              </UserContentBox>
            </>
          ) : null}
  
          <ContainerForm marginTop={editavel ? 20 : 75}>
            {editavel ? (
              <>
                <BoxInputField
                  labelText={"Nome:"}
                  placeholderText={"Nome Completo"}
                  inputPerfil
                  fieldValue={dadosUsuario.idNavigation.nome}
                />
              </>
            ) : null}
            {perfilUsuario == "Medico" ? (
              <>
                <BoxInputField
                  labelText={"CRM:"}
                  keyType="numeric"
                  placeholderText={"Crm do médico"}
                  editable={editavel}
                  multiline={false}
                  inputPerfil
                  fieldValue={
                    editavel ? dadosAtualizarUsuario.crm : dadosUsuario.crm
                  }
                  onChangeText={(text) =>
                    setDadosAtualizarUsuario({
                      ...dadosAtualizarUsuario,
                      crm: text,
                    })
                  }
                />
              </>
            ) : (
              <>
                <BoxInputField
                  labelText={"RG:"}
                  placeholderText={"Rg do paciente"}
                  keyType="numeric"
                  editable={editavel}
                  multiline={false}
                  inputPerfil
                  fieldValue={
                    editavel
                      ? mascararRg(dadosAtualizarUsuario.rg)
                      : mascararRg(dadosUsuario.rg)
                  }
                  onChangeText={(text) =>
                    setDadosAtualizarUsuario({
                      ...dadosAtualizarUsuario,
                      rg: text,
                    })
                  }
                />
  
                <BoxInputField
                  labelText={"Data De Nascimento:"}
                  placeholderText={"Data de nascimento do paciente"}
                  editable={editavel}
                  inputPerfil
                  fieldValue={
                    editavel
                      ? mascararData(dadosAtualizarUsuario.dataNascimento)
                      : moment(dadosUsuario.dataNascimento).format("DD/MM/YYYY")
                  }
                  onChangeText={(text) =>
                    setDadosAtualizarUsuario({
                      ...dadosAtualizarUsuario,
                      dataNascimento: text,
                    })
                  }
                />
                <BoxInputField
                  labelText={"CPF:"}
                  placeholderText={"Cpf do Paciente"}
                  keyType="numeric"
                  editable={editavel}
                  multiline={false}
                  inputPerfil
                  fieldValue={
                    editavel
                      ? mascararCpf(dadosAtualizarUsuario.cpf)
                      : mascararCpf(dadosUsuario.cpf)
                  }
                  onChangeText={(text) =>
                    setDadosAtualizarUsuario({
                      ...dadosAtualizarUsuario,
                      cpf: text,
                    })
                  }
                />
              </>
            )}
  
            <BoxInputRow>
              <BoxInputField
                labelText={"Endereço:"}
                placeholderText={"Rua Das Goiabeiras"}
                fieldValue={
                  editavel ? logradouro : dadosUsuario.endereco.logradouro
                }
                inputPerfil
                fieldWidth={47}
              />
              <BoxInputField
                labelText={"Número:"}
                placeholderText={"XX"}
                fieldValue={
                  editavel
                    ? dadosAtualizarUsuario.endereco.numero.toString()
                    : dadosUsuario.endereco.numero.toString()
                }
                keyType="numeric"
                multiline={false}
                editable
                inputPerfil
                fieldWidth={47}
                onChangeText={(text) =>
                  setDadosAtualizarUsuario({
                    ...dadosAtualizarUsuario,
                    endereco: {
                      ...dadosAtualizarUsuario.endereco,
                      numero: text,
                    },
                  })
                }
              />
            </BoxInputRow>
            <BoxInputRow>
              <BoxInputField
                labelText={"CEP:"}
                placeholderText={"Cep de sua Residência"}
                fieldWidth={47}
                keyType={"numeric"}
                multiline={false}
                editable={editavel}
                inputPerfil
                fieldValue={
                  editavel
                    ? mascararCep(cep)
                    : mascararCep(dadosUsuario.endereco.cep)
                }
                onChangeText={(text) => setCep(text)}
              />
              <BoxInputField
                labelText={"Cidade:"}
                placeholderText={"Ribeirão Pires"}
                fieldWidth={47}
                fieldValue={editavel ? cidade : dadosUsuario.endereco.cidade}
                inputPerfil
              />
            </BoxInputRow>
            {perfilUsuario === "Paciente" ? (
              editavel ? (
                <>
                  <Button
                    disable={!enableButton}
                    onPress={
                      enableButton ? () => AtualizarUsuario(idUsuario) : null
                    }
                  >
                    {mostrarLoading ? (
                      <ActivityIndicator color={"#FBFBFB"} />
                    ) : (
                      <ButtonTitle>Salvar Edições</ButtonTitle>
                    )}
                  </Button>
                </>
              ) : (
                <Button onPress={() => ModoEdicaoUsuario()}>
                  <ButtonTitle>Editar</ButtonTitle>
                </Button>
              )
            ) : null}
          </ContainerForm>
          {editavel ? (
            <LinkCancel onPress={() => AbortarEdicaoUsuario()}>
              Cancelar
            </LinkCancel>
          ) : (
            <LinkCancel onPress={() => UserLogout(navigation)}>
              Deslogar
            </LinkCancel>
          )}
  
          <View style={{ height: 30 }}></View>
  
          <ErrorModal
            visible={showModalError}
            setShowModalError={setShowModalError}
            textModal={textModal}
          />
        </ContainerPerfilPage>
  
        <ModalCamera
          visible={showCamera}
          setShowModal={setShowCamera}
          enviarFoto={setFotoRecebida}
          getMediaLibrary
        />
      </>
    ) : (
      <>
        <LoadingIndicator />
      </>
    );
}