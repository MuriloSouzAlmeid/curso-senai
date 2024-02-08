import { InputField, InputVirifyEmail } from "./style";

export const Input = ({
    placeholderText, keyType = "default", onChangeText = null, maxLength, fieldvalue = null,
    fieldWidth = "100", verifyEmail = false
}) => {
    if (verifyEmail) {
        return (
            <InputVirifyEmail
                placeholder={placeholderText}
                keyboardType={keyType}
                onChangeText={onChangeText}
                maxLength={maxLength}
                value={fieldvalue}
                fieldWidth={fieldWidth}
            />
        )
    } else {
        return (
            <InputField
                placeholder={placeholderText}
                keyboardType={keyType}
                onChangeText={onChangeText}
                maxLength={maxLength}
                value={fieldvalue}
                fieldWidth={fieldWidth}
            />
        )
    }

}