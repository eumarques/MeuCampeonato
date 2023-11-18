using MediatR;
using MeuCampeonato.Application.Services;
using MeuCampeonato.Application.ViewModels.User;
using MeuCampeonato.Core.Repositories;

namespace MeuCampeonato.Application.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);


            var user = await _userRepository.ObterUsuarioPorEmailESenhaAsync(request.Email, passwordHash);


            if (user == null)
            {
                return null;
            }


            var token = _authService.GenerateJwtToken(user.Email, user.Funcao);

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
