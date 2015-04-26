using Imarley.Controle.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Imarley.Controle.Data.EntityConfig
{
    public class StatusConfiguration : EntityTypeConfiguration<Status>
    {
        public StatusConfiguration()
        {
            ToTable("Status");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("StatusId")
                .HasColumnType("int");

            Property(x => x.Nome).HasColumnName("Nome")
                .IsRequired();

        }
    }
}
