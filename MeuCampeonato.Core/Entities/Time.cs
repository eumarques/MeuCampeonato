namespace MeuCampeonato.Core.Entities
{
    public class Time : BaseEntity
    {
        public Time(string nome, DateTime dataInscricao)
        {
            NomeTime = nome;
            Pontuacao = 0;
            Gols = 0;
            DataInscricao = dataInscricao;
        }

        public string NomeTime { get; private set; }
        public int Pontuacao { get; private set; }
        public int Gols { get; private set; }
        public DateTime DataInscricao { get; private set; }
    }
}
