import { Ionicons } from '@expo/vector-icons';
import { ContainerHeader } from '../Container/style';
import { HeaderContent, TextHeaderBox, WelcomeView } from './style';
import { UserImageHeader } from '../UserImage/styled';
import { UserNameTextHeader, WelcomeText } from '../Text/style';
import { LinearGradient } from 'expo-linear-gradient';

export const Header = () => {
    return (
        <ContainerHeader>

            <HeaderContent>
                <WelcomeView>
                    <UserImageHeader
                        source={require("../../assets/images/foto-murilo.jpg")}
                    />
                    <TextHeaderBox>
                        <WelcomeText>Bem Vindo</WelcomeText>
                        <UserNameTextHeader>Murilo Souza</UserNameTextHeader>
                    </TextHeaderBox>
                </WelcomeView>
                <Ionicons name="notifications" size={25} color="white" />
            </HeaderContent>

        </ContainerHeader>
    )
}