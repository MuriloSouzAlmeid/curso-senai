// See https://aka.ms/new-console-template for more information

Console.WriteLine("Informe sua nota");
float nota = float.Parse(Console.ReadLine());

if(nota >= 5){
    Console.WriteLine("Aprovado");
}else{
    Console.WriteLine("Reprovado");
}