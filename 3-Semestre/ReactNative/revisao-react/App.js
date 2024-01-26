import { SafeAreaView, StatusBar} from 'react-native';
import Person from './src/components/Person/Person';

export default function App() {
  return (
    <SafeAreaView>
      <StatusBar/>
      <Person name={'Murilo Souza Almeida'} age={18}/>
      <Person name={'Gelipe Fóis'} age={17}/>
      <Person name={'Pedro Gabriel Gentileza'} age={20}/>
      <Person name={'Pedro Maconha'} age={18}/>
      <Person name={'Miguel Lamarca'} age={16}/>
    </SafeAreaView>
  );
}
