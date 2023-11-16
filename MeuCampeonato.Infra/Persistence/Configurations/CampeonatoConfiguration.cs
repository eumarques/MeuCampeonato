using MeuCampeonato.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCampeonato.Infra.Persistence.Configurations
{
    public class CampeonatoConfiguration : IEntityTypeConfiguration<Campeonato>
    {
        public void Configure(EntityTypeBuilder<Campeonato> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(e => e.Id).HasColumnName("CampeonatoId");
            builder.Property(e => e.NomeComapeonato).HasColumnName("NomeComapeonato");
            builder.Property(e => e.DataCampeonato).HasColumnName("DataCampeonato");
            builder.Property(e => e.PrimeiroLugar).HasColumnName("PrimeiroLugar");
            builder.Property(e => e.SegundoLugar).HasColumnName("SegundoLugar");
            builder.Property(e => e.TerceiroLugar).HasColumnName("TerceiroLugar");
            builder.Property(e => e.QuantoLugar).HasColumnName("QuantoLugar");
        }
    }
}
