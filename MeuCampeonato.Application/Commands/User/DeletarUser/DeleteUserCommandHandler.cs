using MediatR;
using MeuCampeonato.Core.Interface.Repositories;

namespace MeuCampeonato.Application.Commands.User.DeletarUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.BuscarPorIdAsync(request.Id);

            await _userRepository.RemoverAsync(user.Id);

            return Unit.Value;
        }
    }
}
