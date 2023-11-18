using MediatR;

namespace MeuCampeonato.Application.Commands.User.CriarUser
{
    public class CriarUsuarioCommand : IRequest<int>
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public string Funcao { get; set; }
    }

}
