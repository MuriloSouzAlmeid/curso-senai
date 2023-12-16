import React, { useContext, useEffect, useState } from "react";

import "./EventosAlunoPage.css";

import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Titulo/Titulo";
import Table from "./TableEva/TableEva";
import Container from "../../components/Container/Container";
import { Select } from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal";
import Notification from "../../components/Notification/Notification";
import api from "../../services/Service";

import { GetEventIdDescription } from "../../Utils/GetEventIdDescription";

import { UserContext } from "../../context/AuthContext";

import { ActivatedPage } from "../../context/ActivatedPage";
import TiposEventos from "../TiposEventosPage/TiposEventos";
import { useNavigate } from "react-router-dom";

const EventosAlunoPage = () => {
  // contexts
  const { setActivatedPage } = useContext(ActivatedPage);
  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: 1, text: "Todos os eventos" },
    { value: 2, text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const [notifyUser, setNotifyUser] = useState({});
  const [idEventoComentario, setIdEventoComentario] = useState("");
  const [descricaoComentario, setDescricaoComentario] = useState("");
  const [idComentario, setIdComentario] = useState(null);

  const navigate = useNavigate();

  async function loadEventsType() {
    setShowSpinner(true);

    try {
      if (tipoEvento === "1") {
        const retornoEventos = await api.get(`/Evento`);

        const retornoPresencas = await api.get(
          `/PresencasEvento/ListarMInhas/${userData.userId}`
        );

        const eventosMarcados = verificarPresenca(
          retornoEventos.data,
          retornoPresencas.data
        );

        setEventos(eventosMarcados);
        console.log(eventosMarcados);
      } else {
        let arrayEventos = [];

        const retornoEventos = await api.get(
          `/PresencasEvento/ListarMInhas/${userData.userId}`
        );

        retornoEventos.data.forEach((elemento) => {
          arrayEventos.push({
            ...elemento.evento,

            situacao: elemento.situacao,
            idPresencaEvento: elemento.idPresencaEvento,
          });
        });

        setEventos(arrayEventos);
      }
    } catch (error) {
      console.log(error);
    }

    setShowSpinner(false);
  }

  useEffect(() => {
    setActivatedPage("eventos-aluno");

    loadEventsType();
  }, [tipoEvento, userData.userId]);

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  const showHideModal = (idEvento) => {
    setShowModal(showModal ? false : true);
    setIdEventoComentario(idEvento);

    if (idEvento === "") {
      setDescricaoComentario("");
    }
  };

  async function loadMyComentary(idUsuario, idEvento) {
    try {
      const retornoComentario = await api.get(
        `/ComentariosEvento/ListarPorUsuarioEvento?idUsuario=${idUsuario}&idEvento=${idEvento}`
      );

      if(retornoComentario.data.length === 0){
        setDescricaoComentario("Ainda não foi feito comentário para este evento")
        setIdComentario("")
      }else{
        setDescricaoComentario(retornoComentario.data[0].descricao);
        setIdComentario(retornoComentario.data[0].idComentarioEvento)
      }

      // setDescricaoComentario(retornoComentario.data.descricao);
      // setIdComentario(retornoComentario.data.idComentarioEvento);
    } catch (erro) {
      console.log(erro);
    }
  }

  const commentaryRemove = async (idComentario, idEvento, idUsuario) => {
    try {
      if (idComentario === "") {
        alert("Ainda não há comentário");
        return;
      }

      await api.delete(`/ComentariosEvento/${idComentario}`);
      alert("comentário apagado");

      loadMyComentary(idUsuario, idEvento);
    } catch (erro) {
      console.log(erro);
    }
  };

  const postarComentario = async (descricao, idEvento, idUsuario, idComentario) => {
    try {
      if(idComentario === ""){
        await api.post("/ComentariosEvento", {
          descricao: descricao,
          idEvento: idEvento,
          idUsuario: idUsuario
        });

        alert("comentário cadastrado")

        loadMyComentary(idUsuario, idEvento);
      }else{
        alert("Só é possível cadastrar um comentário por evento")
      }
    } catch (erro) {
      console.log(erro);
    }
  };

  async function handleConnect(statusConexao, idEvento, idPresencaEvento) {
    // alert(statusConexao ? "Desconectar" : "Conectar");

    if (!statusConexao) {
      try {
        await api.post("/PresencasEvento", {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvento,
        });

        setNotifyUser({
          titleNote: "inscrição Realizada com Sucesso",
          textNote: `Sua inscrição no evento em questão foi realizada com sucesso!`,
          imgIcon: "success",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });

        loadEventsType();
      } catch (erro) {
        console.log(erro);
      }
    }

    if (statusConexao) {
      try {
        await api.delete(`/PresencasEvento/${idPresencaEvento}`);

        loadEventsType();
      } catch (erro) {
        console.log(erro);
      }
    }
  }

  const verificarPresenca = (allEvents, userEvents) => {
    for (let x = 0; x < allEvents.length; x++) {
      for (let i = 0; i < userEvents.length; i++) {
        if (allEvents[x].idEvento === userEvents[i].evento.idEvento) {
          allEvents[x].situacao = true;
          allEvents[x].idPresencaEvento = userEvents[i].idPresencaEvento;
          break;
        }
      }
    }

    return allEvents;
  };

  const handleDetalharEvento = (idEvento) => {
    GetEventIdDescription(idEvento, navigate)
  }

  return (
    <>
      <MainContent>
        <Container>
          <Title titleText={"Eventos"} additionalClass="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            dados={quaisEventos} // aqui o array dos tipos
            mudaOpcao={(e) => myEvents(e.target.value)} // aqui só a variável state
            selectValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            tableType={tipoEvento}
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={showHideModal}
            carregarDetalhes={handleDetalharEvento}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnGet={loadMyComentary}
          fnDelete={commentaryRemove}
          fnPost={postarComentario}
          eventId={idEventoComentario}
          comentaryText={descricaoComentario}
          idComentario={idComentario}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
