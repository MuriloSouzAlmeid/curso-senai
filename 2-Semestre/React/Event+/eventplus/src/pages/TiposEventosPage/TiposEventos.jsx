import React, { useState } from "react";
import "./TiposEventos.css";

//import da api
import api from '../../services/Service';

//import dos componentes
import Titulo from "../../components/Titulo/Titulo";
import MainContent from "../../components/MainContent/MainContent";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import Container from "../../components/Container/Container";

//pois não é um export default
import { Input, Button } from "../../components/FormComponents/FormComponents";

import imageTipoEvento from "../../assets/images/tipo-evento.svg";

const TiposEventos = () => {
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

      alert('Tipo de evento cadastrado com sucesso!!');
    }catch(error){
      console.log(error);
    }
  }

  async function handleUpdate(e) {
    e.preventDefault();

    if(titulo.trim().length < 3){
        alert('O título deve ter no mínimo 3 caracteres');
        return;
    }

    const retorno = await api.put(`/TiposEvento/`);
  }

  return (
    <MainContent>
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
    </MainContent>
  );
};

export default TiposEventos;
