import { useFonts } from 'expo-font';
import { MontserratAlternates_600SemiBold } from '@expo-google-fonts/montserrat-alternates';;
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import { NavigationContainer } from '@react-navigation/native';
import { Navegacao } from './src/screens/Navegacao/navegacao';
import { Login } from './src/screens/Login/login';

//instância de um objeto da classe Native Stack Navigator para acessar seus métodos
const Stack = createNativeStackNavigator();

export default function App() {
  const [fontsLoaded, fontsError] = useFonts({
    MontserratAlternates_600SemiBold
  })

  if (!fontsLoaded || fontsError) {
    return;
  }

  return (
    //Container de Navegação - envolve toda a estrutura de navegação
      <NavigationContainer>
        {/* Navigator - componente que realiza a navegação */}
        <Stack.Navigator>
          {/* Telas - a tela a ser carregada
                name: nome da tela
                component: o componente que será carregado como tela
                optios(title): título da tela      
          */}
          <Stack.Screen 
            name="Navegacao" 
            component={Navegacao}
            options={{title: "Navegação"}}  
          />
          <Stack.Screen 
            name="Login" 
            component={Login}
            options={{title: "Login"}}  
          />
        </Stack.Navigator>
      </NavigationContainer>
  );
}
