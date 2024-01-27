import { useCallback, useEffect, useState } from 'react';
import { StatusBar } from 'react-native';
import { Inika_400Regular, Inika_700Bold } from '@expo-google-fonts/inika';
import { StyleSheet, Text, Image, View, TextInput, TouchableOpacity } from 'react-native';
import * as SplashScreen from 'expo-splash-screen';
import * as Font from 'expo-font';

// mantém a tela de splash visível enquanto as fontes são carregadas
SplashScreen.preventAutoHideAsync();

export default function App() {

  //state para deinir se a App.js poderá ser carregada ou não
  const [isReady, setIsReady] = useState(false);

  useEffect(() => {
    async function prepara(){
      try {
          // vai esperar as fontes que passei como parâmetro carregar
          await Font.loadAsync({
            Inika_400Regular, Inika_700Bold
          });

          //cria um tempo de "mentirinha" para manter splashscreen
          await new Promise(resposta => setTimeout(resposta, 2000));
      } catch (erro) {
        //mostra um aviso com o erro sem quebar a aplicação
        console.warn(erro);
      } 
      // vai acontecer independente de ter dado certo ou errado
      finally {
        //está pronto para carregar a App.js
        setIsReady(true)
      }
    }
    prepara();
  },[]);

  //agora usa-se um outro Hook, o useCallback que funciona da mesma forma que o useEffect, no entanto este não irá rodar quando a página carregar pela primeira vez e sim somente quando a dependência for alterada


  //precisa do Root no nome de não não funciona (não sei o pq)
  const onLayoutRootView = useCallback(async () => {
    // vai verificar se a tela App.js já pode ser carregada, se sim então vai tirar o SplashScreen
    if(isReady){
      // tem que esperar o retorno do useEffect, por isso o await
      await SplashScreen.hideAsync();
    }
  }, 
  //vai acontecer assim que o isReady que é a dependência for alterada
  [isReady]);

  // caso ainda não esteja pronto para ser carregado então apenas retorna nulo
  if(!isReady){
    return null;
  }



  return (
    // precisamos do onLayout na view para saber de fato de a App.js já pode ser carregada ou não
    <View  onLayout={onLayoutRootView} style={styles.container}>
      <StatusBar />
      <View style={styles.loginBox}>
        <Image
          style={styles.imgLogo}
          source={require('./src/assets/img/money-management.png')}
        />
        <Text style={styles.title}>Login</Text>
        <View style={styles.formBox}>
          <View style={styles.inputBox}>
            <Text style={styles.label}>Email:</Text>
            <TextInput
              placeholderTextColor={'rgba(2, 58, 4, 0.55)'}
              inputMode='email'
              style={styles.input}
              placeholder='Digite seu email:'
            />
          </View>

          <View style={styles.inputBox}>
            <Text style={styles.label}>Senha:</Text>
            <TextInput
              placeholderTextColor={'rgba(2, 58, 4, 0.55)'}
              secureTextEntry={true}
              style={styles.input}
              placeholder='Digite sua senha:'
            />
            <Text style={styles.textSenhaEsquecida}>Esqueci minha senha</Text>
          </View>

        </View>
        <TouchableOpacity style={styles.btnLogar}>
          <Text style={styles.txtEntrar}>Entrar</Text>
        </TouchableOpacity>
      </View>
      <View style={styles.titleSociais}>
        <View style={styles.rowSocial}></View>
        <Text style={styles.txtSociais}>Entrar com</Text>
        <View style={styles.rowSocial}></View>
      </View>
      <View style={styles.loginSociais}>
        <TouchableOpacity>
          <Image
            style={styles.imgSociais}
            source={require('./src/assets/img/google.png')}
          />
        </TouchableOpacity>
        <TouchableOpacity>

          <Image
            style={styles.imgSociais}
            source={require('./src/assets/img/microsoft.png')}
          />
        </TouchableOpacity>
        <TouchableOpacity>
          <Image
            style={styles.imgSociais}
            source={require('./src/assets/img/linkedin.png')}
          />
        </TouchableOpacity>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'space-between',
    width: '80%',
    marginLeft: '10%',
    marginRight: '10%',
    paddingTop: 100,
    paddingBottom: 115
  },
  loginBox: {
    alignItems: 'center',
    justifyContent: 'center',
    width: '100%',
    marginBotton: 30
  },
  title: {
    fontFamily: 'Inika_700Bold',
    textTransform: 'uppercase',
    color: '#0E7670',
    fontSize: 30,
    marginTop: 35,
  },
  imgLogo: {
    width: 150,
    height: 150
  },
  formBox: {
    width: '100%',
    gap: 25
  },
  inputBox: {
    gap: 5
  },
  label: {
    fontFamily: 'Inika_400Regular',
    color: '#0E7670',
    fontSize: 20
  },
  input: {
    borderWidth: 2,
    borderColor: '#18A11E',
    borderRadius: 10,
    width: '100%',
    height: 60,
    paddingLeft: 15
  },
  textSenhaEsquecida: {
    fontSize: 13,
    color: '#247309',
    marginLeft: 5,
    textDecorationLine: 'underline'
  },
  btnLogar: {
    alignItems: 'center',
    justifyContent: 'center',
    marginTop: 30,
    backgroundColor: '#18A11E',
    borderRadius: 10,
    width: '60%',
    height: 40,
    marginBottom: 30
  },
  titleSociais: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    gap: 10
  },
  txtEntrar: {
    color: 'white',
    fontSize: 15,
  },
  loginSociais: {
    gap: 42,
    flexDirection: 'row'
  },
  imgSociais: {
    marginTop: 30,
    height: 40,
    width: 40
  },
  txtSociais: {
    color: '#085A55'
  },
  rowSocial: {
    height: 0.000000000001,
    borderWidth: 0.8,
    width: '30%',
    borderColor: '#18A11E',
    borderTopColor: 'black'
  }
});
