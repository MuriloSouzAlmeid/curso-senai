// Validação de Senha

Console.WriteLine(@$"
===============================================================
                   Bem vindo ao nosso servidor
===============================================================
");

Console.WriteLine($"Insira seu nome:");
string nome = Console.ReadLine();

Console.WriteLine($"\nInsira sua senha:");
string senha = Console.ReadLine();

// a propriedade .Length serve para saber quantos caracteres há em seu referencial (variável.Length)
while(senha.Length != 6){
    Console.WriteLine(@$"
Senha Inválida, a senha tem que ter 6 caracteres");
    Console.WriteLine($"Insira a senha novamente:");
    senha = Console.ReadLine();
    
}

Console.WriteLine(@$"
Login efetuado com sucesso! Aproveite nosso servidor senhor(a) {nome}");