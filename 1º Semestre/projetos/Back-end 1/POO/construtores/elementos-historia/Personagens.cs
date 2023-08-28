using System;

namespace Personagens{
    public class Protagonistas{
        // Atributos
        public string nome;
        public int idade;
        public string habilidades;

        // Construtor
        public Protagonistas(string nomeInformado, int idadeInformada, string habilidadesInformadas){
            nome = nomeInformado;
            idade = idadeInformada;
            habilidades = habilidadesInformadas;
        }
    }

    public class Antagonistas{
        public string nome;
        public int idade;
        public string habilidades;

        // Construtor
        public Antagonistas(string nomeInformado, int idadeInformada, string habilidadesInformadas){
            nome = nomeInformado;
            idade = idadeInformada;
            habilidades = habilidadesInformadas;
        }
    }
}