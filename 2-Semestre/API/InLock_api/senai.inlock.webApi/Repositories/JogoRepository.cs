using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositório que implementa os métodos e as regras de negócios da inteface IJogoRepository
    /// </summary>
    public class JogoRepository : IJogoRepository
    {
        public void AtualizarJogoPelaUrl(int id, JogoDomain jogoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarJogoPorCorpo(JogoDomain jogoAtualizado)
        {
            throw new NotImplementedException();
        }

        public JogoDomain BuscarJogoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void CadastrarJogo(JogoDomain novoJogo)
        {
            throw new NotImplementedException();
        }

        public void DeletarJogo(int id)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListarJogos()
        {
            throw new NotImplementedException();
        }
    }
}
