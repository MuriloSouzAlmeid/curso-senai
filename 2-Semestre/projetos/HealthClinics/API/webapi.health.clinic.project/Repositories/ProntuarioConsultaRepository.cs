using Microsoft.EntityFrameworkCore;
using webapi.health.clinic.project.Contexts;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;

namespace webapi.health.clinic.project.Repositories
{
    public class ProntuarioConsultaRepository : IProntuarioConsultaRepository
    {
        private readonly HealthClinicContext ctx;
        public ProntuarioConsultaRepository()
        {
            this.ctx = new HealthClinicContext();
        }

        public void Atualizar(Guid id, ProntuarioConsulta prontuarioAtualizado)
        {
            try
            {
                ProntuarioConsulta prontuarioBuscado = this.BuscarPorId(id);

                prontuarioBuscado.Descricao = prontuarioAtualizado.Descricao;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProntuarioConsulta BuscarPorId(Guid id)
        {
            try
            {
                ProntuarioConsulta prontuarioBuscado = ctx.ProntuarioConsulta.FirstOrDefault(p => p.IdProntuario == id)!;

                if(prontuarioBuscado == null)
                {
                    return null;
                }

                return prontuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ProntuarioConsulta novoProntuario)
        {
            try
            {
                ctx.ProntuarioConsulta.Add(novoProntuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
