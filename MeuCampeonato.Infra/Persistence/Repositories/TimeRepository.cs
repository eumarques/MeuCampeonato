using MeuCampeonato.Core.Entities;
using MeuCampeonato.Core.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeuCampeonato.Infra.Persistence.Repositories
{
    public class TimeRepository : IRepository<Time>
    {
        private readonly MeuCampeonatoDbContext _dbContext;

        public TimeRepository(MeuCampeonatoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarAsync(Time entity)
        {
            await _dbContext.Times.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Time> BuscarPorIdAsync(int id)
        {
            return await _dbContext.Times.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Time>> BuscarTodosAsync()
        {
            return await _dbContext.Times.ToListAsync();
        }

        public async Task AtualizarAsync(Time entity)
        {
            _dbContext.Times.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var entity = await _dbContext.Times.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _dbContext.Times.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
