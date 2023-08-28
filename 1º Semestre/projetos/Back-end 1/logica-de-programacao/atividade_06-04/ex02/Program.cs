// Senha Segura

// Faça um programa que leia um nome de usuário e a sua senha e não aceite a senha igual ao nome do usuário, mostrando uma mensagem de erro e voltando a pedir as informações.

// Início

Console.WriteLine($"\nCadastre-se Abaixo:\n");

Console.WriteLine($"Digite seu primeiro nome:");
string primeiroNome = Console.ReadLine().ToUpper();

Console.WriteLine($"\nDigite seu sobrenome:");
string sobreNome = Console.ReadLine().ToUpper();

Console.WriteLine($"\nDigite sua senha:");
string senha = Console.ReadLine().ToUpper();

while(senha.Contains(primeiroNome)){
    Console.WriteLine($"\nSua senha não pode conter seu nome nela. Digite uma senha mais segura:");
    senha = Console.ReadLine().ToUpper();
}

Console.WriteLine($"\nMuito bem senhor(a) {primeiroNome} {sobreNome}, o senhor foi cadastrado com sucesso! Senha: {senha}");

// Fim