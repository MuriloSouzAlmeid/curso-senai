//Principais métodos da classe array -> para cada item em uma lista realizam determinada ação por uma função de callback
/*
foreach - não retorna (retorno void)
map - retorna um novo array modificado
filter
reduce
*/

const numeros = [1,57,25,37,12];

//foreach -> não retorna nada apenas executa comandos com todos os elementos no array - """tipo void"""
// numeros.forEach(n => {console.log(n)});

//map - retorna um novo array com todos os item modificados de acordo com uma consição especificada
const dobro = numeros.map( n => n * 2 );

//filter - retorna um novo array apenas com os elementos que atenderam a uma condição especificada
const maior25 = numeros.filter(n => n >= 25);

//reduce - retorna um valor reduzindo determinado array a um único valor de acordo com as determinadas condições
//possui dois parâmetros, a callback e o valor inicial que receberá os valores do array
const soma = numeros.reduce(
    (inicio, n) => inicio + n // a arrow function recebe primeiramente o valor inicial como parâmetro passado como o segundo parâmetro do reduce e só em seguida o valor de cada item, seu índice e assim por diante
, 10); //valor inicial podendo ser o que eu escolher

//o reduce também serve para concatenação de strings
const nomes = ["Murilo", " Souza ", "Almeida"];

const nomeCompleto = nomes.reduce((inicio, n) => inicio + n, "");


//retornos no prompt
console.log(numeros);
console.log(dobro);
console.log(maior25);
console.log(soma);
console.log(nomes);
console.log(nomeCompleto);



//exercício defixação

// const comentarios = [
//     {comentario: "Bom dia", exibe: true},
//     {comentario: "O evento foi uma putaria", exibe: false},
//     {comentario: "Meu nome é Murilo", exibe: true}
// ];

//como a condição retorna true ou false podemos colocar apenas a propriedade - o filter executa apenas quando for true
// const comentariosOk = comentarios.filter( c =>
//      c.exibe
//      //c.exibe === true
// );

// comentariosOk.forEach( (c,i) => {
//     console.log(`${i + 1}º Comentário: ${c.comentario}`);
// });

//= -> atribuição: atribui valores para variáveis
//== -> comparação: compara duas variáveis e caso seus valores sejam iguais retorna true, caso não retorna false
///=== -> idêntico: compara duas variáveis e rotorna true apenas se tanto os valores quanto os tipos das variáveis foram iguais, caso não sejam retorna false




