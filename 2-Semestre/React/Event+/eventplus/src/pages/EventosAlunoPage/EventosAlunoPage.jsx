import React, { useContext, useEffect, useState } from "react";

import "./EventosAlunoPage.css";

import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Titulo/Titulo";
import Table from "./TableEva/TableEva";
import Container from "../../components/Container/Container";
import { Select } from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal";
import api from "../../services/Service";

import { UserContext } from "../../context/AuthContext";

import { ActivatedPage } from "../../context/ActivatedPage";
import TiposEventos from "../TiposEventosPage/TiposEventos";

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

  useEffect(() => {
    setActivatedPage("eventos-aluno");

    async function loadEventsType() {
      setShowSpinner(true);

      try {
        if (tipoEvento === "1") {
          const retornoEventos = await api.get(`/Evento`);

          setEventos(retornoEventos.data);
        } else {

          let arrayEventos = [];

          const retornoEventos = await api.get(
            `/PresencasEvento/ListarMInhas/${userData.userId}`
          );

          retornoEventos.data.forEach((elemento) => {
            arrayEventos.push(elemento.evento);
          });

          setEventos(arrayEventos);
        }

      } catch (error) {
        console.log(error);
      }

      setShowSpinner(false);
    }

    loadEventsType();
  }, [tipoEvento]);

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  function handleConnect() {
    alert("Desenvolver a função conectar evento");
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
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
