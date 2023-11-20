using MediatR;
using MeuCampeonato.Core.Interface.Repositories;

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
            var campeonato = new Core.Entities.Campeonato(request.nomeCompeonato);

            var allTime = new List<Core.Entities.Time>(request.Times);

            var oitoTimesAleatorios = campeonato.ColocarTimesEmAleatorios(allTime);

            var timesParaSemiFinal = campeonato.SimularJogos(oitoTimesAleatorios, 4, oitoTimesAleatorios.Count, false);
            var final = campeonato.SimularJogos(timesParaSemiFinal, 2, timesParaSemiFinal.Count, true);
            campeonato.DefinirPosicaoPrimeiroSegundo(campeonato, final[0], final[1]);
            campeonato.DefinirPosicaoTerceiroQuarto(campeonato, final[2], final[3]);

            await _campeonatoRepository.AdicionarAsync(campeonato);

            return campeonato.Id;
        }
    }
}
