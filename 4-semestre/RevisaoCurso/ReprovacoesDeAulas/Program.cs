// See https://aka.ms/new-console-template for more information
using System.Runtime.Intrinsics.Arm;

List<List<float>> listaDeAlunos = new List<List<float>>();

Console.WriteLine($"Informe a quantidade de alunos");
int qtdAlunos = int.Parse(Console.ReadLine()!);

Console.WriteLine($"");
Console.WriteLine($"Informe a quantidade de matérias:");
int qtdMaterias = int.Parse(Console.ReadLine()!);

Console.WriteLine($"");

for(int aluno = 1; aluno <= qtdAlunos; aluno++){
    Console.WriteLine($"Notas do {aluno}º aluno:");
    List<float> notasAluno = new List<float>();

    for (int n = 1; n <= qtdMaterias; n++)
    {
        Console.WriteLine($"Nota da {n}º matéria: ");
        float nota = float.Parse(Console.ReadLine()!);
        notasAluno.Add(nota);
    }

    listaDeAlunos.Add(notasAluno);
    Console.WriteLine($"");
    
}
Console.WriteLine($"");


foreach(List<float> notasAluno in listaDeAlunos){
    Console.WriteLine($"{listaDeAlunos.IndexOf(notasAluno) + 1}º Aluno:");
    float somaNotas = 0;
    
    foreach(float nota in notasAluno){
        somaNotas+=nota;
    }

    float media = somaNotas / notasAluno.Count();

    Console.WriteLine($"A média das notas do {listaDeAlunos.IndexOf(notasAluno) + 1}º é {media}");
    Console.WriteLine(media >= 7 ? "Este aluno está APROVADO" : "Este aluno está REPROVADO");
    Console.WriteLine($"");
    
}