import './App.css';
import Titulo from './components/Titulo/Titulo';
import CardEvento from './components/CardEvento/CardEvento';

function App() {
  //retorna um elemento html
  return (
    <div className="App">
      <h1>Hello World</h1>
      {/* componente que foi importado
      passa a propriedade na hora de instanciar o componente */}
      <Titulo texto="Murilo Souza" />
      <Titulo texto="Pedro Gabriel" />
      <Titulo texto="Guilherme Henrrique" />
      <Titulo texto="Filipe Góis" />
      <Titulo texto="Pedro Henrrique" />
      <CardEvento titulo="Título do Evento" descricao="Breve descrição do evento, pode ser um parágrafo pequeno." disabled={false} />
      <CardEvento titulo="Título do Evento" descricao="Breve descrição do evento, pode ser um parágrafo pequeno." disabled={true} />
    </div>
  );
}

//exporta a função App com o elemento html
export default App;
