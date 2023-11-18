using MediatR;
using MeuCampeonato.Application.ViewModels.User;
using MeuCampeonato.Core.Entities;
using MeuCampeonato.Core.Repositories;

namespace MeuCampeonato.Application.Queries.User.BuscarTodos
{
    public class BuscarTodosUserQueryHandler : IRequestHandler<BuscarTodosUserQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public BuscarTodosUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(BuscarTodosUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.BuscarTodosAsync();

            if (!users.Any() == null)
            {
                return null;
            }

            var userViewModel = users.Select(x => new UserViewModel(x.Id, x.NomeCompleto, x.Email)).ToList();

            return userViewModel;
        }
    }
}
