using MediatR;
using MeuCampeonato.Application.ViewModels.User;

namespace MeuCampeonato.Application.Queries.User.BuscarPorId
{
    public class BuscarUserQuery : IRequest<UserViewModel>
    {
        public BuscarUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
