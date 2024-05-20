import { ButtonSemiBoldTitle, ButtonSemiBoldTitleLight } from "../Text/style"
import { Button, ButtonLight } from "./styled"

export const ButtonHome = ({ widthValue = 30, actived, buttonText, manipulationFunction, situacao
}) => {
    return (
        actived ? <Button
            onPress={() => manipulationFunction(situacao)}
            width={widthValue}>
            <ButtonSemiBoldTitle>{buttonText}</ButtonSemiBoldTitle>
        </Button>
            : <ButtonLight
                onPress={() => manipulationFunction(situacao)}
                width={widthValue}>
                <ButtonSemiBoldTitleLight>{buttonText}</ButtonSemiBoldTitleLight>
            </ButtonLight>
    )
}

export const ButtonModalConsulta = ({ widthValue = 30, actived, buttonText, manipulationFunction = null, situacao, manipularAgendamento = null, idPrioridade = "", labelPrioridade = "" }) => {
    return (
        actived ? <Button
            onPress={() => {
                manipulationFunction(situacao)
                if(manipularAgendamento !== null){
                    manipularAgendamento(idPrioridade, labelPrioridade)
                }
            }}
            width={widthValue}
            modal
        >
            <ButtonSemiBoldTitle>{buttonText}</ButtonSemiBoldTitle>
        </Button>
            : <ButtonLight
                onPress={() => {
                    manipulationFunction(situacao)
                    if(manipularAgendamento !== null){
                        manipularAgendamento(idPrioridade, labelPrioridade)
                    }
                }}
                width={widthValue}
                modal
            >
                <ButtonSemiBoldTitleLight modal>{buttonText}</ButtonSemiBoldTitleLight>
            </ButtonLight>
    )
}