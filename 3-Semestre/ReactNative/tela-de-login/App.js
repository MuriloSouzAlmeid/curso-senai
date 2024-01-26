import { StatusBar } from 'expo-status-bar';
import {useFonts} from 'expo-font';
import { StyleSheet, Text, Image, View, TextInput, TouchableOpacity } from 'react-native';

export default function App() {
  const [fontesPersonalizadas] = useFonts({
    'Inika-Bold': require('./src/assets/fonts/Inika/Inika-Bold.ttf')
  });

  return (
    <View style={styles.container}>
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
      <Text style={styles.txtSociais}>Entrar com</Text>
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
      <StatusBar style="auto" />
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
    paddingTop: 100,
    paddingBottom: 110
  },
  loginBox: {
    alignItems: 'center',
    justifyContent: 'center',
    width: '100%',
    marginBotton: 30
  },
  title: {
    fontFamily: 'Inika-Bold',
    textTransform: 'uppercase',
    color: '#0E7670',
    fontSize: 30,
    fontWeight: 'bold',
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
    color: '#10510B'
  }
});
