using webapi.health.clinic.project.Contexts;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;

namespace webapi.health.clinic.project.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext ctx;
        public ClinicaRepository()
        {
            ctx = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = this.BuscarPorId(id);

            clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
            clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            clinicaBuscada.CNPJ = clinicaAtualizada.CNPJ;
            clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            clinicaBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;
            clinicaBuscada.HorarioEncerramento = clinicaAtualizada.HorarioEncerramento;

            ctx.Clinica.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = ctx.Clinica.FirstOrDefault(c => c.IdClinica == id)!;

                if (clinicaBuscada == null)
                {
                    return null;
                }

                return clinicaBuscada;
            }catch(Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Clinica novaClinica)
        {
            try
            {
                ctx.Clinica.Add(novaClinica);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = this.BuscarPorId(id);

                ctx.Clinica.Remove(clinicaBuscada);

                ctx.SaveChanges();
            }catch(Exception)
            {
                throw;
            }
        }

        public List<Clinica> Listar()
        {
            try
            {
                List<Clinica> lista = ctx.Clinica.ToList();

                return lista;
            }catch(Exception)
            {
                throw;
            }
        }
    }
}
