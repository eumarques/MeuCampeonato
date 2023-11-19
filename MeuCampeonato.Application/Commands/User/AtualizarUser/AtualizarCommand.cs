using MediatR;

namespace MeuCampeonato.Application.Commands.User.AtualizarUser
{
    public class AtualizarCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        
    }
}
