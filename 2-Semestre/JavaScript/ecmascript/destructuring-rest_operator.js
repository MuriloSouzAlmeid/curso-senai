// //Destructuring -> extrair determinados atributos de um objeto de uma vez distribuindo em outras variáveis ou constantes apenas com o objeto desejado 

// const camisaLacoste = {
//     descricaoCamisa : "Camisada Lacoste",
//     preco: 349.98,
//     tamanho: "G",
//     marca: "Lacoste",
//     cor: "Amarelo",
//     promo: true
// };

// //primeiro passamos quais serão os elementos que serão extraídos e em seguida de qual objeto será atribuído
// //const/let {elemento1, elemento2, ... , elementoN} = objeto com as propriedades em questão
// const {descricaoCamisa, preco, promo} = camisaLacoste; //Destructoring


// //recursos das `` se chama Literal Templates que indica uma região do código onde usamos interpolação
// console.log(`
//     Produto: ${descricao},
//     Preço: ${preco},
//     Promoção: ${promo ? 'Sim' : 'Não'}
// `);


/*Exercício: crie um objeto evento com as propriedades:
    => Data do Evento
    => Descrição do Evento
    => Título
    => Presença
    => Comentário
*/

const evento = {
    titulo: "Evento JavaScript",
    descricao: 'Evento sobre lógica de programação e POO em JavaScript',
    data: new Date(),
    presenca: true,
    comentario: "O evento foi muito bom. Meus parabéns para a equipe envolvida.",
    exibe: true
};

//Conceito Rest - define o resto do objeto ou array desestruturado e o joga para um novo objeto ou array
//se for o resto de um objeto resultará em um novo objeto, se for um array resultará em um novo array 

const {titulo, descricao, data, ...restoDoObjeto} = evento; //na escrita utlizamos o 3 pontos seguido do nome do novo elemento a ser criado

console.log(titulo);
console.log(descricao);
console.log(data);
console.log(restoDoObjeto);

//define o local da data para ser formatada
// const options = { timeZone: 'America/Sao_Paulo' };

// console.log(`
//     Título Do Evento: ${titulo}. 

//     Descrição do Evento: ${descricao}.
//     Data do Evento: ${data.toLocaleString('pt-BR', options)}.
//     Presença: ${presenca ? 'Confirmada' : 'Não Confirmada'}.
//     Comentário do Evento: ${comentario}.
// `);