// Validação de Data de Aniversário

// Escreva um programa que pergunte o dia, mês e ano do aniversário de uma pessoa e diga se a data é válida ou não. Caso não seja, diga o motivo. Suponha que todos os meses tem 31 dias e que estejamos no ano de 2013.

// Início

Console.WriteLine(@$"Programa que valida data de nascimento
");

// Entradas

bool diaValido = true;
bool mesValido = true;
bool anoValido = true;
string diaInvalido = "";
string mesInvalido = "";
string anoInvalido = "";

var dataAtual = DateTime.Now;

Console.WriteLine($"Em que dia você nasceu?");
int diaNascido = int.Parse(Console.ReadLine());

Console.WriteLine($"Em que mês você nasceu?");
int mesNascido = int.Parse(Console.ReadLine());

Console.WriteLine($"Em que ano você nasceu?");
int anoNascido = int.Parse(Console.ReadLine());

// Processamento

if((diaNascido > 31) || (diaNascido < 1)){
     diaInvalido = "o dia";
     diaValido = false;
 }

if((mesNascido > 12) || (mesNascido < 1)){
     mesInvalido = "o mês";
     mesValido = false;
}

if((anoNascido > dataAtual.Year) || (anoNascido < 1)){
     anoInvalido = "o ano";
     anoValido = false;
}

if(anoNascido == dataAtual.Year){
     if(mesNascido > dataAtual.Month){
         mesInvalido = "o mês";
         mesValido = false;
     } else if(diaNascido > dataAtual.Day){
         diaInvalido = "o dia";
         diaValido = false;
     }
}

// Saída

if((diaValido == false) && (mesValido == false) && (anoValido == false)){
    Console.WriteLine(@$"
A data informada é inválida pois {diaInvalido}, {mesInvalido} e {anoInvalido} informado não condiz com o calendário.");
} else if((diaValido == false) && (mesValido == false)){
    Console.WriteLine(@$"
A data informada é inválida pois {diaInvalido} e {mesInvalido} informado não condiz com o calendário.");
} else if((mesValido == false) && (anoValido == false)){
    Console.WriteLine(@$"
A data informada é inválida pois {mesInvalido} e {anoInvalido} informado não condiz com o calendário.");
} else if((diaValido == false) && (anoValido == false)){
    Console.WriteLine(@$"
A data informada é inválida pois {diaInvalido} e {anoInvalido} informado não condiz com o calendário.");
} else if(diaValido == false){
    Console.WriteLine(@$"
A data informada é inválida pois {diaInvalido} informado não condiz com o calendário.");
} else if(mesValido == false){
    Console.WriteLine(@$"
A data informada é inválida pois {mesInvalido} informado não condiz com o calendário.");
} else if(anoValido == false){
    Console.WriteLine(@$"
A data informada é inválida pois {anoInvalido} informado não condiz com o calendário.");
} else{
    Console.WriteLine(@$"
Muito bem, a data informada é válida");
}

// Fim

Console.WriteLine(@$"
Fim do Programa");