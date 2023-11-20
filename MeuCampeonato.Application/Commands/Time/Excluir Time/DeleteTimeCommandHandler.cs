using MediatR;
using MeuCampeonato.Core.Interface.Repositories;

namespace MeuCampeonato.Application.Commands.Time.Excluir_Time
{
    public class DeleteTimeCommandHandler : IRequestHandler<DeleteTimeCommand,Unit>
    {
        private readonly IRepository<Core.Entities.Time> _timeRepository;

        public DeleteTimeCommandHandler(IRepository<Core.Entities.Time> timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<Unit> Handle(DeleteTimeCommand request, CancellationToken cancellationToken)
        {
            var time = await _timeRepository.BuscarPorIdAsync(request.Id);

            await _timeRepository.RemoverAsync(request.Id);
            return Unit.Value;
        }
    }
}
