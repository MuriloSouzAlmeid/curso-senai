// Medids da Circunferência

// Escreva um programa que pergunte o raio de uma circunferência, e sem seguida mostre o diâmetro, comprimento e área da circunferência.

// Início

Console.WriteLine(@$"Quais as medidas da circuferência?
");

// Entrada

Console.WriteLine($"Digite a medida do raio da circunferência em centímetros:");
float raio = float.Parse(Console.ReadLine());

// Peocessamento

float diametro = 2 * raio;
double comprimento = 2 * Math.PI * raio;
double area = Math.PI * (float)Math.Pow(raio,2);

// Saída

Console.WriteLine(@$"
O diâmetro da circunferência em questão mede {diametro} cm, o comprimento mede aproximadamente {Math.Round(comprimento,2)} cm e sua área mede aproximadamente {Math.Round(area,2)} cm ao quadrado");

// Fim

Console.WriteLine(@$"
Fim do Programa");