// Culpado ou Inocente?

// Início

Console.WriteLine(@$"
Culpado ou Suspeito?
");

// Entrada

int contadorCulpado = 0;

Console.WriteLine($"Você telefonou para a vítima recentemente? (s/n)");
string respostaTelefone = Console.ReadLine().ToUpper();

Console.WriteLine($"Você esteve no local do crime? (s/n)");
string respostaLocal = Console.ReadLine().ToUpper();

Console.WriteLine($"Você mora perto da vítima? (s/n)");
string respostaMoradia = Console.ReadLine().ToUpper();

Console.WriteLine($"Você devia alguma quantida em dinheiro para a vítima? (s/n)");
string respostaDivida = Console.ReadLine().ToUpper();

Console.WriteLine($"Você trabalha ou já trabalhou com a vítima antes? (s/n)");
string respostaTrabalho = Console.ReadLine().ToUpper();

// Processamento

if(respostaTelefone == "S"){
    contadorCulpado++;
}

if(respostaLocal == "S"){
    contadorCulpado++;
}

if(respostaMoradia == "S"){
    contadorCulpado++;
}

if(respostaDivida == "S"){
    contadorCulpado++;
}

if(respostaTrabalho == "S"){
    contadorCulpado++;
}

// Saída

if(contadorCulpado == 5){
    Console.WriteLine(@$"
Parece que enfim achamos o nosso CULPADO!! (é você)");   
} else if(contadorCulpado >= 3){
    Console.WriteLine(@$"
Ao que parece cabamos de trombar com um belo de um CUMPLICE!! (você mesmo)");
} else if(contadorCulpado == 2){
    Console.WriteLine(@$"
Mesmo que não tenhamos como provar nada, essa sua cara não me engana, você é um baita de um SUSPEITO!!");
} else{
    Console.WriteLine(@$"
Sinto muito o incômodo senhor, parece que pegamos o cara errado. O senhor foi considerado INOCENTE.");    
}

// Fim

Console.WriteLine(@$"
Fim do Programa.");
