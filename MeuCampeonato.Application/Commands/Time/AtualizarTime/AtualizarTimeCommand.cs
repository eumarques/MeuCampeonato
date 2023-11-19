using MediatR;

namespace MeuCampeonato.Application.Commands.Time.AtualizarTime
{
    public class AtualizarTimeCommand : IRequest<Unit>
    {
        public AtualizarTimeCommand(int id, string nameTime)
        {
            Id = id;
            NameTime = nameTime;
        }

        public int Id { get; set; }
        public string NameTime { get; set; }
    }
}
