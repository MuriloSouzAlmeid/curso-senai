import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, Image, View, TextInput, TouchableOpacity } from 'react-native';

export default function App() {
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
              inputMode='email'
              style={styles.input}
              placeholder='Digite seu email:'
            />
          </View>

          <View style={styles.inputBox}>
            <Text style={styles.label}>Senha:</Text>
            <TextInput
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
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
    width: '80%',
    marginLeft: '10%'
  },
  loginBox: {
    alignItems: 'center',
    justifyContent: 'center',
    width: '100%'
  },
  title: {
    textTransform: 'uppercase',
    color: '#0E7670',
    fontSize: 30,
    fontWeight: 'bold',
    marginTop: 35,
    marginBottom: 35
  },
  imgLogo: {
    width: 200,
    height: 200
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
    width: '50%',
    height: 40
  },
  txtEntrar: {
    color: 'white',
    fontSize: 15
  }
});
