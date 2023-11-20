using MediatR;
using MeuCampeonato.Application.ViewModels.Time;
using MeuCampeonato.Core.Interface.Repositories;

namespace MeuCampeonato.Application.Queries.Time.BuscarTodos
{
    public class BuscarTodosTimesQueryHandler : IRequestHandler<BuscarTodosTimesQuery, List<TimeViewModel>>
    {

        private readonly IRepository<Core.Entities.Time> _timeRepository;

        public BuscarTodosTimesQueryHandler(IRepository<Core.Entities.Time> timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<List<TimeViewModel>> Handle(BuscarTodosTimesQuery request, CancellationToken cancellationToken)
        {
            var times = await _timeRepository.BuscarTodosAsync();

            var timeViewModel = times.Select(x => new TimeViewModel(x.Id, x.NomeTime, x.DataInscricao)).ToList();
               
            return timeViewModel;

        }
    }
}
