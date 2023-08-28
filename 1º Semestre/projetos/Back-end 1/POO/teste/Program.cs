static string FuncaoTeste(){
    return $"Hello World!\nPressione ENTER para continuar...\n {Console.ReadLine()}";
}

Console.WriteLine($"{FuncaoTeste()}");
