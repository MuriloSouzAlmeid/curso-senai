import React from 'react';
import './HomePage.css';

//import dos componentes
import MainContent from '../../components/MainContent/MainContent';
import Banner from '../../components/Banner/Banner';
import Titulo from '../../components/Titulo/Titulo';
import VisionSection from '../../components/VisionSection/VisionSection';

const HomePage = () => {
    return (
        //quando tem componentes dentro de um outro componente usamos um elemento duplo (com abertura e fechamento)
        <MainContent>
            <Banner/>
            <Titulo titleText={'Página Home'} />
            <VisionSection/>
        </MainContent>
    );
};

export default HomePage;