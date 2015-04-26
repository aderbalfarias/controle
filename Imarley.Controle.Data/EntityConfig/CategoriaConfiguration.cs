using Imarley.Controle.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Imarley.Controle.Data.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            ToTable("Categorias");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("CategoriaId")
                .HasColumnType("int");

            Property(x => x.Nome).HasColumnName("Nome")
                .IsRequired();

        }
    }   
}
