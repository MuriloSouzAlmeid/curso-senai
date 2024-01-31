import { HeaderContainer, HeaderContent, TextHeader } from "./style"

export const Header = () => {
    return (
        // container
        <HeaderContainer>
            {/* SafeAreaView */}
            <HeaderContent>
                {/* Text */}
                <TextHeader>Consumo da API ViaCep</TextHeader>
            </HeaderContent>
        </HeaderContainer>
    )
}