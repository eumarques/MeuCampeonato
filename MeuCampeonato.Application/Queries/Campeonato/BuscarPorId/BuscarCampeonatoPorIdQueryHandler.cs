using MediatR;
using MeuCampeonato.Application.ViewModels.Campeonato;
using MeuCampeonato.Core.Repositories;

namespace MeuCampeonato.Application.Queries.Campeonato.BuscarPorId
{
    public class BuscarCampeonatoPorIdQueryHandler : IRequestHandler<BuscarCampeonatoPorIdQuery, CampeonatoViewModel>
    {
        private readonly IRepository<Core.Entities.Campeonato> _campeonatoRepository;

        public BuscarCampeonatoPorIdQueryHandler(IRepository<Core.Entities.Campeonato> campeonatoRepository)
        {
            _campeonatoRepository = campeonatoRepository;
        }

        public async Task<CampeonatoViewModel> Handle(BuscarCampeonatoPorIdQuery request, CancellationToken cancellationToken)
        {
            var campeonato = await _campeonatoRepository.BuscarPorIdAsync(request.Id);

            if (campeonato == null)
            {
                return null;
            }

            var campeonatoViewModel = new CampeonatoViewModel(campeonato.Id, campeonato.NomeComapeonato, campeonato.DataCampeonato, campeonato.PrimeiroLugar
                , campeonato.SegundoLugar, campeonato.TerceiroLugar, campeonato.QuantoLugar);

            return campeonatoViewModel;
        }
    }
}
