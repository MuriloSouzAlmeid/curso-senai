using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositório que implementa os métodos e as regras de negócios da inteface IEstudioRepository
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        public void AtualizarEstudioPeloCorpo(EstudioDomain estudioAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarEstudioPorUrl(int _id, EstudioDomain estudioAtualizado)
        {
            throw new NotImplementedException();
        }

        public EstudioDomain BuscarEstudioPorId(int _id)
        {
            throw new NotImplementedException();
        }

        public void CadastrarEstudio(EstudioDomain novoEstudio)
        {
            throw new NotImplementedException();
        }

        public void DeletarEstudio(int _id)
        {
            throw new NotImplementedException();
        }

        public List<EstudioDomain> ListarEstudios()
        {
            throw new NotImplementedException();
        }
    }
}
