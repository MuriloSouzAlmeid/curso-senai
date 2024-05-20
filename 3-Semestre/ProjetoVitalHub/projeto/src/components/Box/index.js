import { ButtonModal } from "../Button/styled";
import { Input, InputSelect } from "../Input";
import { InputField, PerfilInputField } from "../Input/style";
import { LinkCancel } from "../Link";
import { ButtonTitle, InputLabel } from "../Text/style";
import { InputContentBox } from "./style";

export const BoxInputField = ({
    labelText, placeholderText, fieldWidth = "100",
    keyType = "default", onChangeText = null, maxLength, fieldValue = null, editable = false, fieldHeight = "20", apointment = false, inputPerfil, center = false, multiline = true
}) =>
    <InputContentBox fieldWidth={fieldWidth}>
        <InputLabel>{labelText}</InputLabel>

        <Input
            multiline={multiline}
            placeholderText={placeholderText}
            keyType={keyType}
            maxLength={maxLength}
            onChangeText={onChangeText}
            fieldvalue={fieldValue}
            inputPerfil={inputPerfil}
            editable={editable}
            fieldHeight={fieldHeight}
            apointment={apointment}
            center={center}
        />
    </InputContentBox>

export const ButtonContinuarBox = ({enable, manipulationFunction = null, openModalFunction = null, functionCancel = null, buttonText = "Continuar"}) => 
    <>
        <ButtonModal disable={!enable}  onPress={manipulationFunction}>
            <ButtonTitle>{buttonText}</ButtonTitle>
        </ButtonModal>

        <LinkCancel onPress={functionCancel}>Cancelar</LinkCancel>
    </>

export const BoxInputSelect = ({labelText, selecionarHora}) => {
    return(
        <InputContentBox
            fieldWidth={"90"}
        >
            <InputLabel>{labelText}</InputLabel>
            <InputSelect
                selecionarHora={selecionarHora}
            />
        </InputContentBox>
    )
}