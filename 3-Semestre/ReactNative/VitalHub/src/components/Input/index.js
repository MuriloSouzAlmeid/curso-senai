import { InputField } from "./style";

export const Input = ({
    placeholderText, keyType = "default", onChangeText = null, maxLenght, fieldvalue = null
}) =>
    <InputField
        placeholder={placeholderText}
        keyboardType={keyType}
        onChangeText={onChangeText}
        maxLenght={maxLenght}
        value={fieldvalue}
    />


