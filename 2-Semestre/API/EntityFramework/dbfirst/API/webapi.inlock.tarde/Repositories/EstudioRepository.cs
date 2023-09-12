using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
{
    /// <summary>
    /// Repositório que implementa os métodos da interface IEstudioRepository e chama a Context para lidar com as querys no banco de dados
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        //instancia um objeto da classe context para ter acesso aos seus métodos
        InLockContext ctx = new InLockContext();

        public void Atualizar(Guid id, Estudio estudioAtualizado)
        {
            throw new NotImplementedException();
        }

        public Estudio BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadatrar(Estudio novoEstudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Estudio> Listar()
        {
            //através do context iremos acessar a tabela estudio e listar o que há no banco de dados (SELECT *)
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            //trás todos os estúdios incluídos com seus jogos por meio da função include e da expressão lambda onde o estúdio representado pela variável e contem a sua própria coleção de jogos dentro de si e por isso acessamos o e.Jogos e no final listamos com o ToList(). 
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
