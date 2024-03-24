import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';

import Ohio from "./src/assets/sound/Ohio.mp3";

import * as Notifications from "expo-notifications";

Notifications.requestPermissionsAsync();

Notifications.setNotificationHandler({
  handleNotification: async () => ({
    shouldShowAlert: true,
    shouldPlaySound: true,
    shouldSetBadge: false,
  }),
});

export default function App() {

  const ChamarNotificacao = async () => {
    const { status } = await Notifications.requestPermissionsAsync();

    if (status !== "granted") {
      alert("Notificações ativadas!");
      return;
    }

    await Notifications.scheduleNotificationAsync({
      content: {
        title: "Bem-vindo ao Senai!",
        body: "Notificação recebida!",
        sound: Ohio,
      },
      trigger: null,
    });
  };

  return (
    <View style={styles.container}>
    <TouchableOpacity onPress={ChamarNotificacao} style={styles.btn}>
      <Text style={styles.text}>Clique aqui!</Text>
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
  },
  btn: {
    width: "40%",
    height: 90,
    backgroundColor: "red",
    alignItems: "center",
    justifyContent: "center",
    borderRadius: 15,
  },
  text: {
    color: "#fff",
    fontSize: 24,
  }
});
