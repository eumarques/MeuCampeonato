using MeuCampeonato.Core.Entities;
using MeuCampeonato.Core.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeuCampeonato.Infra.Persistence.Repositories
{
    public class CampeonatoRepository : IRepository<Campeonato>
    {
        private readonly MeuCampeonatoDbContext _dbContext;

        public CampeonatoRepository(MeuCampeonatoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarAsync(Campeonato entity)
        {
            await _dbContext.Campeonatos.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Campeonato> BuscarPorIdAsync(int id)
        {
            return await _dbContext.Campeonatos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Campeonato>> BuscarTodosAsync()
        {
            return await _dbContext.Campeonatos.ToListAsync();
        }

        public async Task AtualizarAsync(Campeonato entity)
        {
            _dbContext.Campeonatos.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var entity = await _dbContext.Campeonatos.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Campeonatos.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    
    }
}
