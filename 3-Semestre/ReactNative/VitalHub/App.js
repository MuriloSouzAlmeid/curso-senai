import { useFonts } from 'expo-font';
import { MontserratAlternates_600SemiBold,MontserratAlternates_400Regular, MontserratAlternates_700Bold } from '@expo-google-fonts/montserrat-alternates';
import { Quicksand_500Medium, Quicksand_600SemiBold } from '@expo-google-fonts/quicksand';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import { NavigationContainer } from '@react-navigation/native';
import { Navegacao } from './src/screens/Navegacao/navegacao';
import { Login } from './src/screens/Login/login';
import { Cadastro } from './src/screens/Cadastro/cadastro';
import { RedefinirSenha } from './src/screens/RedefinirSenha/redefinir-senha';
import { VerificarEmail } from './src/screens/VerificarEmail/verificar-email';
import { Home } from './src/screens/Home/home';
import { PerfilDeUsuario } from './src/screens/PerfilDeUsuario/perfil-de-usuario';

//instância de um objeto da classe Native Stack Navigator para acessar seus métodos
const Stack = createNativeStackNavigator();

export default function App() {
  const [fontsLoaded, fontsError] = useFonts({
    MontserratAlternates_600SemiBold,
    MontserratAlternates_400Regular,
    MontserratAlternates_700Bold,
    Quicksand_500Medium,
    Quicksand_600SemiBold
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
          <Stack.Screen 
            name="Cadastro" 
            component={Cadastro}
            options={{title: "Cadastro"}}  
          />
          <Stack.Screen 
            name="RedefinirSenha"
            component={RedefinirSenha}
            options={{title: "Redefinir Senha"}}
          />
          <Stack.Screen
            name="VerificarEmail"
            component={VerificarEmail}
            option={{title: "Verificar Email"}}
          />
          <Stack.Screen
            name="Home"
            component={Home}
            options={{title: "Página Home"}}
          />
          <Stack.Screen
            name="PerfilDeUsuario"
            component={PerfilDeUsuario}
            option={{title: "Perfil de Usuário"}}
          />
        </Stack.Navigator>
      </NavigationContainer>
  );
}
