import { ApointmentInputField, InputField, InputVirifyEmail, PerfilInputField } from "./style";

import RNPickerSelect from "react-native-picker-select";
import { ActivityIndicator, StyleSheet, View } from "react-native";

import { FontAwesomeIcon } from '@fortawesome/react-native-fontawesome'
import { faCaretDown } from '@fortawesome/free-solid-svg-icons'
import React, { useEffect, useState } from "react";
import moment from "moment";

export const Input = ({
    placeholderText, keyType = "default", onChangeText = null, maxLength, fieldvalue = null, verifyEmail = false, inputPerfil = false, editable = false, fieldHeight = "16", apointment = false, center = false, multiline = true, secure = false, inputWidth = "100", error = false, onFocus = null, onBlur = null
}) => {
    if (verifyEmail) {
        return (
            <InputVirifyEmail
                onFocus={onFocus}
                onBlur={onBlur}
                error={error}
                inputWidth={inputWidth}
                secureTextEntry={secure}
                multiline={multiline}
                placeholder={placeholderText}
                keyboardType="numeric"
                onChangeText={onChangeText}
                maxLength={maxLength}
                value={fieldvalue}
                editable={editable}
            />
        )
    } else if (inputPerfil) {
        return (
            <PerfilInputField
                inputWidth={inputWidth}
                secureTextEntry={secure}
                multiline={multiline}
                placeholder={placeholderText}
                keyboardType={keyType}
                onChangeText={onChangeText}
                maxLength={maxLength}
                value={fieldvalue}
                editable={editable}
                fieldHeight={fieldHeight}
            />
        )
    } else if (apointment) {
        return (
            <ApointmentInputField
                inputWidth={inputWidth}
                secureTextEntry={secure}
                multiline={multiline}
                placeholder={placeholderText}
                keyboardType={keyType}
                onChangeText={onChangeText}
                maxLength={maxLength}
                value={fieldvalue}
                editable={editable}
                fieldHeight={fieldHeight}
                center={center}
            />
        )
    } else {
        return (
            <InputField
                error={error}
                inputWidth={inputWidth}
                secureTextEntry={secure}
                multiline={multiline}
                placeholder={placeholderText}
                keyboardType={keyType}
                onChangeText={onChangeText}
                maxLength={maxLength}
                value={fieldvalue}
                editable={editable}
                center={center} 
            />
        )
    }

}

export const VerificarEmaiInput = React.forwardRef(({ placeholderText, keyType = "default", onChangeText = null, maxLength, fieldvalue = null, inputPerfil = false, editable = false, fieldHeight = "16", apointment = false, center = false, multiline = true, secure = false }, ref) => {
    return (
        <InputVirifyEmail
            ref={ref}
            secureTextEntry={secure}
            multiline={multiline}
            placeholder={placeholderText}
            keyboardType={keyType}
            onChangeText={onChangeText}
            maxLength={maxLength}
            value={fieldvalue}
            editable={editable}
        />
    )
});

export const InputSelect = ({ selecionarHora }) => {
    const dataAtual = moment().format("YYYY-MM-DD")
    const [arrayOptions, setArrayOptions] = useState(null)

    const LoadOptions = async () => {
        // Capturar a quantidade que faltam para 24hrs
        const horasRestantes = moment(dataAtual).add(24, 'hours').diff(moment(), "hours");
        console.log(horasRestantes);

        // Criar um laço que rode a quantidade de horas
        const options = Array.from({ length: horasRestantes }, (_, index) => {

            // pra cada hora será uma nova option

            let valor = new Date().getHours() + (index + 1)

            return {
                label: `${valor}:00`, value: `${valor}:00`
            }
        })

        setArrayOptions(options);

    }

    useEffect(() => {
        LoadOptions()
    }, [])

    return (
        <View style={{ width: 316, borderWidth: 2, marginBottom: 75, borderStyle: "solid", borderColor: "#34898F", borderRadius: 5 }}>
            {arrayOptions ?
                <RNPickerSelect
                    style={style}
                    Icon={() => {
                        return <FontAwesomeIcon style={{ marginLeft: "1%" }} icon={faCaretDown} color='#34898F' size={22} />
                    }}
                    placeholder={{
                        label: 'Selecione um valor',
                        value: null,
                        color: '#34898F'
                    }}
                    onValueChange={(value) => selecionarHora(value)}
                    items={arrayOptions}
                />
                : <ActivityIndicator />}
        </View>
    )
}

const style = StyleSheet.create({
    inputIOS: {
        fontSize: 16,
        padding: 16,
        borderWidth: 2,
        borderColor: '#60BFC5',
        borderRadius: 5,
        color: '#34898F',
        alignContent: 'center',
        alignItems: 'center',
        justifyContent: 'center',
        fontFamily: 'MontserratAlternates_600SemiBold'
    },
    inputAndroid: {
        fontSize: 16,
        padding: 16,
        borderWidth: 2,
        borderColor: '#60BFC5',
        borderRadius: 5,
        color: '#34898F',
        alignItems: 'center',
        justifyContent: 'center',

        fontFamily: 'MontserratAlternates_600SemiBold'
    },
    iconContainer: {
        top: '25%',
        marginRight: 10
    },
    placeholder: {
        color: '#34898F',
    }
})