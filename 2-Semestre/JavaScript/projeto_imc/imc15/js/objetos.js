//objeto literal
let murilo = {
    //possui características da mesma forma que o json
    "chave": "valor",
    "nome": "murilo",
    "idade": 17
};

//criado pelo construtor
let gabriel = new Object();
gabriel.nome = "gabiel";
gabriel.idade = 17;

//método em um objeto dinâmico => podendo ser por uma função anônima ou expressão lambda
murilo.ExibeMensagem = (texto,numero) => {
    console.log(texto);
    console.log(`Número ${numero}`);
}

console.log(murilo);
console.log(gabriel);
murilo.ExibeMensagem("Deu certo",10);