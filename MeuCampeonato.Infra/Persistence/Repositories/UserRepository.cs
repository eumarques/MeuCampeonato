﻿using MeuCampeonato.Core.Entities;
using MeuCampeonato.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeuCampeonato.Infra.Persistence.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly MeuCampeonatoDbContext _dbContext;

        public UserRepository(MeuCampeonatoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var entity = await _dbContext.Users.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Users.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<User> BuscarPorIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> BuscarTodosAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}