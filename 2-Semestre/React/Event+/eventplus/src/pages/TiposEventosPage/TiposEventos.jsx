import React, { useState, useEffect, useContext } from "react";
import "./TiposEventos.css";

//import da api
import api from "../../services/Service";

//import dos componentes
import Titulo from "../../components/Titulo/Titulo";
import MainContent from "../../components/MainContent/MainContent";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import Container from "../../components/Container/Container";
import TableTp from "./TableTp/TableTp";
import Notification from "../../components/Notification/Notification";
import Spinner from '../../components/Spinner/Spinner'

//pois não é um export default
import { Input, Button } from "../../components/FormComponents/FormComponents";

import imageTipoEvento from "../../assets/images/tipo-evento.svg";
import { ActivatedPage } from "../../context/ActivatedPage";

const TiposEventos = () => {
  //contexts
  const {setActivatedPage} = useContext(ActivatedPage);

  //states
  const [formEdit, setFormEdit] = useState(false);
  const [titulo, setTitulo] = useState("");
  const [idTipoEvento, setIdTipoEvento] = useState("");
  const [listaTiposDeEventos, setListaTiposDeEventos] = useState([]);
  const [notifyUser, setNotifyUser] = useState({});
  const [showSpinner, setShowSpinner] = useState(false);

  //ao carregar a página
  useEffect(() => {
    setActivatedPage('tipos-eventos')

    async function getEvetsType() {
      
      //antes de consultar a api
      setShowSpinner(true);
      try {
        const promisse = await api.get("/TiposEvento");
        setListaTiposDeEventos(promisse.data);
      } catch (error) {
        setNotifyUser({
          titleNote: "Deu Ruim na API",
          textNote: `Não foi possíve entrar na tela de edição. Abra o console para ver o erro`,
          imgIcon: "danger",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
        console.log(error);
      }
    }
    getEvetsType();

    //depois de consultar a api
    setShowSpinner(false);
  }, []);

  //métodos/funções do componente
  async function handleSubmit(e) {
    //já passa o event automaticamente
    //parar o submit do formulário
    e.preventDefault();

    //validar no mínimo 3 caracteres
    if (titulo.trim().length < 3) {
      setNotifyUser({
        titleNote: "Nome do Tipo Inválido",
        textNote: `O título deve ter no mínimo 3 caracteres!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return; //retorna a função a  aqui mesmo
    }
    setNotifyUser({
      titleNote: "Sucesso",
      textNote: `Cadastrado com sucesso!`,
      imgIcon: "success",
      imgAlt:
        "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
      showMessage: true,
    });

    //chamar a api e cadastrar no banco de dados
    try {
      // o post requer como parâmetros qual a rota a ser acessada e qual o corpo de rquisição
      const retorno = await api.post("/TiposEvento", { titulo: titulo }); //representa o JSON

      setTitulo(""); //limpa o estado

      atualizarListaDeTiposDeEventos();
    } catch (error) {
      console.log(error);
    }
  }

  // ATUALIZAÇÃO DOS DADOS

  //funçào que puxa os dados atuais e coloca o formulário em modo de edição
  async function showUpdateForm(idElemento) {
    setFormEdit(true);

    //pegar o título do tipo de evento em questão - get by id

    try {
      const retorno = await api.get(`/TiposEvento/${idElemento}`);

      const { idTipoEvento, titulo } = await retorno.data;

      setIdTipoEvento(idTipoEvento);
      setTitulo(titulo);
    } catch (error) {
      setNotifyUser({
        titleNote: "Deu Ruim na API",
        textNote: `Não foi possíve entrar na tela de edição. Abra o console para ver o erro`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      console.log(error);
    }
  }

  //função que atualiza os dados na api
  async function handleUpdate(e) {
    e.preventDefault();

    if (titulo.trim().length < 3) {
      setNotifyUser({
        titleNote: "Nome do Tipo Inválido",
        textNote: `O título deve ter no mínimo 3 caracteres!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }

    try {
      //como a propriedade e o valor possuem o mesmo nome posso simplificar
      const retorno = await api.put(`/TiposEvento/${idTipoEvento}`, { titulo });

      editActionAbort();

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      atualizarListaDeTiposDeEventos();
    } catch (error) {
      console.log(error);
    }
  }

  //função que cancela a operação de atualizar
  function editActionAbort() {
    setFormEdit(false);
    setTitulo("");
    setIdTipoEvento("");
  }

  // FUNÇÃO para deletar um tipo de evento
  async function handleDelete(id) {
    try {
      const retorno = await api.delete(`/TiposEvento/${id}`);

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Deletado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      const promisse = await api.get("/TiposEvento");

      setListaTiposDeEventos(promisse.data);
    } catch (error) {
      console.log(error);
    }
  }

  async function atualizarListaDeTiposDeEventos() {
    const promisse = await api.get(`/TiposEvento/`);
    setListaTiposDeEventos(promisse.data);
  }













  
  return (
    <MainContent>
      {/* Cadastro de Tipo de Eventos */}
      <section className="cadastro-evento-section">
        <Container>
          <Titulo titleText={"Página de Tipos de Eventos"} />
          <div className="cadastro-evento__box">
            <ImageIllustrator
              alterText={"Imagem da página de tipos de eventos"}
              imageRender={imageTipoEvento}
            />
            <form
              className="ftipo-evento"
              onSubmit={formEdit ? handleUpdate : handleSubmit}
            >
              {/* compara se está em modo de cadastro ou edição */}
              {!formEdit ? (
                // Cadastrar
                <>
                  <p>Tela de Cadastro</p>
                  <Input
                    value={titulo}
                    type={"text"}
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Título"}
                    required={"required"}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  <Button
                    textButton={"Cadastrar"}
                    id={"button"}
                    type={"submit"}
                  />
                </>
              ) : (
                // Atualizar
                <>
                  <p>Tela de Edição</p>
                  <Input
                    value={titulo}
                    type={"text"}
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Novo Título"}
                    required={"required"}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />

                  {/* div para os botões de editar e cancelar */}
                  <div className="buttons-editbox">
                    <Button
                      textButton={"Atualizar"}
                      id={"atualizar"}
                      name={"atualizar"}
                      type={"submit"}
                      additionalClass={"button-component--middle"}
                    />
                    <Button
                      textButton={"Cancelar"}
                      id={"cancelar"}
                      name={"cancelar"}
                      type={"button"}
                      additionalClass={"button-component--middle"}
                      manipulationFunction={editActionAbort}
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      {/* Listagem de Tipos de Eventos */}
      <section className="lista-eventos-section">
        <Container>
          <Titulo titleText={"Tipo de Eventos Cadastrados"} color="white" />
          <TableTp
            dados={listaTiposDeEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>

      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />

      {showSpinner ? (
        <Spinner />
      ) : null}
      
    </MainContent>
  );
};

export default TiposEventos;
