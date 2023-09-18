using Microsoft.EntityFrameworkCore;
using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Contexts
{
    //Devemos primeiramente herdar da classe DbContext
    public class InLockContext : DbContext
    {
        /// <summary>
        /// Definição das entidades de dados
        /// </summary>
        //cria as propriedades do tipo DbSet<"Entidade"> para fazer referência ao banco de dados
        //o nome da entidade deve ser o mesmo da tabela
        public DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

        //configuração da string de conexão
        //tem de ser protected para informar que é um método protegido
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //define que será usado o SGBD SqlServer
            //dentro dos parênteses vai a string de conexão com o banco como parâmetro
            //Muda-se o Data Source para Server e o Initial Catalog para Database
            //TrustServerCertificate garante a sertificação do windows para permitir o acesso ao localhost(servidor local)
            //Senai:
            //optionsBuilder.UseSqlServer("Server=NOTE16-S15; Database=inlock_games_CodeFirst_tarde; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true");
            //Casa:
            optionsBuilder.UseSqlServer("Server=NOTEBOOKFAMILIA; Database=inlock_games_CodeFirst; User Id=sa; Pwd=Murilo12$; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        //ao final, após definir a string de conexão devemos abrir o console do NuGet e rodar o comando 'dotnet build' para fazer a conexão com o SqlServer

        //após isso rodamos o comando 'Add-Migration InLockBD' para criar as migrations - mapear todas as entidades do Domain e gerar o banco de dados por código na pasta Migrations

        //após isso rodamos o comando 'Update-Database' para levar as Migrations criadas ao SqlServer e criar o banco de dados com as especificações da Migration criada

        //Para deletar uma migration que deu errado rodamos o código 'Remove-Migration' e em seguida apagamos a pasta Migrations manualmente
    }
}
