using Microsoft.EntityFrameworkCore;
using webapi.inlock.codefirst.Contexts;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;

namespace webapi.inlock.codefirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //objeto da classe context
        private readonly InLockContext ctx;

        //construtor que atribui os métodos da context ao seu objeto
        public EstudioRepository()
        {
            ctx = new InLockContext();
        }
        public void AtualizarEstudio(Guid id, Estudio estudioAtualizado)
        {
            Estudio estudioBuscado = this.BuscarEstudioPorId(id);

            estudioBuscado.Nome = estudioAtualizado.Nome;

            ctx.Estudio.Update(estudioBuscado);

            ctx.SaveChanges();
        }

        public Estudio BuscarEstudioPorId(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudio.Include(e => e.Jogo).FirstOrDefault(e => e.IdEstudio == id)!;
            if (estudioBuscado == null)
            {
                return null;
            }
            return estudioBuscado;
        }

        public void CadastarEstudio(Estudio novoEstudio)
        {
            ctx.Estudio.Add(novoEstudio);

            ctx.SaveChanges();
        }

        public void DeletarEsudio(Guid id)
        {
            Estudio estudioBuscado = this.BuscarEstudioPorId(id);

            ctx.Estudio.Remove(estudioBuscado);

            ctx.SaveChanges();
        }

        public List<Estudio> ListarEstudios()
        {
            return ctx.Estudio.Include(e => e.Jogo).ToList();
        }
    }
}
