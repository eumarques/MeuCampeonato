using MediatR;
using MeuCampeonato.Core.Repositories;

namespace MeuCampeonato.Application.Commands.Campeonato
{
    public class SimularCampeonatoCommandHandler : IRequestHandler<SimularCampeonatoCommand, int>
    {
        private readonly IRepository<Core.Entities.Time> _timeRepository;
        private readonly IRepository<Core.Entities.Campeonato> _campeonatoRepository;

        public SimularCampeonatoCommandHandler(IRepository<Core.Entities.Time> timeRepository, IRepository<Core.Entities.Campeonato> campeonatoRepository)
        {
            _timeRepository = timeRepository;
            _campeonatoRepository = campeonatoRepository;
        }

        public async Task<int> Handle(SimularCampeonatoCommand request, CancellationToken cancellationToken)
        {
            var campeonato = new Core.Entities.Campeonato(request.nomeComapeonato);

            // fazer tratamento nas lista deve ter no minimo 8 itens
            var allTime = new List<Core.Entities.Time>(request.Times);


            var oitoTimesAleatorios = SelecionarOitoTimesAleatorios(allTime);

            var timesParaSemiFinal = SimularJogos(oitoTimesAleatorios, 4, oitoTimesAleatorios.Count, false);
            var final = SimularJogos(timesParaSemiFinal, 2, timesParaSemiFinal.Count, true);
            DefinirPosicaoPrimeiroSegundo(campeonato, final[0], final[1]);
            DefinirPosicaoTerceiroQuarto(campeonato, final[2], final[3]);

            await _campeonatoRepository.AdicionarAsync(campeonato);

            return campeonato.Id;
        }

        public List<Core.Entities.Time> SelecionarOitoTimesAleatorios(List<Core.Entities.Time> times)
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
        private static void DefinirPosicaoPrimeiroSegundo(Core.Entities.Campeonato campeonato, Core.Entities.Time timeA, Core.Entities.Time timeB)
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
        private static void DefinirPosicaoTerceiroQuarto(Core.Entities.Campeonato campeonato, Core.Entities.Time timeA, Core.Entities.Time timeB)
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
        private static int SimularPlacar()
        {
            Random aleatorio = new Random();
            return aleatorio.Next(1, 6);
        }
        private static Core.Entities.Time Desempate(Core.Entities.Time primeiroTime, Core.Entities.Time segundoTime)
        {
            if (primeiroTime.Pontuacao != segundoTime.Pontuacao)
            {
                return primeiroTime.Pontuacao > segundoTime.Pontuacao ? primeiroTime : segundoTime;
            }

            return primeiroTime.DataInscricao < segundoTime.DataInscricao ? primeiroTime : segundoTime;
        }
    }
}
