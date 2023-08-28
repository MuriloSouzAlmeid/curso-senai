//Possui o acesso ao banco de dados
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamer_fullstack.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_fullstack.infra
{
    public class Context : DbContext
    {
        public Context(){

        }

        public Context(DbContextOptions<Context> options): base(options){
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Se OptionsBuilder estiver ou não configurado
            if(!optionsBuilder.IsConfigured){
                //A parte mais importante - Conexão com o banco de dados
                //Logando com o usuário padrão do Windowns (Integrated Security = true;)
                //Escolhendo um usuário em específico (User Id = nome do usuário; pwd= senha do usuário)
                optionsBuilder.UseSqlServer("Data Source = NOTE09-S14; initial catalog = projetoGamer; User Id = sa; pwd=Senai@134; TrustServerCertificate = true");
                // optionsBuilder.UseSqlServer("Data Source = NOTE09-S14; initial catalog = projetoGamer; User Id = sa; pwd=Senai@134; TrustServerCertificate = true"); - Escola
                // optionsBuilder.UseSqlServer("Data Source = NOTEBOOKFAMILIA; initial catalog = projetoGamer; Integrated Security = true; User Id = sa; pwd=Murilo12$; TrustServerCertificate = true"); - Casa 
            }
        }

        public DbSet<Jogador> Jogador {get;set;}
        public DbSet<Equipe> Equipe {get;set;}
    }
}