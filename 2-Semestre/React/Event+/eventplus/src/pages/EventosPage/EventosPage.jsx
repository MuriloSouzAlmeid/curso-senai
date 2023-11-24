import React, { useEffect, useState } from "react";
import "./EventosPage.css";

//import dos componentes
import Titulo from "../../components/Titulo/Titulo";
import MainContent from "../../components/MainContent/MainContent";
import Container from "../../components/Container/Container";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import TableEv from "./TableEv/TableEv";
import {
  Input,
  Button,
  Select,
} from "../../components/FormComponents/FormComponents";

//import da API
import api from "../../services/Service";

//import dos assets
import EventImage from "../../assets/images/evento.svg";

//import do Spinnet e Notification
import Spinner from "../../components/Spinner/Spinner";
import Notification from "../../components/Notification/Notification";

//import de Utils
import { dateFormatDbToDateValue } from "../../Utils/stringFunctions";

const EventosPage = () => {
  //states
  const [listaDeEventos, setListaDeEventos] = useState([]);
  const [mostraSpinner, setMostraSpinner] = useState(false);
  const [nome, setNome] = useState("");
  const [descricao, setDescricao] = useState("");
  const [dataEvento, setDataEvento] = useState("");
  const [idTipoEventoSelecionado, setIdTipoEventoSelecionado] = useState("");
  const [idEventoSelecionado, setIdEventoSelecionado] = useState("");
  const [idInstituicao, setIdInstituicao] = useState(
    "4b18d4c6-018b-4e45-8be8-46d59593e7e1"
  );
  const [formularioCadastro, setFormularioCadastro] = useState(true);
  const [listaDeTiposDeEventos, setListaDeTiposDeEventos] = useState([]);
  const [notifyUser, setNotifyUser] = useState({});

  const [eventoDados, setEventoDados] = useState({});

  //use effect
  useEffect(() => {
    async function getEvents() {
      setMostraSpinner(true);

      try {
        const retornoEvento = await api.get("/Evento");

        setListaDeEventos(retornoEvento.data);

        const retornoTiposDeEvento = await api.get("/TiposEvento");

        setListaDeTiposDeEventos(retornoTiposDeEvento.data);
      } catch (erro) {
        console.log(erro);
      }
    }

    getEvents();

    setMostraSpinner(false);
  }, []);

  // function tornarGenericos(listaDeTipoDeEventos){

  //   const novoArray = {};

  //   listaDeTipoDeEventos.foreach((tp) => {
  //     novoArray.push({
  //       [0]: idTipoEvento,
  //       [1]: titulo
  //     })
  //   })

  //   return novoArray;
  // }

  async function atualizarListaEventos() {
    try {
      const retorno = await api.get(`/Evento`);
      setListaDeEventos(retorno.data);
    } catch (error) {
      console.log(error);
    }
  }

  async function handleDelete(idEvento) {
    try {
      const retorno = await api.delete(`/Evento/${idEvento}`);

      setNotifyUser({
        titleNote: "Evento Deletado Com Sucesso",
        textNote: `O Evento em questão foi deletado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      atualizarListaEventos();
    } catch (erro) {
      console.log(erro);
    }
  }

  async function handleSubmit(e) {
    e.preventDefault();

    if (nome.length < 3) {
      setNotifyUser({
        titleNote: "Nome de Evento Inválido",
        textNote: `O nome do evento deve conter pelo menos 3 caracteres!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }else if(new Date(dataEvento) < new Date(Date.now())){
      setNotifyUser({
        titleNote: "Data do Evento Inválido",
        textNote: `Informe uma data válida para o evento!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }

    try {
      const retorno = await api.post("/Evento", {
        nomeEvento: nome,
        descricao: descricao,
        dataEvento: dataEvento,
        idTipoEvento: idTipoEventoSelecionado,
        idInstituicao: idInstituicao
      });

      atualizarListaEventos();
      redefinirCamposFormulario();

      setNotifyUser({
        titleNote: "Evento Cadastrado Com Sucesso",
        textNote: `O Evento em questão foi cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    } catch (erro) {
      console.log(erro);
    }
  }

  function mostraFormularioAtualizar(evento) {
    setFormularioCadastro(false);
    setEventoDados(evento);

    // const retorno = await api.get(`/Evento/${id}`);

    // const { idEvento, nomeEvento, descricao, dataEvento, idTipoEvento } =
    //   retorno.data;

    // setNome(nomeEvento);
    // setDescricao(descricao);
    // setDataEvento(dateFormatDbToDateValue(dataEvento));
    // setIdTipoEventoSelecionado(idTipoEvento);
    // setIdEventoSelecionado(idEvento);
  }

  async function handleUpdate(e) {
    e.preventDefault();

    if (nome.length < 3) {
      setNotifyUser({
        titleNote: "Nome de Evento Inválido",
        textNote: `O nome do evento deve conter pelo menos 3 caracteres!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }else if(new Date(dataEvento) < new Date(Date.now())){
      setNotifyUser({
        titleNote: "Data do Evento Inválido",
        textNote: `Informe uma data válida para o evento!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }

    try {
      const retorno = await api.put(`/Evento/${idEventoSelecionado}`, {
        nomeEvento: nome,
        descricao: descricao,
        dataEvento: dataEvento,
        idTipoEvento: idTipoEventoSelecionado,
        idInstituicao: idInstituicao,
      });

      atualizarListaEventos();
      cancelarEdit();

      setNotifyUser({
        titleNote: "Evento Atualizado Com Sucesso",
        textNote: `O Evento em questão foi atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    } catch (error) {
      console.log(error);
    }
  }

  function redefinirCamposFormulario() {
    setNome("");
    setDescricao("");
    setDataEvento("");
    setIdTipoEventoSelecionado("");
    setIdEventoSelecionado("");
  }

  function cancelarEdit() {
    redefinirCamposFormulario();
    setFormularioCadastro(true);
  }

  return (
    <MainContent>
      <section className="cadastro-evento-section">
        <Container>
          <Titulo titleText="Eventos" />
          <div className="cadastro-evento__box">
            <ImageIllustrator
              imageRender={EventImage}
              alterText={"Imagem de um cara vendo uns balões"}
            />
            <form className="fevento" onSubmit={ formularioCadastro ? handleSubmit : handleUpdate}>
              {formularioCadastro ? (
                <>
                  <Input
                    type={"text"}
                    id={"nome"}
                    value={nome}
                    required={"required"}
                    name={"nome"}
                    placeholder={"Nome"}
                    manipulationFunction={(e) => {
                      setNome(e.target.value);
                    }}
                  />

                  <Input
                    type={"text"}
                    id={"descricao"}
                    value={descricao}
                    required={"required"}
                    name={"descricao"}
                    placeholder={"Descrição"}
                    manipulationFunction={(e) => {
                      setDescricao(e.target.value);
                    }}
                  />

                  <Select
                    id={"tipos-de-eventos"}
                    name={"tipos-de-eventos"}
                    required
                    dados={listaDeTiposDeEventos}
                    selectValue={idTipoEventoSelecionado}
                    mudaOpcao={(e) => {
                      setIdTipoEventoSelecionado(e.target.value);
                    }}
                  />

                  <Input
                    type={"date"}
                    id={"data-evento"}
                    value={dataEvento}
                    required={"required"}
                    name={"data-evento"}
                    manipulationFunction={(e) => {
                      setDataEvento(e.target.value);
                    }}
                  />

                  <Button
                    id={"cadastrar-evento"}
                    name={"cadastrar-evento"}
                    type={"submit"}
                    textButton={"Cadastrar"}
                    manipulationFunction={handleSubmit}
                  />
                </>
              ) : (
                <>
                  <Input
                    type={"text"}
                    id={"nome"}
                    value={eventoDados.nomeEvento}
                    required={"required"}
                    name={"nome"}
                    placeholder={"Nome"}
                    manipulationFunction={(e) => {
                      setEventoDados({
                        ...eventoDados, 
                        nomeEvento: e.target.value
                      });
                    }}
                  />

                  <Input
                    type={"text"}
                    id={"descricao"}
                    value={eventoDados.descricao}
                    required={"required"}
                    name={"descricao"}
                    placeholder={"Descrição"}
                    manipulationFunction={(e) => {
                      setDescricao({
                        ...eventoDados,
                        descricao: e.target.value
                      });
                    }}
                  />

                  <Select
                    id={"tipos-de-eventos"}
                    name={"tipos-de-eventos"}
                    required
                    dados={listaDeTiposDeEventos}
                    selectValue={eventoDados.idTipoEvento}
                    mudaOpcao={(e) => {
                      setEventoDados({
                        ...eventoDados, idTipoEvento: e.target.value
                      });
                    }}
                  />

                  <Input
                    type={"date"}
                    id={"data-evento"}
                    value={dateFormatDbToDateValue(eventoDados.dataEvento)}
                    required={"required"}
                    name={"data-evento"}
                    manipulationFunction={(e) => {
                      setEventoDados({
                        ...eventoDados, dataEvento: e.target.value
                      });
                    }}
                  />

                  <div className="buttons-editbox">
                    <Button
                      id={"atualizar-evento"}
                      name={"atualizar-evento"}
                      type={"submit"}
                      textButton={"Atualizar"}
                    />
                    <Button
                      id={"cancelar-edit"}
                      name={"cancelar-edit"}
                      type={"button"}
                      textButton={"Cancelar"}
                      manipulationFunction={cancelarEdit}
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      <section className="lista-eventos-section">
        <Container>
          <Titulo titleText={"Lista de eventos"} color="white" />
          <TableEv
            dados={listaDeEventos}
            fnDelete={handleDelete}
            fnUpdate={mostraFormularioAtualizar}
          />
        </Container>
      </section>

      {mostraSpinner ? <Spinner /> : null}
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
    </MainContent>
  );
};

export default EventosPage;
