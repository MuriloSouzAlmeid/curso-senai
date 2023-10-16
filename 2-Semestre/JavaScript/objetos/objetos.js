// o node do javascript é uma forma de vizualizar os códigos gerados no console do editor de código, uma vez que o javascript foi criado para serf interpretado pelo navegador se fez necessário a criação de uma ferramenta a parte para poder vizualizar os comandos sem um navegador -> para rodar o comando usamos node "nome do arquivo com o script"



//para instanciar um novo objeto utilizamos o padrão chave e valor tal como no json
let murilo = {
    nome: "Murilo Souza Almeida",
    idade: 17,
    altura: 1.72
};

//como o javascript possui objetos dinâmicos os atributos podem ser instanciados também no decorrer do código
murilo.peso = 86;

//instancia um objeto vazio e sem atributos
let gabriel = new Object();

//como os objetos são dinâmicos eu posso criar aqui mesmo
gabriel.nome = "Gabriel Dantas";
gabriel.idade = 17;
gabriel.nivelDeEnsino = "Cursando o Ensino Médio"

// console.log(murilo);
// console.log(gabriel);

// let pessoas = new Array();
let pessoas = [];

pessoas.push(murilo, gabriel);

console.log(pessoas);

//diz o tamanho de um array
console.log(pessoas.length)

// exibir somente o nome das pessoas
pessoas.forEach(
    //Função anônima => é como uma função normal no entanto sem seu nome 
    // function (p, i) {
    //     console.log(`${i + 1}º Nome: ${p.nome}`);
    // }
    //Expressão Lâmbda => é um pouco diferente, primeiro que não tem nome e nem a declaração de que é uma função
    //na expressão lâmbda colocamos primeiro o parâmetro recebido (se tiver mais que um colocar entre parênteses), em seguida o símbolo de flecha (arrow) e por fim o corpo da função com o processamento de dados
    //1 parâmetro: x => {}; 2 ou mais: (x,y,z) => {}
    (p,i) => {
        console.log(`${i + 1}º Nome: ${p.nome}`);
    }
);