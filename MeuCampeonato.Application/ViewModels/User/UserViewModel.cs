namespace MeuCampeonato.Application.ViewModels.User
{
    public class UserViewModel
    {
        public UserViewModel(int id, string nomeCompleto, string email)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Id = id;
        }

        public int Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
    }
}
