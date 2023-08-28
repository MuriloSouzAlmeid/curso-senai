using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_produtos
{
    public class Produto
    {
        // Atributos
        public string? Codigo { get; set; }
        public string? NomeProduto { get; set; }
        public float Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CadastradoPor { get; set; }

        // Composição
        public Marca? MarcaProduto { get; set; }

        // Listas
        List<Produto> listaDeProdutos = new List<Produto>();

        // Métodos
        public bool CadastarProduto(Produto _produto, string _usuario, Marca _marca)
        {
            Console.WriteLine($"\nInforme o código do produto a ser cadastrado:");
            string _codigo = Console.ReadLine()!;

            bool codigoExiste = false;
            do
            {
                codigoExiste = false;
                foreach (Produto p in listaDeProdutos)
                {
                    if (p.Codigo == _codigo)
                    {
                        codigoExiste = true;
                    }
                }

                if (codigoExiste)
                {
                    Console.WriteLine($"\nO código informado para cadastro já existe.");
                    return false;
                }

            } while (codigoExiste);


            Console.WriteLine($"\nInforme o nome do produto:");
            string _nome = Console.ReadLine()!;

            bool nomeExiste = false;
            do
            {
                codigoExiste = false;
                foreach (Produto p in listaDeProdutos)
                {
                    if (p.NomeProduto == _nome)
                    {
                        nomeExiste = true;
                    }
                }

                if (codigoExiste)
                {
                    Console.WriteLine($"\nO nome informado para produto já existe.");
                    return false;
                }

            } while (nomeExiste);

            Console.WriteLine($"\nInforme o preço do prutoto:");
            string _preco = Console.ReadLine()!;

            bool InformacoesValidas = true;

            if (_codigo == "" || _nome == "" || _preco == "")
            {
                InformacoesValidas = false;
            }

            float numeroResultante = 0;

            try
            {
                float.Parse(_preco);

                numeroResultante = float.Parse(_preco);
            }
            catch (System.Exception)
            {
                InformacoesValidas = false;
            }

            if (InformacoesValidas)
            {
                _produto.Codigo = _codigo;
                _produto.NomeProduto = _nome;
                _produto.Preco = numeroResultante;
                _produto.DataCadastro = DateTime.Now;
                _produto.CadastradoPor = _usuario;


                Console.WriteLine($"");
                Console.WriteLine($"\nSeleção da Marca do Produto:");

                _marca.ListarMarcas();

                bool codigoMarcaExiste = false;
                int codigoMarca = 0;
                string codigoMarcaNova = "";

                if (_marca.ListaDeMarcas().Count == 0)
                {
                    Console.WriteLine($"\nComo não há marcas ainda você terá de cadastrar uma nova.");
                    Console.WriteLine($"Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.WriteLine($"\nCadastro de nova Marca:");
                    Console.WriteLine($"\nInforme o código da marca a ser cadastrada:");
                    codigoMarcaNova = Console.ReadLine()!;
                    if (_marca.Cadastrar(codigoMarcaNova, _usuario))
                    {
                        Console.WriteLine($"\nMarca cadastrada com Sucesso!");
                        codigoMarca = int.Parse(codigoMarcaNova);
                        codigoMarcaExiste = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"\nEscolha Entre:");
                    Console.WriteLine($"\n[1] - Selecionar uma Marca existente");
                    Console.WriteLine($"[2] - Cadastrar uma nova Marca para o produto");
                    string respostaMarca = Console.ReadLine()!;

                    switch (respostaMarca)
                    {
                        case "1":
                            Console.WriteLine($"\nInforme o código da marca do produto");
                            string codigoInformado = Console.ReadLine()!;

                            try
                            {
                                int.Parse(codigoInformado);

                                codigoMarca = int.Parse(codigoInformado);
                            }
                            catch (SystemException)
                            {
                                return false;
                            }

                            foreach (Marca m in _marca.ListaDeMarcas())
                            {
                                if (m.Codigo == codigoMarca)
                                {
                                    codigoMarcaExiste = true;
                                }
                            }
                            break;

                        case "2":
                            Console.WriteLine($"\nCadastro de nova Marca:");
                            Console.WriteLine($"\nInforme o código da marca a ser cadastrada:");
                            codigoMarcaNova = Console.ReadLine()!;
                            if (_marca.Cadastrar(codigoMarcaNova, _usuario))
                            {
                                Console.WriteLine($"\nMarca cadastrada com Sucesso!");
                                codigoMarca = int.Parse(codigoMarcaNova);
                                codigoMarcaExiste = true;
                            }
                            else
                            {
                                return false;
                            }
                            break;

                        default:
                            Console.WriteLine($"\nOpção informada inválida, tente novamente!");
                            respostaMarca = "0";
                            break;
                    }

                    if (respostaMarca == "0")
                    {
                        return false;
                    }
                }

                if (codigoMarcaExiste)
                {
                    Marca marcaSelecionada = _marca.ListaDeMarcas().Find(x => x.Codigo == codigoMarca)!;

                    _produto.MarcaProduto = marcaSelecionada;

                    this.listaDeProdutos.Add(_produto);

                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public void ListarProdutos()
        {
            if (listaDeProdutos.Count == 0)
            {
                Console.WriteLine($"\nAinda não há produtos cadastrados por enquanto.");
            }
            else
            {
                Console.WriteLine($"\nLista de Produtos:");
                foreach (Produto p in listaDeProdutos)
                {
                    Console.WriteLine($"------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Código: {p.Codigo}. Nome: {p.NomeProduto}. Preço: {p.Preco:C2}");
                    Console.WriteLine($"Marca Do Produto: {p.MarcaProduto.NomeMarca}. Código da Marca: {p.MarcaProduto.Codigo}");

                    Console.WriteLine($"Produto cadastrado na {p.DataCadastro:D} por {p.CadastradoPor}. ");

                }
                Console.WriteLine($"-------------------------------------------------------------------------------------------------");
            }
        }

        public string DeletarProduto(string _codigo, Usuario _usuario)
        {
            bool codigoExiste = false;
            foreach (Produto p in listaDeProdutos)
            {
                if (p.Codigo == _codigo)
                {
                    codigoExiste = true;
                }
            }
            if (codigoExiste)
            {
                listaDeProdutos.Remove(listaDeProdutos.Find(x => x.Codigo == _codigo)!);
                Console.WriteLine($"\nProduto Removido com Sucesso!");

                return $"\nProduto Removido com Sucesso!";
            }
            else
            {
                Console.WriteLine($"\nNão existe um produto cadastrado com o código informado, tente novamente!");

                return $"\nNão existe um produto cadastrado com o código informado, tente novamente!";
            }
        }
    }
}