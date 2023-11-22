import React, { useEffect, useState } from 'react';
import './EventosPage.css';

//import dos componentes
import Titulo from '../../components/Titulo/Titulo';
import MainContent from '../../components/MainContent/MainContent';
import Container from '../../components/Container/Container';
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';
import TableEv from './TableEv/TableEv';
import {Input, Button} from '../../components/FormComponents/FormComponents';

//import da API
import api from '../../services/Service';
 
//import dos assets
import EventImage from '../../assets/images/evento.svg';

//import do Spinnet e Notification
import Spinner from '../../components/Spinner/Spinner';

const EventosPage = () => {

    //states
    const [listaDeEventos, setListaDeEventos] = useState([]);
    const [mostraSpinner, setMostraSpinner] = useState(false);
    const [nome, setNome] = useState('');
    const [descricao, setDescricao] = useState('');
    const [dataEvento, setDataEvento] = useState();

    //use effect
    useEffect(
        () => {
            async function getEvents(){
                setMostraSpinner(true);

                try{
                    const retorno = await api.get('/Evento');

                    setListaDeEventos(retorno.data);

                }catch(erro){
                    console.log(erro);
                }
            }

            getEvents();

            setMostraSpinner(false);
        }
        ,[]
    )

    async function atualizarListaEventos(){
        try {
            const retorno = await api.get(`/Evento`);
            setListaDeEventos(retorno.data);
        } catch (error) {
            console.log(error);
        }
    }

    async function handleDelete(idEvento){
        try{

            const retorno = await api.delete(`/Evento/${idEvento}`)

            atualizarListaEventos();

        }catch(erro){
            console.log(erro);
        }
    }

    async function handleSubmit(){
        alert('Bora cadastrar!')
    }























    return (
        <MainContent>
            <section className="cadastro-evento-section">
                <Container>
                    <Titulo titleText="Eventos" />
                    <div className="cadastro-evento__box">
                        <ImageIllustrator
                            imageRender={EventImage}
                            alterText={'Imagem de um cara vendo uns balões'}
                        />
                        <form className="fevento" onSubmit={handleSubmit}>

                            {/* Input de Título */}
                            <Input
                                type={'text'}
                                id={'nome'}
                                value={nome}
                                required={'required'}
                                name={'nome'}
                                placeholder={'Nome'}
                                manipulationFunction={(e) => {
                                    setNome(e.target.value)
                                }}
                            />

                            {/* Input de Descrição */}
                            <Input
                                type={'text'}
                                id={'descricao'}
                                value={descricao}
                                required={'required'}
                                name={'descricao'}
                                placeholder={'Descrição'}
                                manipulationFunction={(e) => {
                                    setDescricao(e.target.value)
                                }}
                            />

                            {/* Select dos tipos de eventos */}
                            <select name="" id="">
                                <option value="">Selecione</option>
                                <option value="">1</option>
                                <option value="">2</option>
                                <option value="">3</option>
                            </select>

                            {/* Input de data do evento */}
                            <Input
                                type={'date'}
                                id={'data-evento'}
                                value={dataEvento}
                                required={'required'}
                                name={'data-evento'}
                                manipulationFunction={(e) => {
                                    setDataEvento(e.target.value)
                                }}
                            />

                            {/* Button para submit do formulário */}
                            <Button 
                                id={'cadastrar-evento'}
                                name={'cadastrar-evento'}
                                type={'submit'}
                                textButton={'Cadastrar'}
                                manipulationFunction={handleSubmit}
                            />
                        </form>
                    </div>
                </Container>
            </section>

            <section className="lista-eventos-section">
                <Container>
                    <Titulo titleText={'Lista de eventos'} color='white' />
                    <TableEv 
                        dados={listaDeEventos} 
                            fnDelete={handleDelete} />
                </Container>
            </section>


            { mostraSpinner ? <Spinner/> : null}
        </MainContent>
    );
};

export default EventosPage;