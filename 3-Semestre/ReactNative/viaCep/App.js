import {StatusBar } from 'react-native';
import { useFonts } from 'expo-font';
import { Roboto_500Medium, Roboto_700Bold } from '@expo-google-fonts/roboto';

import { ContainerApp } from './style';
import { Header } from './src/components/Header';

export default function App() {
  const [fonts] = useFonts({
    Roboto_500Medium, Roboto_700Bold
  })

  if(!fonts){
    return null;
  }

  return (
    <ContainerApp>
      <StatusBar
        backgroundColor="#FECC2B"
      />

      {/* HEADER */}
      <Header/>

      {/* HOMESCREEN */}

    </ContainerApp>
  );
}
