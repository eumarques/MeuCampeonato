using MeuCampeonato.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MeuCampeonato.Infra.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .HasKey(s => s.Id);

            builder.Property(e => e.Id).HasColumnName("UsuarioId");
            builder.Property(e => e.NomeCompleto).HasColumnName("NomeCompleto");
            builder.Property(e => e.Email).HasColumnName("Email");
            builder.Property(e => e.DataNascimento).HasColumnName("DataNascimento");
            builder.Property(e => e.Ativo).HasColumnName("Ativo");
            builder.Property(e => e.Senha).HasColumnName("Senha");
            builder.Property(e => e.Funcao).HasColumnName("Funcao");
        }
    }
}
