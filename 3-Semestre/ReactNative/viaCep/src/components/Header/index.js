import { HeaderContainer, HeaderContent, TextHeader } from "./style"
import {StyleSheet} from "react-native"

export const Header = () => {
    return (
        // container
        <HeaderContainer style={styles.container}>
            {/* SafeAreaView */}
            <HeaderContent>
                {/* Text */}
                <TextHeader>Consumo da API BrasilAberto</TextHeader>
            </HeaderContent>
        </HeaderContainer>
    )
}

const styles = StyleSheet.create({
    container: {
        shadowColor: 'black',
        shadowOpacity: 0.2,
        shadowOffset: {
            width: 2, 
            height: -4
        },
        shadowRadius: 1,
        elevation: 20,
    }
})