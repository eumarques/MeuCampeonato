namespace MeuCampeonato.Core.Entities
{
    public class Campeonato
    {
        public Campeonato(string nomeComapeonato, DateTime dataCampeonato,
            string primeiroLugar, string segundoLugar, string terceiroLugar, string quantoLugar)
        {
            
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
