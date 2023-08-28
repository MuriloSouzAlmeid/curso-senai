// Aprovado ou Reprovado?


// Sabemos que um aluno é aprovado caso apresente média maior ou igual a 7.0 e frequência maior ou igual a 75%. Na verdade, em uma situação real, se o aluno obtiver a frequência mínima exigida e uma média entre 3 e 7, ainda teria direito a uma última avaliação de recuperação. Como faríamos para resolver o problema em questão utilizando apenas estruturas de condição se-então-senão? Poderíamos começar avaliando a frequência do aluno, e se a mesma for menor que 75% o aluno já estaria reprovado, porém caso a frequência respeite o mínimo exigido, começaríamos a avaliar a média para saber se está aprovado, em recuperação ou reprovado.

// Início
Console.ForegroundColor = ConsoleColor.DarkYellow;

Console.WriteLine(@$"
========================================================================
                     Está Aprovado ou Reprovado?
========================================================================
");

Console.ResetColor();

// Entradas

Console.ForegroundColor = ConsoleColor.DarkBlue;

Console.WriteLine($"Informe qual a primeira nota do aluno:");
float n1 = float.Parse(Console.ReadLine());
Console.WriteLine($"Informe qual a segunda nota do aluno:");
float n2 = float.Parse(Console.ReadLine());
Console.WriteLine($"Informe qual a terceira nota do aluno:");
float n3 = float.Parse(Console.ReadLine());

Console.WriteLine($"Informe quantos dias de aula letivos sua instituição teve nesse bimestre:");
float aulasTotais = float.Parse(Console.ReadLine());

Console.WriteLine($"Desses {aulasTotais} dias, quantos o aluno faltou?");
float faltasAluno = float.Parse(Console.ReadLine());

Console.ResetColor();


// Processamento

float media = (n1 + n2 + n3) / 3;

float faltasMaximas = (25/100f) * aulasTotais;

if(faltasAluno > faltasMaximas){
    Console.ForegroundColor = ConsoleColor.DarkRed;

    // Saída
    Console.WriteLine(@$"
O aluno Está Reprovado por nâo ter atingido a frequência mínima de no máximo {faltasMaximas} faltas!!");

Console.ResetColor();

} else if(media >= 7){

    Console.ForegroundColor = ConsoleColor.Green;

    // Saída
    Console.WriteLine(@$"
O aluno Está Aprovado!! Com média final de {Math.Round(media,1)}");

Console.ResetColor();

} else if(media >= 3){

    Console.ForegroundColor = ConsoleColor.Yellow;

    // Saída
    Console.WriteLine(@$"
O aluno Está Retido!! Com média final de {Math.Round(media,1)}. mas ainda tem direito a uma avaliação de recuperção.");

Console.ResetColor();

} else{

    Console.ForegroundColor = ConsoleColor.Red;

    // Saída
    Console.WriteLine(@$"
O aluno Está Reprovado!! Com média final de {Math.Round(media,1)}");

Console.ResetColor();

}

// Fim

Console.WriteLine(@$"
========================================================================
                            Fim do Programa
========================================================================
");