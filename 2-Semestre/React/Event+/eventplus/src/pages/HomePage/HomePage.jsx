import React, { useContext, useEffect, useState } from "react";
import api from '../../services/Service';
import { Swiper, SwiperSlide } from 'swiper/react';
import "./HomePage.css";

//import dos componentes
import MainContent from "../../components/MainContent/MainContent";
import Banner from "../../components/Banner/Banner";
import Titulo from "../../components/Titulo/Titulo";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "../../components/ContactSection/ContactSection";
import NextEvent from "../../components/NextEvent/NextEvent";
import Container from "../../components/Container/Container";
import { ActivatedPage } from "../../context/ActivatedPage";

const HomePage = () => {
  const {setActivatedPage} = useContext(ActivatedPage)
  //chamar a api na hora que carregar a página
  //usamos o useEffect, ele sempre roda uma primeira vez mesmo não tendo alterado a variável
  useEffect( () => {
    setActivatedPage('home')
    //função que será executada quando o useEffect for chamado (irá chamar a api)
    async function getProximosEventos () {
      try{
        const promisse = await api.get('/Evento/ListarProximos');

        setNextEvents(promisse.data); //o data acessa os dados no objeto json
      }catch(error){
        console.log('Deu ruim na API');
      }
    }
    getProximosEventos();
  }, 
    [] //array de dependências para indicar quando o comando será executado (vazia roda uma vez só quando a página for carregada)
    //podemos colocar várias variáveis como dependência e quando qualquer uma delas for alterada o useEffect é executado
  );

  //fake mock - api mocada
  const [nextEvents, setNextEvents] = useState([]);

  return (
    //quando tem componentes dentro de um outro componente usamos um elemento duplo (com abertura e fechamento)
    <MainContent>
      <Banner />

      {/* PRÓXIMOS EVENTOS */}
      <section className="proximos-eventos">
        <Container>
          <Titulo titleText={"Próximos Eventos"} />

          <div className="events-box">
            {nextEvents.map((e) => {
              return (
                <NextEvent
                  title={e.nomeEvento}
                  description={e.descricao}
                  eventDate={e.dataEvento}
                  idEvento={e.idEvento}
                />
              );
            })}
          </div>
        </Container>
      </section>

      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
