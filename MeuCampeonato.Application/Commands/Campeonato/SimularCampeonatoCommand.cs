using MediatR;

namespace MeuCampeonato.Application.Commands.Campeonato
{
    public class SimularCampeonatoCommand : IRequest<int>
    {
        public string NomeCampeonato { get; set; }
        public List<Core.Entities.Time> times { get; set; }
    }
}
