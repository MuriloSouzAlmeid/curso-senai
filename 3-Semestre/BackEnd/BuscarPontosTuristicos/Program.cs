using GenerativeAI.Models;
using GenerativeAI.Types;
using Newtonsoft.Json;
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
            },
            Model = "gemini-1.5-pro"
        });
        //or var model = new GeminiProModel(apiKey)

        Console.WriteLine("Informe o local do qual você quer viajar");
        string local = Console.ReadLine()!;
        Console.WriteLine("");

        var res = "";

        while(local != "")
        {
            res = await model.GenerateContentAsync($"Me retorne uma lista em JSON dos 5 melhores pontos turísticos para se visitar no(a) {local}. O JSON representará uma lista de objetos e cada objeto deverá conter como propriedades o nome do ponto turístico, a cidade e país onde está situado e uma breve descrição do local. O nome dos atributos entao serao: nome, pais, cidade, descricao. Adicione também um atibuto chamado imagem contendo uma string vazia. Retorne o valor como um texto qualquer, no entanto simulando um json sem as crases no início e no final e iniciando e finalizando a resposta com colchetes []. Caso o local informado não exista no planeta Terra retorne como resposta: [].");

            PlaceSettings[] listaDePontosTuristicos = JsonConvert.DeserializeObject<PlaceSettings[]>(res);

            if (listaDePontosTuristicos.Length != 0) { 
                foreach (PlaceSettings pontoTuristico in listaDePontosTuristicos)
                {
                    Console.WriteLine(pontoTuristico.nome);
                    Console.WriteLine(pontoTuristico.descricao);
                    Console.WriteLine(pontoTuristico.cidade);
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Local Inválido");
                Console.WriteLine("");
            }

            Console.WriteLine("Informe o local do qual você quer viajar");
            local = Console.ReadLine()!;
            Console.WriteLine("");
        }
    }

    public class PlaceSettings
    {
        public string? nome { get; set; }
        public string? pais { get; set; }
        public string? cidade { get; set; }
        public string? descricao { get; set; }
        public string? imagem { get; set; }
    }
}