import {useState} from 'react';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, Image, View, TextInput } from 'react-native';

export default function App() {
  const [textoDigitado, setTextoDigitado] = useState("");

  return (
    <View style={styles.container}>
      <Text style={styles.text}>Teste de Imagem</Text>
      <Text>Tá dando certo???</Text>
      <Image
        style={styles.img}
        source={{
          uri: 'https://i.ytimg.com/vi/za5wbJD62RE/hqdefault.jpg',
        }}
      />

      <Text style={styles.text2}>FUNCIONOU !!</Text>
      <TextInput
        style={styles.input}
        placeholder="Digite algo aqui:"
      />
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
    gap: 20
  },
  text: {
    fontSize: 20
  },
  text2: {
    color: '#483D8B',
    fontSize: 40
  },
  img: {
    width: 300,
    height: 200
  },
  input: {
    height: 40,
    width: 300,
    margin: 12,
    borderWidth: 1,
    padding: 10,
    borderRadius: 10
  }
});
