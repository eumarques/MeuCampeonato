namespace MeuCampeonato.Application.ViewModels.Campeonato
{
    public class CampeonatoViewModel
    {
        public CampeonatoViewModel(int campeonatoId, string nomeComapeonato, DateTime dataCampeonato, string primeiroLugar, string segundoLugar, string terceiroLugar, string quantoLugar)
        {
            CampeonatoId = campeonatoId;
            NomeComapeonato = nomeComapeonato;
            DataCampeonato = dataCampeonato;
            PrimeiroLugar = primeiroLugar;
            SegundoLugar = segundoLugar;
            TerceiroLugar = terceiroLugar;
            QuantoLugar = quantoLugar;
        }

        public int CampeonatoId { get; private set; }
        public string NomeComapeonato { get; private set; }
        public DateTime DataCampeonato { get; private set; }
        public string PrimeiroLugar { get; private set; }
        public string SegundoLugar { get; private set; }
        public string TerceiroLugar { get; private set; }
        public string QuantoLugar { get; private set; }
    }
}
