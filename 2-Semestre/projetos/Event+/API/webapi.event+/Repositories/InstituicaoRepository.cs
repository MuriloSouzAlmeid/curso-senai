using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext ctx;
        public InstituicaoRepository()
        {
            ctx = new EventContext();
        }
        public void AtualizarInstituicao(Guid id, Instituicao instituicaoAtualizada)
        {
            try
            {
                Instituicao instituicao = this.BuscarInstituicao(id);

                instituicao.CNPJ = instituicaoAtualizada.CNPJ;
                instituicao.NomeFantasia = instituicaoAtualizada.NomeFantasia;
                instituicao.Endereco = instituicaoAtualizada.Endereco;

                ctx.Instituicao.Update(instituicao);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Instituicao BuscarInstituicao(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = ctx.Instituicao.FirstOrDefault(i => i.IdInstituicao == id)!;

                if (instituicaoBuscada != null)
                {
                    return instituicaoBuscada;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Instituicao novaInstituicao)
        {
            try
            {
                ctx.Instituicao.Add(novaInstituicao);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletarInstituicao(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = this.BuscarInstituicao(id);

                ctx.Instituicao.Remove(instituicaoBuscada);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Instituicao> ListarInstituicoes()
        {
            try
            {
                List<Instituicao> listaDeInstituicao = ctx.Instituicao.ToList();

                return listaDeInstituicao;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
