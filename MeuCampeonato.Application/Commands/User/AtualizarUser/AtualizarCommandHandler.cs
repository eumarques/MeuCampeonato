using MediatR;
using MeuCampeonato.Core.Repositories;

namespace MeuCampeonato.Application.Commands.User.AtualizarUser
{
    public class AtualizarCommandHandler : IRequestHandler<AtualizarCommand,Unit>
    {
        private readonly IUserRepository _userRepository;

        public AtualizarCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AtualizarCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.BuscarPorIdAsync(request.Id);

            user.Atualizar(request.Email);

            await _userRepository.AtualizarAsync(user);
            return Unit.Value;
        }
    }
}
