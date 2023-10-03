using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webapi.health.clinic.project.Contexts;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;

namespace webapi.health.clinic.project.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext ctx;
        public MedicoRepository()
        {
            this.ctx = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Medico medicoAtualizado)
        {
            try
            {
                Medico medicoBuscado = this.BuscarPorId(id);

                medicoBuscado.CRM = medicoAtualizado.CRM;
                medicoBuscado.EstadoCRM = medicoAtualizado.EstadoCRM;
                medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;
                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;

                ctx.Medico.Update(medicoBuscado);

                ctx.SaveChanges();
            }catch(Exception)
            {
                throw;
            }
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                Medico medicoBuscado = ctx.Medico.Include(m => m.Especialidade).Include(e => e.Usuario).FirstOrDefault(m => m.IdMedico == id)!;

                if(medicoBuscado == null)
                {
                    return null;
                }

                return medicoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Medico novoMedico)
        {
            try
            {
                ctx.Medico.Add(novoMedico);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Medico> Listar()
        {
            try
            {
                List<Medico> listaDeMedicos = ctx.Medico.Include(e => e.Especialidade).Include(e => e.Usuario).ToList();

                return listaDeMedicos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
