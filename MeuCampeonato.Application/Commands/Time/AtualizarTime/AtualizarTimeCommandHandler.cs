using MediatR;
using MeuCampeonato.Core.Repositories;

namespace MeuCampeonato.Application.Commands.Time.AtualizarTime
{
    public class AtualizarTimeCommandHandler : IRequestHandler<AtualizarTimeCommand, Unit>
    {
        private readonly IRepository<Core.Entities.Time> _timeRepository;

        public AtualizarTimeCommandHandler(IRepository<Core.Entities.Time> timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<Unit> Handle(AtualizarTimeCommand request, CancellationToken cancellationToken)
        {
            var time = await _timeRepository.BuscarPorIdAsync(request.Id);

            time.AtualizarNome(request.NameTime);

            await _timeRepository.AtualizarAsync(time);

            return Unit.Value;
        }
    }
}
