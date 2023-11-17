using MediatR;

namespace MeuCampeonato.Application.Commands.Time.CriarTime
{
    public class CriarTimeCommand : IRequest<int>
    {
        public string NomeTime { get;  set; }
    }
}
