using MediatR;
namespace MeuCampeonato.Application.Commands.Campeonato
{
    public class SimularCampeonatoCommand : IRequest<int>
    {
        public string nomeComapeonato {  get; set; }
        public List<Core.Entities.Time> Times { get; set; }
    }
}
