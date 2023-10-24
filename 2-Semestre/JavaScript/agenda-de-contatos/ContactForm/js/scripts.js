const urlLocal = "http://localhost:3000/contatos";

function salvarContato(e) {
    e.preventDefault();

    //início da lógica
    let informacoesContato = {
        nome: {
            primeiroNome: document.getElementById("nome").value,
            Sobrenome: document.getElementById("sobrenome").value
        },
        email: document.getElementById("email").value,
        telefone: {
            pais: document.getElementById("pais").value,
            ddd: document.getElementById("ddd").value,
            numeroTelefone: document.getElementById("telefone").value
        },
        endereco: {
            cep: document.getElementById("cep").value,
            rua: document.getElementById("rua").value,
            numero: document.getElementById("numero").value,
            complemento: document.getElementById("complemento").value,
            bairro: document.getElementById("bairro").value,
            cidade: document.getElementById("cidade").value,
            uf: document.getElementById("UF").value
        },
        anotacoes: document.getElementById("anotacoes").value
    } //fim do objeto

    gravarNoJSON(informacoesContato);

    limparFormulário();

} //fim da função de salvar contatos

async function gravarNoJSON(informacoesContato) {

    try {
        const retornoApi = await fetch(urlLocal, {
            body: JSON.stringify(informacoesContato),
            headers: { "Content-Type": "application/json" },
            method: "post"
        });

        console.log(`Contato cadastrado com sucesso! ${retornoApi.json()}`);
    } catch (erro) {
        console.log(`Algo deu errado!`);
        console.log(`Erro: ${erro}`);
    }

} //fim da função de gravar as informações no banco de dados json

function limparFormulário() {

    document.getElementById("nome").value = "";
    document.getElementById("sobrenome").value = "";
    document.getElementById("email").value = "";
    document.getElementById("pais").value = "";
    document.getElementById("ddd").value = "";
    document.getElementById("telefone").value = "";
    document.getElementById("cep").value = "";
    document.getElementById("rua").value = "";
    document.getElementById("numero").value = "";
    document.getElementById("complemento").value = "";
    document.getElementById("bairro").value = "";
    document.getElementById("cidade").value = "";
    document.getElementById("UF").value = "";
    document.getElementById("anotacoes").value = "";

} //fim da função para a limpeza dos campos dos formulários

async function exibirEndereco() {

    let cep = document.getElementById("cep").value;
    const urlViaCep = `https://viacep.com.br/ws/${cep}/json/`;

    try {
        const retornoApi = await fetch(urlViaCep);

        const endereco = await retornoApi.json();

        await preencherEndereco(endereco);

    } catch (erro) {
        alert("Insira um cep válido");
        limparEndereco();
        console.log(`Erro: ${erro}`);
    }

} //fim da função que busca os dados do endereço pelo cep

function preencherEndereco(endereco) {

    const { cep, logradouro, complemento, bairro, localidade, uf, ...resto } = endereco;

    document.getElementById("rua").value = logradouro;
    document.getElementById("complemento").value = complemento;
    document.getElementById("bairro").value = bairro;
    document.getElementById("cidade").value = localidade;
    document.getElementById("UF").value = uf;

} //fim da função para preencher os campos de endereço

function limparEndereco() {

    document.getElementById("rua").value = "";
    document.getElementById("complemento").value = "";
    document.getElementById("bairro").value = "";
    document.getElementById("cidade").value = "";
    document.getElementById("UF").value = "";

} //fim da função para limpar os campos preenchhidos no endereço
