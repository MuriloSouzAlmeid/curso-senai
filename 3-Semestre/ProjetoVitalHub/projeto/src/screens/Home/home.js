import { Header } from "../../components/Header";
import { Calendario } from "../../components/Calendario";
import { ContainerApp, ContainerHome } from "../../components/Container/style";
import { BoxButtonRow } from "../../components/Box/style";
import { FontAwesome } from '@expo/vector-icons';
import { ButtonHome } from "../../components/Button";
import { useCallback, useEffect, useState } from "react";
import { ListaConsultas } from "../../components/FlatList";
import { AgendarConsultaModal, ApointmentModal, CancelattionModal, ConsultaModalCard } from "../../components/Modal";
import { AgendarConsultaButton, HomeContent } from "./style";
import { LoadProfile } from "../../utils/Auth";
import moment from "moment";
import { TextRegular } from "../../components/Text/style";
import { api } from "../../services/service";
import { LoadingIndicator } from "../../components/LoadingIndicator";
import { useFocusEffect } from "@react-navigation/native";

export const Home = ({ navigation, route }) => {
    const { ativado } = route.params

    //state para o estado da lista
    const [statusFiltro, setStatusFiltro] = useState("Agendada")

    //state para guardar as informações do token
    const [infoUsuario, setInfoUsuario] = useState(null)

    //state para a exibição dos modais
    const [showModalCancel, setShowModalCancel] = useState(false)
    const [showModalApointment, setShowModalApointment] = useState(false)
    const [showModalConsulta, setShowModalConsulta] = useState(false)

    //state para a exibição dos modais
    const [showModalAgendarConsulta, setShowAgendarConsulta] = useState(false)

    //state para guardar os dados da consulta e renderizar no modal
    const [infoConsulta, setInfoConsulta] = useState(null)

    //state para armazenar a data seleciondada no calendário
    const [dataAtual, setDataAtual] = useState(moment().format("YYYY-MM-DD"));

    const [listaDeConsultas, setListaDeConsultas] = useState([])

    const [apointmentButton, setApointmentButton] = useState(true)

    const CarregarDadosUsuario = () => {
        LoadProfile()
            .then(token => {
                if (token !== null) {
                    setInfoUsuario(token)
                    setDataAtual(moment().format("YYYY-MM-DD"))
                    ListarConsultasUsuario(token.perfil, token.idUsuario)
                    BuscarImagemUsuario(token.idUsuario)
                }
            }
            )
    }

    useEffect(() => {
        if (ativado === true) {
            setShowAgendarConsulta(true)
        }
    }, [])

    const ListarConsultasUsuario = async (perfil, id) => {
        await api.get(`/${perfil}s/BuscarPorData?data=${dataAtual}&id=${id}`)
            .then(retornoApi => {
                retornoApi.data.map(async (consulta) => {
                    if (consulta.situacao.situacao === "Agendada" && moment(consulta.dataConsulta, "YYYY-MM-DD HH:mm").date() > moment().date()) {
                        await api.put(`/Consultas/Status?idConsulta=${consulta.id}&status=Realizada`)
                            .then(() => {
                                setShowModalCancel(false)
                            }).catch(error => {
                                console.log(`Erro ao atualizar status das consultas. Erro: ${error}`)
                            })
                    }

                    await api.get(`/${perfil}s/BuscarPorData?data=${dataAtual}&id=${id}`).then(retornoApi => {
                        setListaDeConsultas(retornoApi.data)
                    }).catch(error => {
                        console.log(error);
                    })
                });

            }).catch(erro => {
                console.log(erro);
            })
    }

    useEffect(() => {
        CarregarDadosUsuario()
    }, [])

    useEffect(() => {
        if (infoUsuario !== null) {
            ListarConsultasUsuario(infoUsuario.perfil, infoUsuario.idUsuario)
        }
    }, [dataAtual, 1000])


    const [fotoUsuario, setFotoUsuario] = useState("")

    const BuscarImagemUsuario = async (idUsuario) => {
        await api.get(`/Usuario/BuscarPorId?id=${idUsuario}`)
            .then(retornoApi => {
                setFotoUsuario(retornoApi.data.foto)
            }).catch(error => {
                alert(error)
            })
    }

    //Recarrega a imagem no Header
    useFocusEffect(
        useCallback(() => {
            CarregarDadosUsuario()
        }, [])
    )

    return (
        <ContainerHome>
            {infoUsuario !== null ?
                <Header
                    nomeUsuario={infoUsuario.nome}
                    fotoUsuario={fotoUsuario}
                /> : null}
            <Calendario
                setDataAtual={setDataAtual}
            />
            <HomeContent>
                <BoxButtonRow>
                    <ButtonHome
                        buttonText={"Agendadas"}
                        situacao={"Agendada"}
                        actived={statusFiltro === "Agendada"}
                        manipulationFunction={setStatusFiltro}
                    />
                    <ButtonHome
                        buttonText={"Realizadas"}
                        situacao={"Realizada"}
                        actived={statusFiltro === "Realizada"}
                        manipulationFunction={setStatusFiltro}
                    />
                    <ButtonHome
                        buttonText={"Canceladas"}
                        situacao={"Cancelada"}
                        actived={statusFiltro === "Cancelada"}
                        manipulationFunction={setStatusFiltro}
                    />
                </BoxButtonRow>
                {listaDeConsultas.length > 0 ?
                    <ListaConsultas
                        dados={listaDeConsultas}
                        statusConsulta={statusFiltro}
                        onPressCancel={() => setShowModalCancel(true)}
                        onPressApointment={() => setShowModalApointment(true)}
                        onPressConsulta={() => setShowModalConsulta(true)}
                        loadInfoConsulta={setInfoConsulta}
                        perfilUsuario={infoUsuario.perfil}
                        navigation={navigation}
                    />
                    : null
                }
            </HomeContent>


            {/* Modal Cancelar */}

            {infoConsulta !== null && infoUsuario !== null ?
                <>
                    <CancelattionModal
                        setShowModalCancel={setShowModalCancel}
                        visible={showModalCancel}
                        ListarConsultas={() => ListarConsultasUsuario(infoUsuario.perfil, infoUsuario.idUsuario)}
                        infoConsulta={infoConsulta}
                    />


                    {/* Modal Prontuário */}

                    <ApointmentModal
                        idUsuario={infoUsuario.perfil === "Paciente" ? infoConsulta.medicoClinica.medico.idNavigation.id : infoConsulta.paciente.idNavigation.id}
                        setShowModalApointment={setShowModalApointment}
                        visible={showModalApointment}
                        informacoes={infoConsulta}
                        navigation={navigation}
                    />

                    {/* Modal de Consulta no Card */}

                    <ConsultaModalCard
                        visible={showModalConsulta}
                        setShowModal={setShowModalConsulta}
                        navigation={navigation}
                        consulta={infoConsulta}
                        perfilUsuario={infoUsuario.perfil}
                    />




                </>
                : null}

            {/* Botão para agendar consulta */}
            {(infoUsuario !== null && infoUsuario.perfil === "Paciente") ?
                <AgendarConsultaButton onPress={() => setShowAgendarConsulta(true)}>
                    <FontAwesome name="stethoscope" size={32} color="white" />
                </AgendarConsultaButton>
                : null
            }

            {/* Modal de Agendar Consulta */}
            <AgendarConsultaModal
                visible={showModalAgendarConsulta}
                setShowModal={setShowAgendarConsulta}
                navigation={navigation}
            />

        </ContainerHome>
    )
}