// Boas Práticas de digitação (um código mais limpo)
// muriloSouzaAlmeida -> Camel Case (usado para variáveis e parâmetros de métodos)
// MuriloSouzaAlmeida -> Pascal Case (usado pra nomes de classes e de métodos)

/* Tipos de Dados
int -> declarar valores de números inteiros (1, 2, 3, 4, 5 ...)
long -> declarar números inteiros só que muito altos
float -> declarar valores de números reais, funciona até 7 dígitos decimais (1,3 / 8,9 / 0,4 ...)
double -> declarar valores de números reais, funciona até 15 dígitos decimais
char -> declara valores de caracter/texto único (a, b, c, d, e ...)
string -> declara valores com dois ou mais caracteres (murilo, maçã, banana)
bool -> declara um valor de verdadeiro ou falso (true, false) */

// int quantidade = 10;
// double preco = 69.99D;
// float altura = 1.72F;
// bool humano = true;
// string texto = "Murilo";
// char letra = 'm';

// Console.WriteLine(altura);



// Operadores -> usados para realizar operações em variáveis e valores
// Operadores de Atribuição
// recebe -> = (Attribui um valor para uma variável ou constante)

// Operadores Aritmétricos
// soma -> +
// Console.WriteLine(2 + 5);

// subtração -> -
// Console.WriteLine(40 - 7);

// multiplicação -> *
// Console.WriteLine(4 * 3);

// divisão -> /
// Console.WriteLine(30 / 2);

// modular/resto da divisão -> %
// Console.WriteLine(5 % 2);


// poenciação -> **
// Console.WriteLine(3^2);

// incrementar (+1) -> ++ (só funciona em variáveis)
// int numeroIncrementar = 7;
// numeroIncrementar++;
// Console.WriteLine(numeroIncrementar);
// OU
// numeroIncrementar += 2;
// Console.WriteLine(numeroIncrementar);


// decrementar (-1) -> -- (só funciona em variáveis)
// int numeroIncrementar = 7;
// numeroIncrementar--;
// Console.WriteLine(numeroIncrementar);
// numeroIncrementar -= 2;
// Console.WriteLine(numeroIncrementar);


// Operadores de Comparação (True ou False)
//igual a -> ==
// Console.WriteLine(3 == 5); //False

//maior ou igual a >=
// Console.WriteLine(10 >= 15); //False

//menor ou igual a <=
// Console.WriteLine(30 <= 8); //False

//maior que >
// Console.WriteLine(24 > 3); //True

//menor que <
// Console.WriteLine(2 < 7); //True

//diferente de !=
// Console.WriteLine(7 != 28); //True



// Operadores Lógicos

// && -> e
// Console.WriteLine(5 == 5 && 8 > 3); //True && True -> True
/* true e true = true
true e false = false
false e false = false
false e true = false
*/

// || -> ou
// Console.WriteLine(3 == 5 || 39 < 10); // False e False -> Falae
/* true e true = true
true e false = true
false e true = false
false e false = false
*/

// ! -> negação : nega uma condição independente de seu resultado (trocando seus resultados)
// Console.WriteLine(!(5 == 5 && 4 == 6)); // False -> True
/* true = false
false = false
*/


// Cálculo de um IMC

string nome = "Murilo";
float peso = 92.5F;
float altura = 1.72F;

float imc = peso / (long)Math.Pow(altura, 2);

Console.WriteLine("O IMC do(a) " + nome + " é: " + Math.Round(imc,2)); 
//Math Round é um método que arredonda o valor da variável para apenas duas casas decimais sendo Math.Round(o valor a ser arredondado, quantas casas após a vírgula)





//Variáveis -> valores que podem variar de acordo com o processamento do código.

 /* Declarando uma variável
 tipo nomeVariável = valor ( o sinal de igual se le como recebe)
string meuNome = "Murilo Souza Almeida"; */
// Uma variável não precisa ser redeclarada.

//Declarando uma variável
// string meuNome = "Gabriel Cristhofolett Dantas";
// meuNome = "Murilo Souza Almeida";

// Console.WriteLine(meuNome);


//Constantes -> é um valor que se mantém inalterado no código do começo ao fim
// Os tipos de uma constante sao os mesmos de uma variável
// Declarando uma Constante -> uma constante deve ser declarado dessa maneira: const int nomeConstante = valor
// Uma constante não pode ser redeclarada

// const int minhaIdade = 17;
// minhaIdade = 19;

// Console.WriteLine(minhaIdade);


// Digitação / atalhos
/* Console.WriteLine = cwl */
// Console.WriteLine("A idade do(a) " + meuNome + " é " + minhaIdade + " anos.");



// Dando um Hello world
Console.WriteLine("Hello, World!!!");

// See https://aka.ms/new-console-template for more information