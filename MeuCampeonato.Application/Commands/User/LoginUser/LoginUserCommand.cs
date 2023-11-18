using MediatR;
using MeuCampeonato.Application.ViewModels.User;

namespace MeuCampeonato.Application.Commands.User.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
