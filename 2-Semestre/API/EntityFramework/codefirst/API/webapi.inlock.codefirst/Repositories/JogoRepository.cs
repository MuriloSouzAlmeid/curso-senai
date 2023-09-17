using Microsoft.EntityFrameworkCore;
using webapi.inlock.codefirst.Contexts;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;

namespace webapi.inlock.codefirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly InLockContext ctx;
        public JogoRepository()
        {
            ctx = new InLockContext();
        }
        public void AtualizarJogoPorId(Guid id, Jogo jogoAtualizado)
        {
            Jogo jogoBuscado = this.BuscarJogoPorId(id);

            jogoBuscado.Nome = jogoAtualizado.Nome;
            jogoBuscado.Descricao = jogoAtualizado.Descricao;
            jogoBuscado.DataLancamento = jogoAtualizado.DataLancamento;
            jogoBuscado.Preco = jogoAtualizado.Preco;
            jogoBuscado.IdEstudio = jogoAtualizado.IdEstudio;

            ctx.Jogo.Update(jogoBuscado);

            ctx.SaveChanges();
        }

        public Jogo BuscarJogoPorId(Guid id)
        {
            Jogo jogoBuscado = ctx.Jogo.Include(j => j.Estudio).FirstOrDefault(j => j.IdJogo == id)!;

            if(jogoBuscado == null)
            {
                return null;
            }
            else
            {
                return jogoBuscado;
            }
        }

        public void CadastrarJogo(Jogo novoJogo)
        {
            ctx.Jogo.Add(novoJogo);
            ctx.SaveChanges();
        }

        public void DeletarJogoPorId(Guid id)
        {
            Jogo jogoBuscado = this.BuscarJogoPorId(id);

            ctx.Jogo.Remove(jogoBuscado);

            ctx.SaveChanges();
        }

        public List<Jogo> ListarJogos()
        {
            return ctx.Jogo.Include(j => j.Estudio).ToList();
        }
    }
}
