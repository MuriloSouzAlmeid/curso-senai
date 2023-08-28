using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_produtos
{
    public class Marca
    {
        // Atributos
        public int Codigo { get; set; }
        public string? NomeMarca { get; set; }
        public DateTime DataCadastro { get; set; }

        public string CadastradoPor {get;set;}

        List<Marca> listaDeMarcas = new List<Marca>();

        public Marca() { }

        public Marca(int _codigo, string _nome, string _usuario)
        {
            this.Codigo = _codigo;
            this.NomeMarca = _nome;
            this.DataCadastro = DateTime.Now;
            this.CadastradoPor = _usuario;
        }

        // Métodos
        public bool Cadastrar(string _codigoInformado, string _usuario)
        {
            bool codigoExiste = false;
            foreach (Marca m in this.listaDeMarcas)
            {
                if (_codigoInformado == m.Codigo.ToString())
                {
                    codigoExiste = true;
                }
            }

            if (codigoExiste)
            {
                Console.WriteLine($"\nO código informado já foi cadastrado anteriormente!");
                return false;
            }

            int codigoResultante;

            try
            {
                int.Parse(_codigoInformado);

                codigoResultante = int.Parse(_codigoInformado);
            }
            catch (SystemException)
            {
                Console.WriteLine($"\nInforme a marca em formato numérico.");

                return false;
            }

            Console.WriteLine($"\nInforme o nome da marca a ser cadastrada:");
            string nomeInformado = Console.ReadLine()!;

            listaDeMarcas.Add(
                new Marca(codigoResultante, nomeInformado, _usuario)
            );

            if (listaDeMarcas.Count > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"\nErro ao cadastrar a marca, tente novamente.");
                return false;
            }
        }
        public void ListarMarcas()
        {
            if (this.listaDeMarcas.Count == 0)
            {
                Console.WriteLine($"\nNão há marcas cadastradas ainda.");
            }
            else
            {
                Console.WriteLine($"\nLista de Marcas Cadastradas");
                foreach (Marca m in this.listaDeMarcas)
                {
                    Console.WriteLine($"---------------------------------------------------------------------");
                    Console.WriteLine($"Código: {m.Codigo}  Nome: {m.NomeMarca}");
                    Console.WriteLine($"Marca cadastrada {m.DataCadastro:D} por {m.CadastradoPor}.");

                }
                Console.WriteLine($"---------------------------------------------------------------------");
            }
        }

        public List<Marca> ListaDeMarcas()
        {
            return this.listaDeMarcas;
        }

        public bool DeletarMarca()
        {
            Console.WriteLine($"\nInforme o código da marca a ser removida:");
            string codigoInformado = Console.ReadLine()!;

            int codigoResultante;

            try
            {
                int.Parse(codigoInformado);

                codigoResultante = int.Parse(codigoInformado);
            }
            catch (SystemException)
            {
                Console.WriteLine($"\nInforme o código em formato numérico.");
                return false;
            }

            Marca marcaBuscada = this.listaDeMarcas.FirstOrDefault(x => x.Codigo == codigoResultante)!;

            if (marcaBuscada == null)
            {
                Console.WriteLine($"\nA marca com o código informado não foi encontrada.");
                return false;
            }
            else
            {
                this.listaDeMarcas.Remove(marcaBuscada);
                return true;
            }
        }
    }
}