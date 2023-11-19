using MediatR;

namespace MeuCampeonato.Application.Commands.Time.Excluir_Time
{
    public class DeleteTimeCommand : IRequest<Unit>
    {
        public DeleteTimeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
