import React, { useEffect, useState } from "react";
import axios from "axios";
import "./HomePage.css";

//import dos componentes
import MainContent from "../../components/MainContent/MainContent";
import Banner from "../../components/Banner/Banner";
import Titulo from "../../components/Titulo/Titulo";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "../../components/ContactSection/ContactSection";
import NextEvent from "../../components/NextEvent/NextEvent";
import Container from "../../components/Container/Container";

const HomePage = () => {
  //chamar a api na hora que carregar a página
  //usamos o useEffect, ele sempre roda uma primeira vez mesmo não tendo alterado a variável
  useEffect(
    //função que será executada quando o useEffect for chamado (irá chamar a api)
    async function getProximosEventos () {
      try{
        const promisse = await axios.get('http://localhost:5000/api/Evento/ListarProximos');

        setNextEvents(promisse.data); //o data acessa os dados no objeto json
      }catch(error){
        console.log(error);
      }
      getProximosEventos();
    }
    , 
    [] //array de dependências para indicar quando o comando será executado (vazia roda uma vez só quando a página for carregada)
    //podemos colocar várias variáveis como dependência e quando qualquer uma delas for alterada o useEffect é executado
  );

  //fake mock - api mocada
  const [nextEvents, setNextEvents] = useState([
    {
      id: 1,
      title: "Evento A",
      date: "12/11/2023",
      description: "Evento legal sobre assunto A",
    },
    {
      id: 2,
      title: "Evento B",
      date: "25/12/2023",
      description: "Evento legal sobre assunto B",
    },
    {
      id: 3,
      title: "Evento C",
      date: "01/01/2024",
      description: "Evento legal sobre assunto C",
    },
  ]);

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
                  title={e.title}
                  description={e.description}
                  eventDate={e.date}
                  idEvento={e.id}
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
