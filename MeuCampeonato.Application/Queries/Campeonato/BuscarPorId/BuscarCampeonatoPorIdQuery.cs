using MediatR;
using MeuCampeonato.Application.ViewModels.Campeonato;

namespace MeuCampeonato.Application.Queries.Campeonato.BuscarPorId
{
    public class BuscarCampeonatoPorIdQuery : IRequest<CampeonatoViewModel>
    {
        public BuscarCampeonatoPorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
