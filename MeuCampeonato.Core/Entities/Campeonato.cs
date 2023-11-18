namespace MeuCampeonato.Core.Entities
{
    public class Campeonato : BaseEntity
    {
        public Campeonato(string nomeComapeonato)
        {

            NomeComapeonato = nomeComapeonato;
            DataCampeonato = DateTime.Now;
        }

        public string NomeComapeonato { get; private set; }
        public DateTime DataCampeonato { get; private set; }
        public string PrimeiroLugar { get; private set; }
        public string SegundoLugar { get; private set; }
        public string TerceiroLugar { get; private set; }
        public string QuantoLugar { get; private set; }

        public void AddPrimeiroLugar(string nome)
        {
            PrimeiroLugar = nome;
        }

        public void AddSegundoLugar(string nome)
        {
            SegundoLugar = nome;
        }
        public void AddTerceiroLugar(string nome)
        {
            TerceiroLugar = nome;
        }
        public void AddQuantoLugar(string nome)
        {
            QuantoLugar = nome;
        }
    }
}
