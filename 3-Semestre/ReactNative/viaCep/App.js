import {StatusBar } from 'react-native';
import { useFonts } from 'expo-font';
import { Roboto_500Medium, Roboto_700Bold } from '@expo-google-fonts/roboto';

import { ContainerApp } from './style';
import { Header } from './src/components/Header';
import { Home } from './src/screens/HomeScreen';

export default function App() {
  const [fontLoaded, fontError] = useFonts({
    Roboto_500Medium, Roboto_700Bold
  })

  if(!fontLoaded && !fontError){
    return null;
  }

  return (
    <ContainerApp>
      <StatusBar
        barStyle="default"
        backgroundColor="transparent"
        translucent
      />

      {/* HEADER */}
      <Header/>

      {/* HOMESCREEN */}
      <Home/>

    </ContainerApp>
  );
}
