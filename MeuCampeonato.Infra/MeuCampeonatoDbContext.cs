using MeuCampeonato.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MeuCampeonato.Infra
{
    public class MeuCampeonatoDbContext : DbContext
    {
        public MeuCampeonatoDbContext(DbContextOptions<MeuCampeonatoDbContext> options) : base(options)
        {
        }

        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
