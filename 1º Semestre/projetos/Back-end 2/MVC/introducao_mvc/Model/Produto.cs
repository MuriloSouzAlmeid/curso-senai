using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace introducao_mvc.Model
{
    public class Produto
    {
        //Propriedades
        public int Codigo {get;set;}
        public string? Nome {get;set;}
        public float Preco {get;set;}

        //Caminho da pasta e do arquivo .csv
        //PATH(caminho) -> nome da propredade
        private const string PATH = "Database/Produto.csv";

        //Construtor
        public Produto(){
            //Criar a lógica para gerar a pasta e o arquivo

            //Obter o caminhio da pasta
            //Split -> divide uma string apartir de um separador especificado

            //Database/Produto.csv
            //[0] - "Database"
            //[1] - "Produto.csv" 

            string pasta = PATH.Split("/")[0];

            //Verificar se já existe uma pasta
            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }

            //Verfificar se já existe um arquivo
            if(!File.Exists(PATH)){
                File.Create(PATH);
            }
        }

        public Produto(string _codigo, string _nome, string _preco){
            this.Codigo = int.Parse(_codigo);
            this.Nome = _nome;
            this.Preco = float.Parse(_preco);
        }

        //Método que retorna uma lista
        public List<Produto> Ler(){
            //Cria a lista
            List<Produto> produtos = new List<Produto>();

            //Acessa os arquivos e salva suas listas em um array
            string[] linhas = File.ReadAllLines(PATH);

            //Passa por cada item do array (linha) e salva em um objeto
            foreach(string item in linhas){
                //Faz a separação de cada atributo na linha e salva em um outro array
                string[] atributos = item.Split(";");

                //Instancia e adiciona o objeto na lista
                produtos.Add(new Produto(atributos[0], atributos[1], atributos[2]));
            }

            //Retorna a lista
            return produtos;
        }

        //Mátodo para preprar as linhas a serem inseridas no .csv
        public string PrepararLinhasCsv(Produto p){
            return $"{p.Codigo};{p.Nome};{p.Preco}";
        }

        //Inserir um produto na linha do csv
        public void Inserir(Produto p){
            string[] linhas = {this.PrepararLinhasCsv(p)};

            //Adiciona um conteúdo específicado em um caminho específicado
            File.AppendAllLines(PATH, linhas);
        }
    }
}