namespace MeuCampeonato.Core.Repositories
{
    public interface IRepository<T>
    {
        Task AdicionarAsync(T entity);
        Task AtualizarAsync(T entity);
        Task RemoverAsync(int id);
        Task<T> BuscarPorIdAsync(int id);
        Task<List<T>> BuscarTodosAsync();
    }
}
