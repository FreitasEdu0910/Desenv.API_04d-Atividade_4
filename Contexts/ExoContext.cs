using Exo.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Exo.WebApi.Contexts
    {
        public class ExoContext : DbContext
        {
            public ExoContext()
            { 
            }
            public ExoContext(DbContextOptions<ExoContext> options) : 
            base(options)
            {
            }
            protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
            {

                if(!optionsBuilder.IsConfigured)
                {
                    // Essa string de conexão depende da SUA máquina.
                    optionsBuilder.UseSqlServer
                    (

                       //"Server=Nome_do_Servidor_no_SSMS:
                        "Server=localhost\\SQLEXPRESS;"
                        + "User ID = sa;" 
                        + "Password = 1234;"
                        + "Database=ExoApi;" 
                        + "Trusted_Connection=False;"
                        //Caso dê erro de autenticação, utilizar a linha abaixo:
                        // + "TrustServerCertificate=true"

                    );

                    /*
                    //Exemplo 1 de string de conexão (com autenticação):
                    "Server=localhost;"
                    + "User ID=sa;"
                    + "Password=admin;" 
                    + "Database=ExoApi;"
                    + "Trusted_Connection=False"
                    //Caso dê erro de autenticação, utilizar a linha abaixo:
                    + "TrustServerCertificate=true"

                    // Exemplo 2 de string de conexão:
                    Server=localhost\\SQLEXPRESS;Database=ExoApi;Trusted_Connection=True;
                    */
                }
            }

            public DbSet<Projeto> Projetos { get; set; }
        }
    }
