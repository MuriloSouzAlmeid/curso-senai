import { CancelText, CardBox, CardContent, CardTextCancelApointment, DataCard, HorarioBox, HorarioText, TitleCard, ProfileData, TextAge, TextTipoConsulta, ViewRow, TitleSelectCard, CardSelectBox, CardSelectContent, CardSelectDescription, CardSelectContentEnd, AvaliacaoClinicaBox, NotaAvaliacao, HorarioClinicaBox, DisponibilidadeClinicaText } from "./style";
import { AntDesign } from '@expo/vector-icons';
import { MaterialCommunityIcons } from '@expo/vector-icons';
import { UserImageCart } from "../UserImage/styled";
import { useEffect, useState } from "react";
import { GerarNotaClinica } from "../../utils/funcoesUteis";
import { LoadProfile } from "../../utils/Auth";
import moment from "moment";

export const CardConsulta = ({idUsuario, navigation, perfil, consulta, statusConsulta, onPressCancel, onPressApointment, loadInfoConsulta, onPressConsulta, imageSource }) => {
    const [idadePaciente, setIdadePaciente] = useState(null)
    const [prioridadeConsulta, setPrioridadeConsulta] = useState("")

    const AbrirModal = modal => {
        loadInfoConsulta(consulta)

        switch (modal) {
            case "localConsulta":
                onPressConsulta()
                break;
        
            case "prontuario":
                onPressApointment()
                break;

            case "cancelar":
                onPressCancel()
                break;
            
            default:
                alert("Erro ao abrir o modal");
        }
    }

    useEffect(() => {
        if(perfil === "Medico"){
            setIdadePaciente(moment.duration(moment().diff(moment(consulta.paciente.dataNascimento))).asYears());
        }

        switch (consulta.prioridade.prioridade) {
            case 1:
                setPrioridadeConsulta("Rotina")
                break;
        
            case 2:
                setPrioridadeConsulta("Exame")
                break;

            case 3:
                setPrioridadeConsulta("Urgência")
                break;

            default:
                setPrioridadeConsulta("Erro ao carregar prioridade de exame")
                break;
        }

    }, [])

    return (
        <CardBox onPress={statusConsulta !== "Cancelada" ? ( perfil === "Paciente" ? () => AbrirModal("localConsulta") : () => AbrirModal("prontuario")) : null}>
            <UserImageCart
                source={{uri: imageSource}}
            />
            <CardContent>
                <DataCard>
                    <TitleCard>
                        {perfil === "Paciente" ? consulta.medicoClinica.medico.idNavigation.nome 
                            : consulta.paciente.idNavigation.nome }
                    </TitleCard>
                    <ProfileData>
                    {perfil === "Paciente" ?
                        <TextAge>{consulta.medicoClinica.medico.crm}</TextAge> : 
                        <TextAge>{Math.round(idadePaciente)} anos</TextAge>
                    }
                        <TextTipoConsulta>{prioridadeConsulta}</TextTipoConsulta>
                    </ProfileData>
                </DataCard>
                <ViewRow>
                    <HorarioBox statusConsulta={statusConsulta}>
                        <AntDesign name="clockcircle" size={14} color={statusConsulta == "Agendada" ? "#49B3BA" : "#4E4B59"} />
                        <HorarioText statusConsulta={statusConsulta}>{moment(consulta.dataConsulta).format("HH:mm")}</HorarioText>
                    </HorarioBox>
                    <CardTextCancelApointment
                        statusConsulta={statusConsulta}
                        onPress={statusConsulta == "Agendada" ? (() => AbrirModal("cancelar")) : (() => navigation.replace("PaginaDeProntuario", { consulta: consulta, idUsuario: idUsuario }))}
                    >
                        {statusConsulta == "Agendada" ? "Cancelar" : (statusConsulta == "Realizada" ? "Ver Prontuário" : null)}
                    </CardTextCancelApointment>
                </ViewRow>
            </CardContent>
        </CardBox>
    )
}

export const CardClinica = ({ dados, selecionarClinica = null, selecionada = false }) => {
    return (
        <CardSelectBox
            selecionado={selecionada}
            onPress={() => {
                selecionarClinica({
                    clinicaId: dados.id,
                    nomeFantasia: dados.nomeFantasia
                })
            }}
        >
            <CardSelectContent>
                <TitleSelectCard>{dados.nomeFantasia}</TitleSelectCard>
                <CardSelectDescription>{dados.endereco.cidade}</CardSelectDescription>
            </CardSelectContent>
            <CardSelectContentEnd>
                <AvaliacaoClinicaBox>
                    <AntDesign name="star" size={20} color="#F9A620" />
                    <NotaAvaliacao>{GerarNotaClinica()}</NotaAvaliacao>
                </AvaliacaoClinicaBox>
                <HorarioClinicaBox>
                    <MaterialCommunityIcons name="calendar" size={14} color="#49B3BA" />
                    <DisponibilidadeClinicaText>Seg-Sex</DisponibilidadeClinicaText>
                </HorarioClinicaBox>
            </CardSelectContentEnd>
        </CardSelectBox>
    )
}

export const CardMedico = ({ dados, selecionarMedico = null, selecionado = false }) => {
    return (
        <CardBox
            selecionado={selecionado}
            onPress={() => 
                selecionarMedico({
                    medicoId: dados.idNavigation.id,
                    medicoClinicaId: dados.id,
                    medicoNome: dados.idNavigation.nome,
                    medicoEspecialidade: dados.especialidade.especialidade1
                })
            }
            
        >
            <UserImageCart
                source={{uri: dados.idNavigation.foto}}
            />
            <CardSelectContent>
                <TitleSelectCard>{dados.idNavigation.nome}</TitleSelectCard>
                <CardSelectDescription>{dados.especialidade.especialidade1}</CardSelectDescription>
            </CardSelectContent>
        </CardBox>
    )
}