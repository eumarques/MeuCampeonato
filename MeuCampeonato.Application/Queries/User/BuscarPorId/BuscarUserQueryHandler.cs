using MediatR;
using MeuCampeonato.Application.ViewModels.User;
using MeuCampeonato.Core.Interface.Repositories;

namespace MeuCampeonato.Application.Queries.User.BuscarPorId
{
    public class BuscarUserQueryHandler : IRequestHandler<BuscarUserQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public BuscarUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(BuscarUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.BuscarPorIdAsync(request.Id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.Id, user.NomeCompleto, user.Email);
        }
    }
}
