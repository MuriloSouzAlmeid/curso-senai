//instancia a lista de pessoas que será exibida no HTML
const listaDePessoas = [];

//objeto event instanciado já no submit do formulário
function ExibeIMC(e) {
    e.preventDefault();

    let nome = document.getElementById("nome").value.trim(); //limpa a string
    let altura = parseFloat(document.getElementById("altura").value);
    let peso = parseFloat(document.getElementById("peso").value);

    if (isNaN(peso) || isNaN(altura) || nome.length <= 2) {
        alert("Todos os campos deve ser preenchidos da maneira correta!");
        return
    };

    let imc = calculaIMC(altura, peso);

    //método que verifica se um número é finito ou não
    if (!(isFinite(imc))) {
        alert("Insira dados válidos no fomulário!");
        return;
    }

    //gera a classificação do IMC do usuário passando o IMC como parâmetro
    let classificacao = verificaClassificacao(imc);

    //pega qual a data atual e retornar para a constante no entanto em milissegundos
    let dataAtual = Date.now();

    //converte a data para um objeto do tipo Date consertando seus valores de anos, meses, dias e horário 
    dataAtual = new Date(dataAtual);

    //define o local da data para ser formatada
    const options = { timeZone: 'America/Sao_Paulo' };

    //sempre que um usuário nõa vai ser alterado pode ser usado uma constante para criá-lo
    const pessoa = {

        //como o nome da variável é o mesmo da propriedade posso abreviar colocando apenas o nome em questão em vez do método "propriedade": "valor"
        //Método antigo => "propriedade": "valor"
        /*"nome": nome,
        "altura": altura,
        "peso": peso,
        "imc": imc,
        "classificacao": classificacao,*/

        //Novo Método
        nome, //como ambos (propriedade e valor) tem o mesmo nome podemos abreviar
        altura,
        peso,
        imc,
        classificacao,
        //formata a data para um formato legível
        "dataCadastro": gerarDataAtual()
    }

    //adiciona a pessoa cadastrada com os dados do formulário na lista de pessoas do script
    listaDePessoas.push(pessoa);

    //exibir os dados
    exibirPessoas();


    //função para limpar o formulário ao final do cálculo
    limparForm();
}

//função que calcula o valor do IMC
function calculaIMC(altura, peso) {
    return peso / Math.pow(altura, 2);
    // return peso/( altura * altura );
    // return peso/( altura**2 );
}

//função que verifica qual a classificação do IMC do usuário
function verificaClassificacao(imc) {
    if (imc < 18.5) {
        return "Magreza";
    } else if (imc < 25) {
        return "Peso Normal";
    } else if (imc < 30) {
        return "Acima do Peso";
    } else if (imc < 35) {
        classificacao = "Obesidade I";
    } else if (imc < 40) {
        classificacao = "Obesidade II";
    } else {
        return "Obesidade Grave. Cuidado!!";
    }
}

//função que gera a data atual para colocar no registro do formulário
function gerarDataAtual(){
    //pega qual a data atual e retornar para a constante no entanto em milissegundos
    let dataAtual = Date.now();

    //converte a data para um objeto do tipo Date consertando seus valores de anos, meses, dias e horário 
    dataAtual = new Date(dataAtual);

    //define o local da data para ser formatada
    const options = { timeZone: 'America/Sao_Paulo' };

    //retorna a data formatada
    return dataAtual.toLocaleString('pt-BR', options);
}

//função que gera as linhas da tabela no HTML
function exibirPessoas() {
    //listar as pessoas no console

    let template = ''; //template = pedaço de tela

    listaDePessoas.forEach(pessoa => {
        //linhas de tabela
        //+= para ir acumulando a string na variável
        template +=
            `<tr>
            <td data-cell="nome">${pessoa.nome}</td>
            <td data-cell="altura">${pessoa.altura}</td>
            <td data-cell="peso">${pessoa.peso}</td>
            <td data-cell="valor do IMC">${pessoa.imc.toFixed(2)}</td>
            <td data-cell="classificação do IMC">${pessoa.classificacao}</td>
            <td data-cell="data de cadastro">${pessoa.dataCadastro}</td>
        </tr>`
    });

    //inserir as linhas de tabela no html => tem que colocar dentro dessa função para sempre estar atualizando o inner html
    document.getElementById("corpo-tabela").innerHTML = template;
}

//função que limpa os valores dos campos do formulário
function limparForm() {
    //limpar os dados após o cálculo do imc
    document.getElementById("nome").value = '';
    document.getElementById("altura").value = '';
    document.getElementById("peso").value = '';
}

//método para limpar a lista de pessoas
function deletarRegistros() {

}


// Escopo de variáveis => define a visibilidade da variável no decorrer do código
/*
var => escopo global: válida para todo o código
let => escopo local (mais local possível): válida apenas dentro da estrutura em que foi criada
*/

//a propriedade const define que um valor atribuído não poderá ser mudado no código