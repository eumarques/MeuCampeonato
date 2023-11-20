namespace MeuCampeonato.Core.Entities
{
    public class Time : BaseEntity
    {
        public Time(string nomeTime)
        {
            NomeTime = nomeTime;
            Pontuacao = 0;
            DataInscricao = DateTime.Now;
        }

        public string NomeTime { get; private set; }
        public int Pontuacao { get; private set; }

        public DateTime DataInscricao { get; private set; }


        public void AdicionarPontos(int pontuacao)
        {
            Pontuacao += pontuacao;
        }

        public void AtualizarNome(string nameTime)
        {
            NomeTime = nameTime;
        }

        public void RemoverPontos(int pontuacao)
        {
            Pontuacao -= pontuacao;
        }

        public DateTime RetornarDataInscricao()
        {
            return DataInscricao.AddDays(-1);
        }
    }
}
