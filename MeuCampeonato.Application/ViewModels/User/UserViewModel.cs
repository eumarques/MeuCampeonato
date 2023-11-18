namespace MeuCampeonato.Application.ViewModels.User
{
    public class UserViewModel
    {
        public UserViewModel(string nomeCompleto, string email)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
        }

        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
    }
}
