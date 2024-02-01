import { InputForm } from "./style"

export const Input = ({
    editable = false, placeholder, fieldValue = null, onChangeText = null, keyType = 'default', maxLenght
}) =>{
    return(
        <InputForm  
            placeholder={placeholder}
            editable={editable}
            keyboardType={keyType}
            value={fieldValue}
            onChangeText={onChangeText}
            maxLength={maxLenght}
        />
    )
}