using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
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
            Estudio estudioBuscado = BuscarPorId(id);

            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudioAtualizado.Nome;
            }

            //atualiza o estúdio com o id do esúdio passado como parâmetro e com as informações contidas nele 
            ctx.Estudios.Update(estudioBuscado!);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            //usa-se a expressão lâmbda pois é o método FirstOrDeafeult
            //usa-se o FirstOrDefault para que retorne null caso não seja encontrado
            Estudio estudioBuscado = ctx.Estudios.Include(e => e.Jogos).FirstOrDefault(e => e.IdEstudio == id)!;

            if (estudioBuscado != null)
            {
                return estudioBuscado;
            }
            else
            {
                return null;
            }
        }

        public void Cadatrar(Estudio novoEstudio)
        {
            //acessa a atabela Estudio e cadastra um novo estúdio com as informações contidas no objeto recebido como parâmetro
            ctx.Estudios.Add(novoEstudio);

            //salva as alterações no banco de daados sempre que tem uma alteração em registros (DML)
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            //acessa a tabela Estudio e busca um registro com o método Find passando como parâmetro o id do estúdio a ser buscado em seguida guarda o estúdio buscado em um objeto do tipo Estudio
            Estudio estudioBuscado = ctx.Estudios.Find(id)!;

            //verifica se existe um registro no banco de dados com o id informado, no caso se o objeto~tiver algo dentro - não for nulo
            if (estudioBuscado != null)
            {
                //acessa a tabela Estudio e remove o estúdio com as informações do objeto passado como parâmetro
                ctx.Estudios.Remove(estudioBuscado);
            }

            //salva as alterações no banco de dados toda vez que mexe com dados registrados (DML)
            ctx.SaveChanges();
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
