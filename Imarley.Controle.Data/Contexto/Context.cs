using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Imarley.Controle.Domain.Entities;
using Imarley.Controle.Data.EntityConfig;

namespace Imarley.Controle.Data.Contexto
{
    public class Context : DbContext
    {
        public Context()
            : base("Context")
        {
        }
        public void CriarBanco()
        {
            Database.Create();
        }

        public void ExcluirBanco()
        {
            Database.Delete();
        }

        public DbSet<Status> Status { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            // Configuração padrão dos campos string
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Properties<decimal>()
                .Configure(p => p.HasPrecision(10, 2));


            //Configuração das tabelas
            modelBuilder.Configurations.Add(new StatusConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());

        }

        public class ContextCustomInitializer : IDatabaseInitializer<Context>
        {
            public void InitializeDatabase(Context context)
            {

                if (!context.Database.Exists())
                {

                    context.Database.Create();

                    IList<Status> status = new List<Status>
                    {
                        new Status {Id = 1, Nome = "Lead"},
                        new Status {Id = 2, Nome = "Cliente"},
                        new Status {Id = 3, Nome = "Fornecedor"},
                        new Status {Id = 4, Nome = "Inativo"}
                    };

                    foreach (var item in status)
                    {
                        context.Status.Add(item);
                    }


                    IList<Categoria> categorias = new List<Categoria>
                    {
                        new Categoria {Id = 1, Nome = "Fornecedores"},
                        new Categoria {Id = 2, Nome = "Clientes Adwords"},
                        new Categoria {Id = 3, Nome = "Prospecção Adwords"},
                        new Categoria {Id = 4, Nome = "Clientes Web"}
                    };

                    foreach (var item in categorias)
                    {
                        context.Categorias.Add(item);
                    }

                    context.SaveChanges();

                }
            }

        }

    }

}