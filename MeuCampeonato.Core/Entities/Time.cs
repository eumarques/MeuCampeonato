namespace MeuCampeonato.Core.Entities
{
    public class Time
    {
        public Time(string nome, int pontuacao, int gols, DateTime dataInscricao)
        {
            NomeTime = nome;
            Pontuacao = pontuacao;
            Gols = gols;
            DataInscricao = dataInscricao;
        }

        public int TimeId { get; private set; }
        public string NomeTime { get; private set; }
        public int Pontuacao { get; private set; }
        public int Gols { get; private set; }
        public DateTime DataInscricao { get; private set; }
    }
}
