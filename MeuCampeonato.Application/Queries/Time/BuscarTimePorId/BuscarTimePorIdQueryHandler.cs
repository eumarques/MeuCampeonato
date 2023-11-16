using MediatR;
using MeuCampeonato.Application.Queries.BuscarTime.BuscarTimePorId;
using MeuCampeonato.Application.ViewModels.Time;
using MeuCampeonato.Core.Repositories;

namespace MeuCampeonato.Application.Queries.Time.BuscarTimePorId
{
    public class BuscarTimePorIdQueryHandler : IRequestHandler<BuscarTimePorIdQuery,TimeViewModel>
    {
        private readonly IRepository<Core.Entities.Time> _timeRepository;

        public BuscarTimePorIdQueryHandler(IRepository<Core.Entities.Time> timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<TimeViewModel> Handle(BuscarTimePorIdQuery request, CancellationToken cancellationToken)
        {
            var time = await _timeRepository.BuscarPorIdAsync(request.Id);

            var timeViewModel = new TimeViewModel(time.Id,time.NomeTime,time.DataInscricao);

            return timeViewModel;
        }
    }
}
