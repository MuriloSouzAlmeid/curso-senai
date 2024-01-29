import { FlatList, SafeAreaView, StatusBar, View, Text } from 'react-native';
import Person from './src/components/Person/Person';
import { Jogo } from './src/components/Jogo/Jogo';
import { useFonts } from "expo-font";
import { Poppins_400Regular } from '@expo-google-fonts/poppins';
import { OpenSans_700Bold } from '@expo-google-fonts/open-sans';
import { PoorStory_400Regular } from '@expo-google-fonts/poor-story';

export default function App() {
  const [fonts] = useFonts({
    Poppins_400Regular,
    OpenSans_700Bold,
    PoorStory_400Regular
  });

  if (!fonts) {
    return null;
  }

  const listaDePessoas = [
    {
      id: 1,
      nome: 'Murilo',
      age: 18
    }, {
      id: 2,
      nome: 'Jeferson',
      age: 42
    }, {
      id: 3,
      nome: 'Andreia',
      age: 40
    }
  ];

  const listaDeJogos = [{
    id: 1,
    titulo: 'Palworld',
    descricao: 'Este é um jogo completamente inovador de fabricação e sobrevivência em mundo aberto com suporte para vários jogadores. Nele você reúne criaturas fantásticas conhecidas como "Pals" em um vasto mundo e as usa em batalhas ou para trabalhos em construção, fazendas ou fábricas.',
    generos: ['Ação', 'Aventura', 'RPG'],
    preco: '89,99',
    dataLancamento: '19 de Janeiro de 2024',
    desenvolvedora: 'Pocketpair'
  },{
    id: 2,
    titulo: 'Hollow Knight',
    descricao: 'Forje seu caminho em Hollow Knight! Uma aventura de ação épica em um vasto reino arruinado de insetos e heróis. Explore cavernas serpenteantes, lute contra criaturas malignas e alie-se a insetos bizarros num estilo clássico 2D desenhado à mão.',
    generos: ['Ação', 'Aventura', 'Indie'],
    preco: '46,99',
    dataLancamento: '24 de Fevereiro de 2017',
    desenvolvedora: 'Team Cherry'
  }]

  return (
    <SafeAreaView>
      <StatusBar />

      {/* Flat List */}
      <FlatList
        data={listaDePessoas}

        // tem que ser especificamente item
        keyExtractor={item => item.id}
        renderItem={({ item }) => <Person name={item.nome} age={item.age} />}

      />

      <FlatList
        data={listaDeJogos}
        keyExtractor={item => item.id}
        renderItem={({ item }) => <Jogo titulo={item.titulo} descricao={item.descricao} generos={item.generos} preco={item.preco} dataLancamento={item.dataLancamento} desenvoldedora={item.desenvolvedora} />}
      />
    </SafeAreaView>
  );
}
