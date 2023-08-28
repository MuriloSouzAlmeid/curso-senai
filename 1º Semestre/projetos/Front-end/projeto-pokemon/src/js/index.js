// Pega o botão que vai alterar o tema e atribui a uma variável
const botaoAlterarTema = document.getElementById("botao-alterar-tema");

// Pega o body do cocumento html
const body = document.querySelector("body");

//Pega a tag img que irá mudar ao clicar no botão
var imagemAlterarTema = document.querySelector(".imagem-botao");

botaoAlterarTema.addEventListener("click", () => {
    if (body.classList.contains("modo-escuro")) {
        // Remove a classe modo escuro do elemento body
        body.classList.remove("modo-escuro");

        // Troca a imagem do botão para sol
        imagemAlterarTema.setAttribute("src", "src/img/sun.png")
    } else {
        // Adiciona a classe modo escuro no emelemnto body
        body.classList.add("modo-escuro");

        // Troca a imagem do botão para lua
        imagemAlterarTema.setAttribute("src", "src/img/moon.png");
    }
});