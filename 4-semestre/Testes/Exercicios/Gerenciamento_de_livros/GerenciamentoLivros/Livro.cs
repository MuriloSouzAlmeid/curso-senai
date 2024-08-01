using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoLivros
{
    public class Livro
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Autor {  get; set; }
        public string Sinopse { get; set; }
        public int AnoLancamento { get; set; }


        public static void AdicionarLivro(List<Livro> lista, Livro livro)
        {
            lista.Add(livro);
        }
    }
}
