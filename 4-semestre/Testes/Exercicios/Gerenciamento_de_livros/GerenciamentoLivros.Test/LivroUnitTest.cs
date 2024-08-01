using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoLivros.Test
{
    public class LivroUnitTest
    {
        [Fact]
        public void TesteParaAdicionarLivrosEmUmaLista()
        {
            List<Livro> listaDeLivros = new List<Livro>();

            Livro livro = new Livro()
            {
                Titulo = "A Tormenta de Espadas",
                Autor = "George R. R. Martin",
                Sinopse = "O futuro de Westeros está em jogo, e ninguém descansará até que os Sete Reinos tenham explodido em uma verdadeira tormenta de espadas.\r\n\r\nDos cinco pretendentes ao trono, um está morto e outro caiu em desgraça, e ainda assim a guerra continua em toda sua fúria, enquanto alianças são feitas e desfeitas. Joffrey, da Casa Lannister, ocupa o Trono de Ferro, como o instável governante dos Sete Reinos, ao passo que seu rival mais amargo, lorde Stannis, jaz derrotado e enfeitiçado pelas promessas da Mulher Vermelha.\r\n\r\nO jovem Robb, da Casa Stark, ainda comanda o Norte, contudo, e planeja sua batalha contra os Lannister, mesmo que sua irmã seja refém deles em Porto Real. Enquanto isso, Daenerys Targaryen atravessa um continente deixando um rastro de sangue a caminho de Westeros, levando consigo os três únicos dragões existentes em todo o mundo.\r\n\r\nEnquanto forças opostas avançam para uma gigantesca batalha final, um exército de selvagens chega dos confins da civilização. Em seu rastro vem uma horda de terríveis criaturas místicas - os Outros: um batalhão de mortos-vivos cujos corpos são imparáveis.\r\n\r\n\"Eu sempre espero o melhor de George R. R. Martin, e ele sempre entrega.\" -- Robert Jordan, autor de A roda do tempo",
                AnoLancamento = 2000
            };

            Livro.AdicionarLivro(listaDeLivros, livro);

            Assert.True(listaDeLivros.Contains(livro));
        }
    }
}
