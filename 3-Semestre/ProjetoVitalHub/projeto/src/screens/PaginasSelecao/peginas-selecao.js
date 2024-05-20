import { useEffect, useState } from "react";
import { BoxInputSelect, ButtonContinuarBox } from "../../components/Box";
import { CalendarioCompleto } from "../../components/Calendario";
import { ListaClinicas, ListaMedicos } from "../../components/FlatList";
import { InputSelect } from "../../components/Input";
import { ConfirmarConsultaModal } from "../../components/Modal";
import { ContainerSelectPage, TitleSelecao } from "./style";
import { api } from "../../services/service";
import { GerarNotaClinica, ObjetoEstaVazio } from "../../utils/funcoesUteis";

export const SelecionarClinica = ({ navigation, route }) => {
    const [clinicaSelecionada, setClinicaSelecionada] = useState({});
    const [lsitaDeClinicas, setListaDeClinicas] = useState([])

    const [enableButton, setEnableButton] = useState(false)

    useEffect(() => {
        if(!ObjetoEstaVazio(clinicaSelecionada)){
            setEnableButton(true)
        }
    }, [clinicaSelecionada])

    const BuscarClinicas = async (localizacao) => {
        await api.get(`/Clinica/BuscarPorCidade?cidade=${localizacao}`)
            .then(retornoApi => {
                setListaDeClinicas(retornoApi.data)
            })
    }

    const NavegarParaPaginaMedico = () => {
        navigation.replace("SelecionarMedico", { agendamento: { ...clinicaSelecionada, ...route.params.agendamento } })
        
    }

    useEffect(() => {
        console.log(route.params.agendamento);
        BuscarClinicas(route.params.agendamento.localizacao)
    }, [route.params])

    return (
        <ContainerSelectPage>
            <TitleSelecao>Selecionar Clínica</TitleSelecao>
            {(lsitaDeClinicas.length > 0) ?
                <ListaClinicas
                    dados={lsitaDeClinicas}
                    selecionarClinica={setClinicaSelecionada}
                    clinicaSelecionada={clinicaSelecionada}
                />
                : null
            }
            <ButtonContinuarBox
                enable={enableButton}
                manipulationFunction={enableButton ? NavegarParaPaginaMedico : null}
                functionCancel={() => navigation.replace("Main", { ativado: true })}
            />
        </ContainerSelectPage>
    )
}

export const SelecionarMedico = ({ navigation, route }) => {
    const [medicoSelecionado, setMedicoSelecionado] = useState({});
    const [listaDeMedicos, setListaDeMedicos] = useState([])

    const [enableButton, setEnableButton] = useState(false)

    const BuscarMedicos = async (id) => {
        await api.get(`/Medicos/BuscarPorIdClinica?id=${id}`)
            .then(retornoApi => {
                setListaDeMedicos(retornoApi.data)
            })
            .catch(erro => {
                alert(erro)
            })
    }

    const NavegarParaSelecaoDeData = () => {
        navigation.navigate("SelecionarData", { agendamento: { ...medicoSelecionado, ...route.params.agendamento } })
     
    }

    useEffect(() => {
        BuscarMedicos(route.params.agendamento.clinicaId)
    }, [route.params])

    useEffect(() => {
        if(!ObjetoEstaVazio(medicoSelecionado)){
            setEnableButton(true)
        }
    }, [medicoSelecionado])

    return (
        <ContainerSelectPage>
            <TitleSelecao>Selecionar Médico</TitleSelecao>
            {/* <ListaSelectPages
            
            /> */}
            {(listaDeMedicos.length > 0) ?
                <ListaMedicos
                    dados={listaDeMedicos}
                    selecionarMedico={setMedicoSelecionado}
                    medicoSelecionado={medicoSelecionado}
                />
                : null
            }
            <ButtonContinuarBox
                enable={enableButton}
                manipulationFunction={enableButton ? () => NavegarParaSelecaoDeData() : null}
                functionCancel={() => navigation.replace("SelecionarClinica", {agendamento: {...route.params.agendamento}})}
            />
        </ContainerSelectPage>
    )
}

export const SelecionarData = ({ navigation, route }) => {
    const [showModalConfirmarConsulta, setShowModalConfirmarConsulta] = useState(false)
    const [enableButton, setEnableButton] = useState(false)

    const [agendamento, setAgendamento] = useState({
        dataConsulta: ""
    });
    const [dataSelecionada, setDataSelecionada] = useState("");
    const [horaSelecionada, setHoraSelecionada] = useState("");

    const HandleContinue = () => {
        setAgendamento({
            ...route.params.agendamento,
            dataConsulta: `${dataSelecionada} ${horaSelecionada}`
        })

        setShowModalConfirmarConsulta(true)
    }

    useEffect(() => {
        if(dataSelecionada !== "" && horaSelecionada !== ""){
            setEnableButton(true)
        }
    }, [dataSelecionada, horaSelecionada])

    useEffect(() => {
        setAgendamento({...route.params.agendamento})
    }, [])

    return (
        <ContainerSelectPage>
            <TitleSelecao>Selecionar Data</TitleSelecao>
            <CalendarioCompleto
                selecionarData={setDataSelecionada}
                dataSelecionada={dataSelecionada}
            />
            <BoxInputSelect
                labelText={"Selecione um horário disponível:"}
                selecionarHora={setHoraSelecionada}
            />
            <ButtonContinuarBox
                enable={enableButton}
                manipulationFunction={enableButton ? () => HandleContinue() : null}
                functionCancel={() => navigation.replace("SelecionarMedico", {agendamento: {...agendamento}})}
            />

            {agendamento.dataConsulta !== "" ?
                <ConfirmarConsultaModal
                    navigation={navigation}
                    visible={showModalConfirmarConsulta}
                    setShowModal={setShowModalConfirmarConsulta}
                    agendamento={agendamento}
                />
                : null}

        </ContainerSelectPage>
    )
}