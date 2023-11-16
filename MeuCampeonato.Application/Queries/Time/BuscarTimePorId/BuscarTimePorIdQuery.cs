using MediatR;
using MeuCampeonato.Application.ViewModels.Time;

namespace MeuCampeonato.Application.Queries.BuscarTime.BuscarTimePorId
{
    public class BuscarTimePorIdQuery : IRequest<TimeViewModel>
    {
        public BuscarTimePorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

