namespace MeuCampeonato.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string nomeCompleto, string email, DateTime dataNascimento, string senha, string funcao)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            Ativo = true;
            Senha = senha;
            Funcao = funcao;
        }

        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; set; }
        public string Senha { get; private set; }
        public string Funcao { get; private set; }
    }
}

