import { ActivityIndicator } from "react-native"
import { LoadingContainer } from "../Container/style"
import { TextRegular } from "../Text/style"

export const LoadingIndicator = () => {
    return (
        <LoadingContainer>
            <TextRegular>Carregando Informações...</TextRegular>
            <ActivityIndicator />
        </LoadingContainer>
    )
}