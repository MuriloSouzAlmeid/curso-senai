import React from "react";
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
  return (
    //quando tem componentes dentro de um outro componente usamos um elemento duplo (com abertura e fechamento)
    <MainContent>
      <Banner />

      {/* PRÓXIMOS EVENTOS */}

      <section className="proximos-eventos">
        <Container>
          <Titulo titleText={"Próximos Eventos"} />

          <div className="events-box">
            <NextEvent
              title={"Título Card"}
              description={"Descrição"}
              eventDate={"12/11/2005"}
              idEvento={12345}
            />
            <NextEvent
              title={"Título Card"}
              description={"Descrição"}
              eventDate={"12/11/2005"}
              idEvento={54321}
            />
            <NextEvent
              title={"Título Card"}
              description={"Descrição ighljgkhjvhjvh"}
              eventDate={"12/11/2005"}
              idEvento={67890}
            />
          </div>
        </Container>
      </section>

      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
