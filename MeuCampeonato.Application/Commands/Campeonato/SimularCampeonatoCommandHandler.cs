using MediatR;
using MeuCampeonato.Core.Repositories;

namespace MeuCampeonato.Application.Commands.Campeonato
{
    public class SimularCampeonatoCommandHandler : IRequestHandler<SimularCampeonatoCommand, int>
    {
        private readonly IRepository<Core.Entities.Time> _timeRepository;
        private readonly IRepository<Core.Entities.Campeonato> _campeonatoRepository;

        public SimularCampeonatoCommandHandler(IRepository<Core.Entities.Time> timeRepository, IRepository<Core.Entities.Campeonato> campeonatoRepository)
        {
            _timeRepository = timeRepository;
            _campeonatoRepository = campeonatoRepository;
        }

        public async Task<int> Handle(SimularCampeonatoCommand request, CancellationToken cancellationToken)
        {
            var campeonato = new Core.Entities.Campeonato();

            var allTime = await _timeRepository.BuscarTodosAsync();
            

            return campeonato.Id;
        }
    }
}
