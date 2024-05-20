import styled, { css } from "styled-components";
import { InputLabel, MediumText, SemiBoldText, TextLight } from "../Text/style";
import { LinkSemiBoldCancel } from "../Link/style";

export const CardBox = styled.TouchableOpacity`
    padding: 10px;
    flex-direction: row;

    ${props => props.selecionado && css`
        border: 2px solid #496BBA;
    `}

    elevation: 5;
    gap: 10px;
    align-items: center;    
    margin: 0 auto 12px;
    width: 100%;
    border-radius: 5px;
    background-color: white;
`

export const CardSelectBox = styled(CardBox)`
    padding: 20px;
    justify-content: space-between;
    elevation: 5;
    ${props => props.selecionado && css`
        border: 2px solid #496BBA;
    `}
`

export const CardContent = styled.View`
    height: 80px;
    justify-content: space-between;
`

export const CardSelectContent = styled.View`
    justify-content: center;
    gap: 10px;
`
export const CardSelectContentEnd = styled(CardSelectContent)`
    align-items: flex-end;
`

export const DataCard = styled.View`
    gap: 4px;
`

export const ProfileData = styled.View`
    flex-direction: row;
    gap: 17px;
    /* background-color: red; */
`

export const TitleCard = styled(MediumText)`
    font-size: 16px;
`

export const TitleSelectCard = styled(SemiBoldText)`
`

export const TextAge = styled(TextLight)`
    color: #8C8A97;
`

export const TextTipoConsulta = styled(InputLabel)`
    font-size: 14px;
    color: #8C8A97;
`

export const CardSelectDescription = styled(TextTipoConsulta)`
    color: #4E4B59;
`

export const ViewRow = styled.View`
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
    width: 84%;
`

export const HorarioBox = styled.View`
    flex-direction: row;
    gap: 6px;
    border-radius: 5px;
    background-color: ${props => props.statusConsulta == "Agendada" ? `#E8FCFD` : `#F1F0F5`};
    padding: 4px;
    align-items: center;
    justify-content: center;
    width: 100px;
`

export const HorarioText = styled(TextTipoConsulta)`
    color: ${props => props.statusConsulta == "Agendada" ? `#49B3BA` : `#4E4B59`};

`

export const CardTextCancelApointment = styled(LinkSemiBoldCancel)`
    text-decoration: none;
    color: ${props => props.statusConsulta == "Agendada" ? "#C81D25" : "#344F8F"};
    margin-top: -0px;
`

export const AvaliacaoClinicaBox = styled.View`
    flex-direction: row;
    gap: 2px;
`

export const NotaAvaliacao = styled(TextTipoConsulta)`
    color: #F9A620;
`

export const HorarioClinicaBox = styled(HorarioBox)`
    padding: 6px;
    background-color: #E8FCFD;
    gap: 5px;
    width: 100px;
`

export const DisponibilidadeClinicaText = styled(HorarioText)`
    color: #49B3BA;
`