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

        public List<Core.Entities.Time> ColocarTimesEmAleatorios(List<Core.Entities.Time> times)
        {
            Random aleatorio = new Random();
            var listaEmbaralhada = times.OrderBy(x => aleatorio.Next()).ToList();
            var oitoTimesAleatorios = listaEmbaralhada.Take(8).ToList();

            return oitoTimesAleatorios;
        }
        public List<Core.Entities.Time> SimularJogos(List<Core.Entities.Time> times, int rodadas, int posicao, bool semifinal = false)
        {
            var classificados = new List<Core.Entities.Time>();
            var desclassificados = new List<Core.Entities.Time>();

            for (int i = 0; i < rodadas; i++)
            {
                int golsTime1 = SimularPlacar();
                int golsTime2 = SimularPlacar();

                var timeA = times[i];
                var timeB = times[--posicao];

                timeA.AdicionarPontos(golsTime1);
                timeB.AdicionarPontos(golsTime2);

                if (golsTime1 > golsTime2)
                {
                    classificados.Add(timeA);
                    desclassificados.Add(timeB);
                    timeB.RemoverPontos(golsTime1);
                }
                else if (golsTime1 < golsTime2)
                {
                    classificados.Add(timeB);
                    desclassificados.Add(timeA);
                    timeA.RemoverPontos(golsTime2);
                }
                else
                {
                    var vencedorDesempate = Desempate(timeA, timeB);
                    classificados.Add(vencedorDesempate);
                    desclassificados.Add(vencedorDesempate == timeA ? timeB : timeA);
                }

            }

            if (semifinal == true)
            {
                var classificadosParaFinal = classificados.Concat(desclassificados).ToList();
                return classificadosParaFinal;

            }

            return classificados;
        }
        public  void DefinirPosicaoPrimeiroSegundo(Core.Entities.Campeonato campeonato, Core.Entities.Time timeA, Core.Entities.Time timeB)
        {
            int golsTime1 = SimularPlacar();
            int golsTime2 = SimularPlacar();

            if (golsTime1 > golsTime2)
            {
                campeonato.AddPrimeiroLugar(timeA.NomeTime);
                campeonato.AddSegundoLugar(timeB.NomeTime);

            }
            else if (golsTime1 < golsTime2)
            {
                campeonato.AddPrimeiroLugar(timeB.NomeTime);
                campeonato.AddSegundoLugar(timeA.NomeTime);
            }
            else
            {
                var vencedorDesempate = Desempate(timeA, timeB);
                campeonato.AddPrimeiroLugar(vencedorDesempate.NomeTime);
                campeonato.AddSegundoLugar(vencedorDesempate.NomeTime == timeA.NomeTime ? timeB.NomeTime : timeA.NomeTime);
            }
        }
        public  void DefinirPosicaoTerceiroQuarto(Core.Entities.Campeonato campeonato, Core.Entities.Time timeA, Core.Entities.Time timeB)
        {
            int golsTime1 = SimularPlacar();
            int golsTime2 = SimularPlacar();

            if (golsTime1 > golsTime2)
            {
                campeonato.AddTerceiroLugar(timeA.NomeTime);
                campeonato.AddQuantoLugar(timeB.NomeTime);

            }
            else if (golsTime1 < golsTime2)
            {
                campeonato.AddTerceiroLugar(timeB.NomeTime);
                campeonato.AddQuantoLugar(timeA.NomeTime);
            }
            else
            {
                var vencedorDesempate = Desempate(timeA, timeB);
                campeonato.AddTerceiroLugar(vencedorDesempate.NomeTime);
                campeonato.AddQuantoLugar(vencedorDesempate.NomeTime == timeA.NomeTime ? timeB.NomeTime : timeA.NomeTime);
            }
        }
        public int SimularPlacar()
        {
            Random aleatorio = new Random();
            return aleatorio.Next(1, 6);
        }
        public Core.Entities.Time Desempate(Core.Entities.Time primeiroTime, Core.Entities.Time segundoTime)
        {
            if (primeiroTime.Pontuacao != segundoTime.Pontuacao)
            {
                return primeiroTime.Pontuacao > segundoTime.Pontuacao ? primeiroTime : segundoTime;
            }

            return primeiroTime.DataInscricao < segundoTime.DataInscricao ? primeiroTime : segundoTime;
        }

    }
}
