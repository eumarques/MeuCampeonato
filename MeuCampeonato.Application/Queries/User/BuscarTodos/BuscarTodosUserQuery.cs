using MediatR;
using MeuCampeonato.Application.ViewModels.User;

namespace MeuCampeonato.Application.Queries.User.BuscarTodos
{
    public class BuscarTodosUserQuery : IRequest<List<UserViewModel>>
    {
    }
}
