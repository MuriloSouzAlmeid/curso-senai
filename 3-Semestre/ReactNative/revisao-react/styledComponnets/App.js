import { StatusBar } from 'expo-status-bar';
import { useEffect, useState } from 'react';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';

import { Container } from './src/components/container/Container';
import { Title, TitleBtnIncrement, TitleBtnDecrement } from './src/components/titles/Title';

import { ButtonIncrement, ButtonDecrement } from './src/components/button/Button';

import { CountBox, ButtonBox } from './src/components/box/Box';


export default function App() {
  const [count, setCount] = useState(0);

  const increment = () => setCount(count + 1);

  const decrement = () => {
    if(count > 0){
      setCount(count - 1)
    }else{
      console.warn('Não é possível contador menor que 0')
    }
  };

  return (
    <Container>
      <CountBox>
        <Title>{count}</Title>
        <ButtonBox>
          <ButtonDecrement
            onPress={decrement}
          >
            <TitleBtnDecrement>-</TitleBtnDecrement>
          </ButtonDecrement>
          <ButtonIncrement
            onPress={increment}
          >
            <TitleBtnIncrement>+</TitleBtnIncrement>
          </ButtonIncrement>
        </ButtonBox>
      </CountBox>
      <StatusBar style="auto" />
    </Container>
  );
}