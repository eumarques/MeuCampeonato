using MediatR;
using MeuCampeonato.Application.ViewModels.Campeonato;

namespace MeuCampeonato.Application.Queries.Campeonato.BuscarTodos
{
    public class BuscarTodosCampeonatoQuery : IRequest<List<CampeonatoViewModel>>
    {
    }
}
