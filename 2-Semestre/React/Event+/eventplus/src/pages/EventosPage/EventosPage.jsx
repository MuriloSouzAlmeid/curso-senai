import React, { useContext, useEffect, useState } from "react";
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
import { ActivatedPage } from "../../context/ActivatedPage";

const EventosPage = () => {
  //contexts
  const { setActivatedPage } = useContext(ActivatedPage);

  //states
  const [listaDeEventos, setListaDeEventos] = useState([]);
  const [mostraSpinner, setMostraSpinner] = useState(false);
  const [formularioCadastro, setFormularioCadastro] = useState(true);
  const [listaDeTiposDeEventos, setListaDeTiposDeEventos] = useState([]);
  const [notifyUser, setNotifyUser] = useState({});

  const instituicao = "4b18d4c6-018b-4e45-8be8-46d59593e7e1";
  //const instituicao = "a54983d0-9e20-4149-aec7-ed8ed5257371";

  const [dadosEvento, setDadosEvento] = useState({
    idEvento: "",
    nomeEvento: "",
    descricao: "",
    dataEvento: "",
    idTipoEvento: "",
  });

  //use effect
  useEffect(() => {
    setActivatedPage("eventos");
    async function getEvents() {
      setMostraSpinner(true);

      try {
        const retornoEvento = await api.get("/Evento");

        setListaDeEventos(retornoEvento.data);

        const retornoTiposDeEvento = await api.get("/TiposEvento");

        let arrayGenerico = [];

        retornoTiposDeEvento.data.forEach((tp) => {
          arrayGenerico.push({
            value: tp.idTipoEvento,
            text: tp.titulo,
          });
        });

        setListaDeTiposDeEventos(arrayGenerico);
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

    if (dadosEvento.nomeEvento.length < 3) {
      setNotifyUser({
        titleNote: "Nome de Evento Inválido",
        textNote: `O nome do evento deve conter pelo menos 3 caracteres!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    } else if (new Date(dadosEvento.dataEvento) < new Date(Date.now())) {
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
      const cadastro = await api.post("/Evento", {
        nomeEvento: dadosEvento.nomeEvento,
        descricao: dadosEvento.descricao,
        dataEvento: dadosEvento.dataEvento,
        idTipoEvento: dadosEvento.idTipoEvento,
        idInstituicao: instituicao,
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

  async function mostraFormularioAtualizar(evento) {
    setFormularioCadastro(false);

    const retorno = await api.get(`/Evento/${evento.idEvento}`);

    setDadosEvento(retorno.data);

    // setNome(nomeEvento);
    // setDescricao(descricao);
    // setDataEvento(dateFormatDbToDateValue(dataEvento));
    // setIdTipoEventoSelecionado(idTipoEvento);
    // setIdEventoSelecionado(idEvento);
  }

  async function handleUpdate(e) {
    e.preventDefault();
    if (dadosEvento.nomeEvento.length < 3) {
      setNotifyUser({
        titleNote: "Nome de Evento Inválido",
        textNote: `O nome do evento deve conter pelo menos 3 caracteres!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }else if(new Date(dadosEvento.dataEvento) < new Date(Date.now())){
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

    try{
      await api.put(`/Evento/${dadosEvento.idEvento}`, {
        nomeEvento: dadosEvento.nomeEvento,
        dataEvento: dadosEvento.dataEvento,
        descricao: dadosEvento.descricao,
        idTipoEvento: dadosEvento.idTipoEvento
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
    }catch(erro){
      console.log(erro);
    }
    // try {
    //   const retorno = await api.put(`/Evento/${idEventoSelecionado}`, {
    //     nomeEvento: nome,
    //     descricao: descricao,
    //     dataEvento: dataEvento,
    //     idTipoEvento: idTipoEventoSelecionado,
    //     idInstituicao: idInstituicao,
    //   });
    //   atualizarListaEventos();
    //   cancelarEdit();
    //   setNotifyUser({
    //     titleNote: "Evento Atualizado Com Sucesso",
    //     textNote: `O Evento em questão foi atualizado com sucesso!`,
    //     imgIcon: "success",
    //     imgAlt:
    //       "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
    //     showMessage: true,
    //   });
    // } catch (error) {
    //   console.log(error);
    // }
  }

  function redefinirCamposFormulario() {
    setDadosEvento({
      idEvento: "",
      nomeEvento: "",
      descricao: "",
      dataEvento: "",
      idTipoEvento: "",
    });
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
            <form
              className="fevento"
              onSubmit={formularioCadastro ? handleSubmit : handleUpdate}
            >
              {formularioCadastro ? (
                <>
                  <Input
                    type={"text"}
                    id={"nome"}
                    value={dadosEvento.nomeEvento}
                    required={"required"}
                    name={"nome"}
                    placeholder={"Nome"}
                    manipulationFunction={(e) => {
                      setDadosEvento({
                        ...dadosEvento,
                        nomeEvento: e.target.value,
                      });
                    }}
                  />

                  <Input
                    type={"text"}
                    id={"descricao"}
                    value={dadosEvento.descricao}
                    required={"required"}
                    name={"descricao"}
                    placeholder={"Descrição"}
                    manipulationFunction={(e) => {
                      setDadosEvento({
                        ...dadosEvento,
                        descricao: e.target.value,
                      });
                    }}
                  />

                  <Select
                    id={"tipos-de-eventos"}
                    name={"tipos-de-eventos"}
                    defaultOptionText={"Tipo de Evento"}
                    required
                    dados={listaDeTiposDeEventos}
                    selectValue={dadosEvento.idTipoEvento}
                    mudaOpcao={(e) => {
                      setDadosEvento({
                        ...dadosEvento,
                        idTipoEvento: e.target.value,
                      });
                    }}
                  />

                  <Input
                    type={"date"}
                    id={"data-evento"}
                    value={dadosEvento.dataEvento}
                    required={"required"}
                    name={"data-evento"}
                    manipulationFunction={(e) => {
                      setDadosEvento({
                        ...dadosEvento,
                        dataEvento: e.target.value,
                      });
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
                    value={dadosEvento.nomeEvento}
                    required={"required"}
                    name={"nome"}
                    placeholder={"Nome"}
                    manipulationFunction={(e) => {
                      setDadosEvento({
                        ...dadosEvento,
                        nomeEvento: e.target.value,
                      });
                    }}
                  />

                  <Input
                    type={"text"}
                    id={"descricao"}
                    value={dadosEvento.descricao}
                    required={"required"}
                    name={"descricao"}
                    placeholder={"Descrição"}
                    manipulationFunction={(e) => {
                      setDadosEvento({
                        ...dadosEvento,
                        descricao: e.target.value,
                      });
                    }}
                  />

                  <Select
                    id={"tipos-de-eventos"}
                    name={"tipos-de-eventos"}
                    defaultOptionText={"Tipo de Evento"}
                    required
                    dados={listaDeTiposDeEventos}
                    selectValue={dadosEvento.idTipoEvento}
                    mudaOpcao={(e) => {
                      setDadosEvento({
                        ...dadosEvento,
                        idTipoEvento: e.target.value,
                      });
                    }}
                  />

                  <Input
                    type={"date"}
                    id={"data-evento"}
                    value={dateFormatDbToDateValue(dadosEvento.dataEvento)}
                    required={"required"}
                    name={"data-evento"}
                    manipulationFunction={(e) => {
                      setDadosEvento({
                        ...dadosEvento,
                        dataEvento: e.target.value,
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
