using MediatR;

namespace MeuCampeonato.Application.Commands.User.DeletarUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
