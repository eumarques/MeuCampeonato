using MediatR;
using MeuCampeonato.Application.ViewModels.Time;

namespace MeuCampeonato.Application.Queries.Time.BuscarTodos
{
    public class BuscarTodosTimesQuery : IRequest<List<TimeViewModel>>
    {
    }
}
