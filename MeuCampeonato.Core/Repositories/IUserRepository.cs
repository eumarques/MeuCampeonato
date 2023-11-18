using MeuCampeonato.Core.Entities;

namespace MeuCampeonato.Core.Repositories
{
    public interface IUserRepository
    {
        Task AdicionarAsync(User entity);
        Task AtualizarAsync(User entity);
        Task<User> BuscarPorIdAsync(int id);
        Task<List<User>> BuscarTodosAsync();
        Task<User> ObterUsuarioPorEmailESenhaAsync(string email, string senhaHash);
        Task RemoverAsync(int id);
    }
}
