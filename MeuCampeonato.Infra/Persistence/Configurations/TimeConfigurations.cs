using MeuCampeonato.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MeuCampeonato.Infra.Persistence.Configurations
{
    public class TimeConfigurations : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(e => e.Id).HasColumnName("TimeId");
            builder.Property(e => e.NomeTime).HasColumnName("NomeTime");
            builder.Property(e => e.Pontuacao).HasColumnName("Pontuacao");
            builder.Property(e => e.DataInscricao).HasColumnName("DataInscricao");
        }
    }

}

