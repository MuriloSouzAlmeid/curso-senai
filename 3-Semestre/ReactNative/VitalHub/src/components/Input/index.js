import { InputField } from "./style";

export const Input = ({
    placeholderText, keyType = "default", onChangeText = null, maxLenght, fieldvalue = null
}) =>
    <InputField
        placeholderTextColor={"#34898F"}
        placeholder={placeholderText}
        keyboardType={keyType}
        onChangeText={onChangeText}
        maxLenght={maxLenght}
        value={fieldvalue}
    />


