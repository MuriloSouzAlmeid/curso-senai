import { StatusBar } from 'expo-status-bar';
import { useEffect, useState } from 'react';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';

export default function App() {
  const [count, setCount] = useState(0);

  const increment = () => setCount(count + 1);

  const decrement = () => setCount(count - 1);

  useEffect(() => {
    console.warn(`Contador atualizado: ${count}`)
  }, [count])

  return (
    <View style={styles.container}>
      <View style={styles.countBox}>
        <Text style={styles.txtContador}>{count}</Text>
        <View style={styles.btnBox}>
          <TouchableOpacity
            onPress={increment}
            style={styles.btnIncrementar}
          >
            <Text style={styles.btnText}>+</Text>
          </TouchableOpacity>
          <TouchableOpacity
            onPress={decrement}
            style={styles.btnDecrementar}
          >
            <Text style={styles.btnText}>-</Text>
          </TouchableOpacity>
        </View>
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
    justifyContent: 'start'
  },
  countBox: {
    marginTop: 300,
    justifyContent: 'start',
    gap: 300,
    alignItems: 'center'
  },  
  txtContador: {
    fontSize: 80,
    textTransform: 'uppercase',
    color: 'blue'
  },
  btnBox: {
    flexDirection: 'row',
    gap: 20
  },
  btnIncrementar: {
    backgroundColor: 'green',
    borderRadius: '50%',
    width: 50,
    height: 50,
    justifyContent: 'center',
    alignItems: 'center',
  },
  btnDecrementar: {
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'red',
    color: 'white',
    width: 50,
    height: 50
  },
  btnText: {
    color: 'white',
    fontSize: 30
  }
});
