import { useState } from 'react';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, Image, View, TextInput, TouchableOpacity } from 'react-native';

export default function App() {
  const [contador, setContador] = useState(0);

  const incrementar = () => {
    setContador(contador + 1)
  }

  const decrementar = () => {
    setContador(contador - 1)
  }

  return (
    <View style={styles.container}>
      <Text style={styles.text}>Teste de Imagem</Text>
      <Text>Tá dando certo???</Text>
      <Image
        style={styles.img}
        source={require('./src/assets/img/hqdefault.jpg')}
      />

      <Text style={styles.text2}>FUNCIONOU !!</Text>
      <TextInput
        style={styles.input}
        placeholder='Digite aqui mano'
      // defaultValue='Teste'
      />
      <View style={styles.contador}>
        <TouchableOpacity style={styles.button} onPress={incrementar}>
          <Text style={styles.textButton}>Aumentar</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.button} onPress={decrementar}>
          <Text style={styles.textButton}>Diminuir</Text>
        </TouchableOpacity>
      </View>
      <Text>{contador}</Text>
      <TouchableOpacity style={styles.button} onPress={() => { setContador(0) }}>
        <Text style={styles.textButton}>Cabô a Brincadeira</Text>
      </TouchableOpacity>
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
    gap: 20,
    backgroundColor: '#F8F8FF'
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
    height: 200,
    borderRadius: 20
  },
  input: {
    height: 40,
    width: "75%",
    margin: 12,
    borderWidth: 1,
    padding: 10,
    borderRadius: 10
  },
  contador: {
    flexDirection: 'row',
    width: '80%',
    justifyContent: 'space-between'
  },
  button: {
    borderColor: 'darkgrey',
    borderWidth: 2,
    backgroundColor: 'lightgray',
    width: "48%",
    height: 40,
    borderRadius: 12,
    justifyContent: 'center',
    alignItems: 'center'
  },
  textButton: {
    color: 'black'
  }
});
