import { useFonts } from 'expo-font';
import { MontserratAlternates_600SemiBold,MontserratAlternates_400Regular, MontserratAlternates_700Bold, MontserratAlternates_500Medium } from '@expo-google-fonts/montserrat-alternates';
import { Quicksand_500Medium, Quicksand_600SemiBold, Quicksand_400Regular } from '@expo-google-fonts/quicksand';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import { NavigationContainer } from '@react-navigation/native';
import { Navegacao } from './src/screens/Navegacao/navegacao';
import { Login } from './src/screens/Login/login';
import { Cadastro } from './src/screens/Cadastro/cadastro';
import { RedefinirSenha } from './src/screens/RedefinirSenha/redefinir-senha';
import { VerificarEmail } from './src/screens/VerificarEmail/verificar-email';
import { Home, HomePaciente } from './src/screens/Home/home';
import { PerfilDeMedico, PerfilDeUsuario } from './src/screens/PerfilDeUsuario/perfil-de-usuario';
import { PaginaDeProntuario } from './src/screens/Prontuario/prontuario';
import { SelecionarClinica, SelecionarData, SelecionarMedico } from './src/screens/PaginasSelecao/peginas-selecao';
import { LocalConsulta } from './src/screens/LocalConsulta/localConsulta';
import { VisualizarPrescricao } from './src/screens/VisualizarPrescricao/visualizarPrescricao';
import Main from './src/screens/Main/Main';
import { ReceberEmail } from './src/screens/ReceberEmail/receberEmail';

import { LogBox } from 'react-native';

LogBox.ignoreAllLogs();

//instância de um objeto da classe Native Stack Navigator para acessar seus métodos
const Stack = createNativeStackNavigator();

export default function App() {

  //carrega as fontes dentro do useFonts
  const [fontsLoaded, fontsError] = useFonts({
    MontserratAlternates_600SemiBold,
    MontserratAlternates_400Regular,
    MontserratAlternates_700Bold,
    Quicksand_500Medium,
    Quicksand_600SemiBold,
    Quicksand_400Regular,
    MontserratAlternates_500Medium
  })

  if (!fontsLoaded || fontsError) {
    return;
  }

  return (
    //Container de Navegação - envolve toda a estrutura de navegação
      <NavigationContainer>
        {/* Navigator - componente que realiza a navegação */}
        <Stack.Navigator
        screenOptions={{
          headerShown: false
        }}>
          {/* Telas - a tela a ser carregada
                name: nome da tela
                component: o componente que será carregado como tela
                options(title): título da tela      
          */}
          {/* <Stack.Screen 
            name="Navegacao" 
            component={Navegacao}
            options={{title: "Navegação"}}  
          /> */}
          <Stack.Screen 
            name="Login" 
            component={Login}
            options={{title: "Login"}}  
          />
          <Stack.Screen
            name="Main"
            component={Main}
          />
          <Stack.Screen 
            name="Cadastro" 
            component={Cadastro}
            options={{title: "Cadastro"}}  
          />
          <Stack.Screen
            name="ReceberEmail"
            component={ReceberEmail}
            options={{title: "Receber Email"}}
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
            options={{title: "Perfil de Usuário"}}
          />
          <Stack.Screen
            name="PaginaDeProntuario"
            component={PaginaDeProntuario}
            options={{title: "Página de Prontuário"}}
          />
          <Stack.Screen
            name="SelecionarClinica"
            component={SelecionarClinica}
            options={{title: "Selecionar Clínica"}}
          />
          <Stack.Screen
            name="SelecionarMedico"
            component={SelecionarMedico}
            options={{title: "Selecionar Médico"}}
          />
          <Stack.Screen
            name="SelecionarData"
            component={SelecionarData}
            options={{title: "Selecionar Data"}}
          />
          <Stack.Screen
            name="LocalConsulta"
            component={LocalConsulta}
            options={{title: "Local da Consulta"}}
          />
          <Stack.Screen
            name="VisualizarPrescricao"
            component={VisualizarPrescricao}
            options={{title: "Visualizar Prescrição"}}
          />
        </Stack.Navigator>
      </NavigationContainer>
  );
}
