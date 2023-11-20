using MediatR;
using MeuCampeonato.Application.Services;
using MeuCampeonato.Core.Interface.Repositories;
using UserEntity = MeuCampeonato.Core.Entities.User;


namespace MeuCampeonato.Application.Commands.User.CriarUser
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, int>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public CriarUsuarioCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            var user = new UserEntity(request.NomeCompleto, request.Email, request.DataNascimento, passwordHash, request.Funcao);

            await _userRepository.AdicionarAsync(user);
            return user.Id;
        }
    }
}
