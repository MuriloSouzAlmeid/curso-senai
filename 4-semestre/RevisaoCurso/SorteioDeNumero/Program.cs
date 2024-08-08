// See https://aka.ms/new-console-template for more information

Random random = new Random();
int numeroSorteado = random.Next(100);

int tentativas = 0;
int numeroEscolhido = 0;

do
{
    Console.WriteLine($"Chute um número de 1 a 100");
    numeroEscolhido = int.Parse(Console.ReadLine());

    tentativas++;

    if(numeroEscolhido != numeroSorteado){
        Console.WriteLine(numeroEscolhido < numeroSorteado ? "Tenta mais alto aí!" : "Nao tão alto chefe!");
    }
    Console.WriteLine($"");
} while (numeroEscolhido != numeroSorteado);

Console.WriteLine($"Parabéns, você acertou o número em {tentativas} tentativas.");
