using GenerativeAI.Models;
using GenerativeAI.Types;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var apiKey = "AIzaSyCAMtSLTyOYk4DaIv--qxX8eZ7dZ2XpGzk";

        var model = new GenerativeModel(apiKey, new ModelParams()
        {
            GenerationConfig = new GenerationConfig()
            {
                Temperature = 0,
                CandidateCount = 1
            }
        });
        //or var model = new GeminiProModel(apiKey)

        Console.WriteLine("Informe o local do qual você quer viajar");
        string local = Console.ReadLine()!;
        Console.WriteLine("");

        var res = "";

        while(local != "")
        {
            res = await model.GenerateContentAsync($"Me retorne uma lista em JSON dos melhores pontos turísticos para se visitar no(a) {local}. O JSON representará uma lista de objetos e cada objeto deverá conter como propriedades o nome do ponto turístico, a cidade e país onde está situado e uma breve descrição do local");

            Console.WriteLine(res);
            Console.WriteLine("");

            Console.WriteLine("Informe o local do qual você quer viajar");
            local = Console.ReadLine()!;
            Console.WriteLine("");
        }
    }
}