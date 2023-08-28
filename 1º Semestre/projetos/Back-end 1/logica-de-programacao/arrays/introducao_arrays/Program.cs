// Array e Foreach

// Um tipo de variável que pode guardar um ou mais valor

// Programa de informar os carros

// Sem o Array

// string carro1;
// string carro2;
// string carro3;

// Console.WriteLine($"Digite o nome do carro:");
// carro1 = Console.ReadLine();

// Console.WriteLine($"Digite o nome do carro:");
// carro2 = Console.ReadLine();

// Console.WriteLine($"Digite o nome do carro:");
// carro3 = Console.ReadLine();

// Console.WriteLine($"O primeiro carro digitados foi: {carro1}");
// Console.WriteLine($"O segundo carro digitados foi: {carro2}");
// Console.WriteLine($"O terceiro carro digitados foi: {carro3}");

// Com o Array

// string[] carros = new string[3];

// Console.WriteLine($"Digite o nome do 1º carro:");
// carros[0] = Console.ReadLine();

// Console.WriteLine($"Digite o nome do 2º carro:");
// carros[1] = Console.ReadLine();

// Console.WriteLine($"Digite o nome do 3º carro:");
// carros[2] = Console.ReadLine();

// Console.WriteLine($"O 1º carro digitados foi: {carros[0]}");
// Console.WriteLine($"O 2º carro digitados foi: {carros[1]}");
// Console.WriteLine($"O 3º carro digitados foi: {carros[2]}");


// Array com laços de Repetição

string[] carros = new string[3];

int indice;

for(indice = 0; indice < 3; indice++){
    Console.WriteLine($"Digite o nome do {indice + 1}º carro:");
    carros[indice] = Console.ReadLine();
}

indice = 0;
foreach(var item in carros){
    Console.WriteLine($"O {indice + 1}º carro digitado foi: {item}");
    indice++;
}