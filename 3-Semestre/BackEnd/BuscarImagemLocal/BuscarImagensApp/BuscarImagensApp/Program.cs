using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
    
    Console.WriteLine("Digite o nome do local que você deseja buscar:");
        string local = Console.ReadLine();

        string urlImagem = await BuscarImagem(local);

        if (!string.IsNullOrEmpty(urlImagem))
        {
            Console.WriteLine($"URL da imagem: {urlImagem}");
        }
        else
        {
            Console.WriteLine("Nenhuma imagem encontrada para esse local.");
        }

        Console.ReadKey();
    }

    static async Task<string> BuscarImagem(string local)
    {
        string API_KEY = "AIzaSyBq-z7CPO-ZwdPQ9oLm6XRz0Dcl6SvZJHw"; // Substitua pela sua chave
        string CX = "876cc24e0e9ba4108"; // Substitua pelo seu ID do motor de pesquisa

        string busca = $"Paisagens de {local}";

        string urlBusca = $"https://www.googleapis.com/customsearch/v1?key={API_KEY}&cx={CX}&q={Uri.EscapeDataString(busca)}&searchType=image";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(urlBusca);

            if (response.IsSuccessStatusCode)
            {
                string conteudoJson = await response.Content.ReadAsStringAsync();
                JObject respostaJson = JsonConvert.DeserializeObject<JObject>(conteudoJson);

                if (respostaJson["items"] != null)
                {
                    JToken item = respostaJson["items"][0]; // Pega o primeiro resultado da pesquisa
                    return item["link"].ToString(); // Retorna a URL da imagem
                }
            }
        }

        return null;
    }
}