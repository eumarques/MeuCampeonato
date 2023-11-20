using MediatR;
using MeuCampeonato.Core.Interface.Repositories;

namespace MeuCampeonato.Application.Commands.Time.CriarTime
{
    public class CriarTimeCommandHandler : IRequestHandler<CriarTimeCommand,int>
    {
        private readonly IRepository<Core.Entities.Time> _timeRepository;

        public CriarTimeCommandHandler(IRepository<Core.Entities.Time> timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<int> Handle(CriarTimeCommand request, CancellationToken cancellationToken)
        {
            var time = new Core.Entities.Time(request.NomeTime);

            await _timeRepository.AdicionarAsync(time);

            return time.Id;
        }
    }
}
