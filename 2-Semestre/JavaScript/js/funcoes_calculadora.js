//função para calcular
function Calcular() {
    //sempre que houver uma validação antes de postar os dados de um formulário
    event.preventDefault(); //interrompe o submit (postar) do formulário

    //usando let a variável só pode ser usada dentro da estrutura que foi criada
    let n1 = parseFloat(document.getElementById(`numero1`).value);

    //caso o valor do texto não combine com um valor numérico durante a conversão a variáel se torna NaN
    let n2 = parseFloat(document.getElementById(`numero2`).value);

    //isNaN() -> define se o tipo de dado é NaN ou não, retornando true se for e false se não for
    if (isNaN(n1) || isNaN(n2)) {
        alert("Preencha todos os campos!");

        //retorna nada apenas para não ler o restante do código à toa
        return;
    }

    let res; //undefined => valor indefinido

    let op = document.getElementById("operacao").value;

    // strings e números são diferenciados no console.log pela cor do dado retornado

    console.log(`1º n: ${n1}`);
    console.log(`2º n: ${n2}`);

    //lógica para operadores da calculadora

    switch (op) {
        //caso para somar
        case "+":
            res = Somar(n1, n2);
            break;

        //caso para subtrair
        case "-":
            res = Subtrair(n1, n2);
            break;

        //caso para multiplicar
        case "x":
            res = Multiplicar(n1, n2);
            break;

        //caso para dividir
        case ":":
            res = Dividir(n1, n2);
            break;

        default:
            //só é possível retornar um texto diretamente sem validação por conta de uma linguaguem fracamente tipada
            res = `Operação selecionada inválida!`
            break;
    }

    //apropriedade value vale apenas para campos de formulário, em casos de tags html seu valor é descrito pelo atributo .innerText ou innerHtml
    //no caso de innerText irá aparecer apenas o texto de uma tag, mas no caso innerHtml irá receber as tags escritar por extenso no valor


    /*Tipos de dados
    Undefined => variável que não possui valor atrubuído em sua declaração
    Null => quando atrubuímos por conta própria o valor nulo para uma variável
    Infinity => quanod o valor da operação resulta em um número infinito
    NaN => um tipo especial, indica o resultado de uma operação que era pra ser um núemro mas retornou algo que não é um número seja em conversões ou operações numéricas*/

    //o elemento recebe o valor da variável a ser escrito

    //verifica de res é um número e se for atribui o .ToFixed()
    if (isNaN(res) == false) {
        res = res.toFixed(2);
        //o método toFixed(qtd de casas decimais) => define o número máximo de casas decimais do resultado 
        //caso o retorno seja uma string não há como aplicar o método .toFixed() logo devemos utiliá-los em um dado certamente do tipo número
    }

    document.getElementById("resultado").innerText = res;

    // alert('Bora Calcular!');


}//fim da função calcular

// função para somar
function Somar(n1, n2) {
    //caso um dos valores seja uma string irá concatenar e na hora do retorno o resultado será NaN
    return n1 + n2;
}

// função para subtrair
function Subtrair(n1, n2) {
    return n1 - n2;
}

// função para multiplicar
function Multiplicar(n1, n2) {
    return n1 * n2;
}

// função para dividir
function Dividir(n1, n2) {
    if (n1 == 0 && n2 == 0) {
        return `Resultado Indefinido! (Não é possível dividir 0 por 0)`;
    } if (n2 == 0) {
        return `Não dividirás por 0 (Não é possível dividir um número por 0)`;
    }
    return n1 / n2;
}