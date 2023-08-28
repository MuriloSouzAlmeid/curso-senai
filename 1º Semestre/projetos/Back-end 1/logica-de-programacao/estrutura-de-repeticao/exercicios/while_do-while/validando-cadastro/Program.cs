// Teste null

// Console.WriteLine($"Digite um número:");
// int? numeroTeste = int.Parse(Console.ReadLine());

// if(numeroTeste == null){
//     Console.WriteLine($"O número é nulo");
// } else{
//     Console.WriteLine($"O número é normal");
    
// }

// Validando Cadastro

// Início

Console.WriteLine($"\nCadastre-se em nosso Programa!\n");

// Entradas e Processamento

// Nome
Console.WriteLine($"Para começarmos, digite seu nome:");
string nome = Console.ReadLine();

while(nome == ""){
    Console.WriteLine($"Nome digitado inválido, digite novamente:");
    nome = Console.ReadLine();
}

// Idade

int? idade = 0;

Console.WriteLine($"\nAgora digite sua idade:");
string respostaIdade = Console.ReadLine();

if(respostaIdade == ""){
    idade = null;
} else{
    idade = int.Parse(respostaIdade);
}

while((idade < 1) || (idade > 100) || (idade == null)){
    if(idade < 1){
        Console.WriteLine($"\nIdade digitada pequena demais, digite uma idade maior:");
        respostaIdade = Console.ReadLine();
        if(respostaIdade == ""){
            idade = null;
        } else{
            idade = int.Parse(respostaIdade);
        }
    } else if(idade > 100){
        Console.WriteLine($"\nIdade digitada grande demais, digite uma idade menor:");
        respostaIdade = Console.ReadLine();
        if(respostaIdade == ""){
            idade = null;
        } else{
            idade = int.Parse(respostaIdade);
        }
    } else{
        Console.WriteLine($"\nIdade não digitada, digite novamente:");
        respostaIdade = Console.ReadLine();
        if(respostaIdade == ""){
            idade = null;
        } else{
            idade = int.Parse(respostaIdade);
        }
    }
}

// Salario

Console.WriteLine($"\nDigite agora seu salário:");
float salario = float.Parse(Console.ReadLine());

while(salario <= 0){
    Console.WriteLine($"\nSalário digitado inválido, digite novamente:");
    salario = float.Parse(Console.ReadLine());
}

// Estado Civil
Console.WriteLine($"\nDentre os Diferentes casos de Estado Civil abaixo, escolha em qual o senhor(a) se identifica:");
Console.WriteLine(@$"[s] -> Solteiro(a)
[c] -> Casado(a)
[v] -> Viúvo(a)
[d] -> Divorciado(a)");
string estadoCivil = Console.ReadLine().ToUpper();

while((estadoCivil != "S") && (estadoCivil != "C") && (estadoCivil != "V") && (estadoCivil != "D")){
    Console.WriteLine($"\nOpção escolhida não existe, escolha novamente:");
    estadoCivil = Console.ReadLine().ToUpper();
}

if(estadoCivil == "S"){
    estadoCivil = "Solteiro(a)";
} else if (estadoCivil == "C"){
    estadoCivil = "Casado(a)";
} else if (estadoCivil == "V"){
    estadoCivil = "Viúvo(a)";
} else{
    estadoCivil = "Divrciado(a)";
}

// Saída

Console.WriteLine($"\nSeja Bem Vindo ao nosso programa senhor(a).");
Console.WriteLine(@$"
| Nome: {nome}
| Idade: {idade} anos
| Salário: R${salario}
| Estado Civil: {estadoCivil}
");


// Fim