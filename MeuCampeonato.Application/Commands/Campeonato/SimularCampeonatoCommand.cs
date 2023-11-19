using MediatR;
namespace MeuCampeonato.Application.Commands.Campeonato
{
    public class SimularCampeonatoCommand : IRequest<int>
    {
        public string nomeCompeonato {  get; set; }
        public List<Core.Entities.Time> Times { get; set; }
    }
}
