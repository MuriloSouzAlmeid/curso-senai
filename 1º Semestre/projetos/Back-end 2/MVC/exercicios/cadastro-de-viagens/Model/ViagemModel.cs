using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_de_viagens.Model
{
    public class ViagemModel
    {
        public string? Nome {get;set;}
        public string? Descricao {get;set;}
        public DateTime DataEvento {get;set;}
        private const string PATH = "Database/Viagens.csv";

        public ViagemModel(){
            //             Retorna um Array
            string pasta = PATH.Split("/")[0];

            // Verifica a existência de uma pasta 
            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }

            if(!File.Exists(PATH)){
                File.Create(PATH);
            }
        }

        public ViagemModel(string _nome, string _descricao, string _ano, string _mes, string _dia, string _horario){
            this.Nome = _nome;
            this.Descricao = _descricao;
            int anoInformado = int.Parse(_ano);
            int mesInformado = int.Parse(_mes);
            int diaInformado = int.Parse(_dia);

            int horaInformada = int.Parse(_horario.Split(":")[0]);
            int minutoInformado = int.Parse(_horario.Split(":")[1]);
            this.DataEvento = new DateTime(anoInformado, mesInformado, diaInformado, horaInformada, minutoInformado, 0);
        }

        public List<ViagemModel> GerarListaViagens(){
            List<ViagemModel> listaDeViagens = new List<ViagemModel>();

            string[] elementosLista = File.ReadAllLines(PATH);


            foreach(string linha in elementosLista){
                string[] atributos = linha.Split(";");
                string atributoHora = $"{atributos[5]}:{atributos[6]}";
                listaDeViagens.Add(new ViagemModel(atributos[0], atributos[1], atributos[2], atributos[3], atributos[4], atributoHora));
            }

            return listaDeViagens;
        }

        public string PrepararLinha(ViagemModel evento){
            return $"{evento.Nome};{evento.Descricao};{evento.DataEvento.Year};{evento.DataEvento.Month};{evento.DataEvento.Day};{evento.DataEvento.Hour};{evento.DataEvento.Minute}";
        }

        public void AdicionarAoCsv(ViagemModel v){
            string[] linhas = {this.PrepararLinha(v)};

            File.AppendAllLines(PATH, linhas);
        }
    }
}