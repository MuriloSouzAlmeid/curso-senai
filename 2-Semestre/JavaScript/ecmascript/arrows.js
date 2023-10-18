//função convencional no EcmaScript
// const somar = (a, b) => { // função anônima
//     return a + b;
// };

// console.log(somar(20,50));

// const dobro = (c) => {
//     return c * 2;
// }

//quando há apenas 1 parâmetro podemos omitir os parênteses da função
// const dobro = c => {
//     return c * 2;
// }

//quando há apenas uma única linha dentro do bloco de códigos no comando podemos emitir a abertura e fechamento do bloco e a função de return
// const dobro = c => c * 2;

// console.log(dobro(75));


//quando há uma arrow function que não possui parâmetros é obrigado a colocar parênteses vazios na indicação de seus parâmetros
//quando não há um retorno da função (""tipo void"") devemos colocar as indicações de abertura e fechamento do bloco
// const boaTarde = () => { console.log("Boa Tarde"); };

// boaTarde(); // como já retorna um console.log() não há a necessidade de colocar a const dentro de um outro console.log()

const convidados = [
    //podemos escrever o objeto diretamente dentro do array
    {nome : "Murilo", idade : 17}, 
    {nome : "Matheus", idade : 24}, 
    {nome : "Mayara", idade : 15}, 
    {nome : "Miguel", idade : 13}
];

convidados.forEach((c,i) => { //função callback -> função passada como parâmetro que é chamada de tempos em tempos (no caso para cada item no array)
    console.log(`${i + 1}º Convidado: ${c.nome}, ${c.idade} anos`);
});