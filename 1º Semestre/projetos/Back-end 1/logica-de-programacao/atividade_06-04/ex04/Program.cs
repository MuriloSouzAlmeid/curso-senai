// Estudo de Caso da Empresa

// Uma certa empresa fez uma pesquisa de mercado com 10 pessoas para saber se elas gostaram um determinado
// produto lançado. Para isso forneceu o sexo do entrevistado e sua resposta (sim ou não). Faça um programa que calcule e imprima:
// A.O número de pessoas que responderam SIM.
// B.O número de pessoas que responderam NÃO;
// C.O número de mulheres que responderam SIM;
// D.A porcentagem de homens que responderam NÃO entre todos os homens analisados.

// Início
string sexo = "";
string resposta = "";

string masculino = "";
int masculinoSim = 0;
int masculinoNao = 0;

string feminino = "";
int femininoSim = 0;
int femininoNao = 0;

int totalMasculino = 0;
int totalFeminino = 0;

int pessoas = 0;

for(pessoas = 1; pessoas <= 10; pessoas++){
    Console.WriteLine($"\nPessoa {pessoas}:");
    Console.WriteLine(@$"Qual o seu sexo?
[M] -> Masculino
[F] -> Feminino");
    sexo = Console.ReadLine().ToUpper(); 
    if(sexo == "M"){
        masculino = "S";
        totalMasculino++;
    } else if(sexo == "F"){
        feminino = "S";
        totalFeminino++;
    } else{
        while((sexo != "M") && (sexo != "F")){
            Console.WriteLine($"\nOpção Escolhida inválida. Escolha dentre uma das opções abaixo:");
            Console.WriteLine(@$"
[M] -> Masculino
[F] -> Feminino");
            sexo = Console.ReadLine().ToUpper();
            if(sexo == "M"){
                masculino = "S";
                totalMasculino++;
            } else if (sexo == "F"){
                feminino = "S";
                totalFeminino++;
            }
        }
    }    

    Console.WriteLine($"\nEstá gostando do nosso programa? (s/n)");
    resposta = Console.ReadLine().ToUpper();
    switch(resposta){
        case "S":
            if(sexo == "M"){
                masculinoSim++;
            }else{
                femininoSim++;
            }
            break;
        
        case "N":
            if(sexo == "M"){
                masculinoNao++;
            }else{
                femininoNao++;
            }
            break;
        
        default:
            do{
                Console.WriteLine($"\nOpção Escolhida inválida. Escolha dentre uma das opções abaixo:");
                Console.WriteLine($"\n[S] -> Sim\n[N] -> Não");
                resposta = Console.ReadLine().ToUpper();
                switch(resposta){
                    case "S":
                        if(sexo == "M"){
                            masculinoSim++;
                        }else{
                            femininoSim++;
                        }
                        break;
                    
                    case "N":
                        if(sexo == "M"){
                            masculinoNao++;
                        }else{
                            femininoNao++;
                        }
                        break;
                } 
            }while((resposta != "S") && (resposta != "N"));
            break;
    }
}

Console.WriteLine($"\nObrigado a todos pela resposta!");
Console.WriteLine(@$"
Total de Respostas SIM: {femininoSim + masculinoSim}.
Total de Respostas NÃO: {femininoNao + masculinoNao}.
Total de Respostas SIM de usuários do sexo Feminino: {femininoSim}.
Porcentagem de Homens que responderam NÃO dos homens analisados: {(masculinoNao*100)/totalMasculino}%.
");

Console.WriteLine($"\nFim do Programa");


// Fim