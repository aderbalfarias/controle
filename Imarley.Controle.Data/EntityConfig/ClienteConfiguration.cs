using Imarley.Controle.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Imarley.Controle.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("Clientes");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ClienteId")
                .HasColumnType("int");

            Property(x => x.Nome).HasColumnName("Nome")
                .IsRequired();

            Property(x => x.Email).HasColumnName("Email")
                .IsRequired();

            Property(x => x.Telefone).HasColumnName("Telefone")
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.Celular).HasColumnName("Celular")
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.Endereco).HasColumnName("Endereco")
                .IsRequired();

            Property(x => x.Descricao).HasColumnName("Descricao")
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(x => x.Status);

            HasRequired(x => x.Categoria);

        }
    }
}
