namespace MeuCampeonato.Application.ViewModels.Time
{
    public class TimeViewModel
    {

        public TimeViewModel(int timeId,string nomeTime, DateTime dataInscricao)
        {
            NomeTime = nomeTime;
            DataInscricao = dataInscricao;
            TimeId = timeId;
        }

        public int TimeId { get; private set; }
        public string NomeTime { get; private set; }
        public DateTime DataInscricao { get; private set; }
    }
}
