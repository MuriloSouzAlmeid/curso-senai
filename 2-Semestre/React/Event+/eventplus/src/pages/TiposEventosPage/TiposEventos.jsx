import React, { useState, useEffect } from "react";
import "./TiposEventos.css";

//import da api
import api from '../../services/Service';

//import dos componentes
import Titulo from "../../components/Titulo/Titulo";
import MainContent from "../../components/MainContent/MainContent";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import Container from "../../components/Container/Container";
import TableTp from "./TableTp/TableTp";

//pois não é um export default
import { Input, Button } from "../../components/FormComponents/FormComponents";

import imageTipoEvento from "../../assets/images/tipo-evento.svg";

const TiposEventos = () => {
  const [listaTiposDeEventos, setListaTiposDeEventos] = useState([]);

  useEffect(() => {
    async function getEvetsType(){
      try{
        const promisse = await api.get('/TiposEvento');
        setListaTiposDeEventos(promisse.data);
      }catch(error){
        alert('Deu rum na api');
        console.log(error);
      }
    }
    getEvetsType();
  }, [listaTiposDeEventos]);

  //states
  const [formEdit, setFormEdit] = useState(false);
  const [titulo, setTitulo] = useState();

  //métodos/funções do componente
  async function handleSubmit(e) { //já passa o event automaticamente
    //parar o submit do formulário
    e.preventDefault();

    //validar no mínimo 3 caracteres
    if(titulo.trim().length < 3){
      alert('O título deve ter no mínimo 3 caracteres');  
      return; //retorna a função a  aqui mesmo
    }

    //chamar a api e cadastrar no banco de dados
    try{
                            // o post requer como parâmetros qual a rota a ser acessada e qual o corpo de rquisição
      const retorno = await api.post('/TiposEvento', {titulo : titulo})//representa o JSON

      alert('Tipos de evento cadastrado com sucesso!!');
      setTitulo(''); //limpa o estado
    }catch(error){
      console.log(error);
    }
  }



// ATUALIZAÇÃO DOS DADOS

//funçào que puxa os dados atuais e coloca o formulário em modo de edição
function showUpdateForm(){
  alert('Mostrando a tela de update')
  console.log(listaTiposDeEventos);
}

//função que atualiza os dados na api
async function handleUpdate(e) {
    // e.preventDefault();

    // if(titulo.trim().length < 3){
    //     alert('O título deve ter no mínimo 3 caracteres');
    //     return;
    // }

    // try{
    //   const retorno = await api.put(`/TiposEvento/`);
    // }catch(error){
    //   console.log(error);
    // }
}

//função que cancela a operação de atualizar
function editActionAbort(){

}

  function handleDelete(){
    alert('Bora apagar lá na api')
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
                    manipulationFunction={
                      (e) => {
                        setTitulo(e.target.value);
                      }
                    }
                  />
                  <span>{titulo}</span>
                </>
              ) : (
                // Atualizar
                <p>Tela de Edição</p>
              )}

              <Button textButton={"Cadastrar"} id={"button"} type={"submit"} />
            </form>
          </div>
        </Container>
      </section>

      {/* Listagem de Tipos de Eventos */}
      <section className="lista-eventos-section">
        <Container>
          <Titulo titleText={'Tipo de Eventos Cadastrados'} color="white" />
          <TableTp 
            dados={listaTiposDeEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default TiposEventos;
