using MediatR;
using MeuCampeonato.Application.ViewModels.Campeonato;
using MeuCampeonato.Core.Interface.Repositories;

namespace MeuCampeonato.Application.Queries.Campeonato.BuscarTodos
{
    public class BuscarTodosCampeonatoQueryHandler : IRequestHandler<BuscarTodosCampeonatoQuery, List<CampeonatoViewModel>>
    {
        private readonly IRepository<Core.Entities.Campeonato> _campeonatoRepository;

        public BuscarTodosCampeonatoQueryHandler(IRepository<Core.Entities.Campeonato> campeonatoRepository)
        {
            _campeonatoRepository = campeonatoRepository;
        }

        public async Task<List<CampeonatoViewModel>> Handle(BuscarTodosCampeonatoQuery request, CancellationToken cancellationToken)
        {
            var campeonato = await _campeonatoRepository.BuscarTodosAsync();

            var campeonatoViewModel = campeonato.Select(x => new CampeonatoViewModel(x.Id, x.NomeComapeonato, x.DataCampeonato,
                x.PrimeiroLugar, x.SegundoLugar, x.TerceiroLugar, x.QuantoLugar)).ToList();

            return campeonatoViewModel;
        }
    }
}
