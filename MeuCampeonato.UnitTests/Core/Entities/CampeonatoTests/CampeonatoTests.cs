using MeuCampeonato.Core.Entities;
using NSubstitute;
using Xunit;

namespace MeuCampeonato.UnitTests.Core.Entities.CampeonatoTests
{
    public class CampeonatoTests
    {
        [Fact]
        public void Campeonato_Constructor_Sets_Values_Properly()
        {
            // Arrange
            string nomeCampeonato = "MeuCampeonato";

            // Act
            var campeonato = new Campeonato(nomeCampeonato);

            // Assert
            Assert.Equal(nomeCampeonato, campeonato.NomeComapeonato);
            Assert.Equal(DateTime.Now.Date, campeonato.DataCampeonato.Date);
            Assert.Null(campeonato.PrimeiroLugar);
            Assert.Null(campeonato.SegundoLugar);
            Assert.Null(campeonato.TerceiroLugar);
            Assert.Null(campeonato.QuantoLugar);
        }

        [Fact]
        public void AddPrimeiroLugar_Sets_PrimeiroLugar()
        {
            // Arrange
            var campeonato = new Campeonato("MeuCampeonato");
            string primeiroLugar = "TimeA";

            // Act
            campeonato.AddPrimeiroLugar(primeiroLugar);

            // Assert
            Assert.Equal(primeiroLugar, campeonato.PrimeiroLugar);
        }

        [Fact]
        public void AddSegundoLugar_Sets_SegundoLugar()
        {
            // Arrange
            var campeonato = new Campeonato("MeuCampeonato");
            string segundoLugar = "TimeB";

            // Act
            campeonato.AddSegundoLugar(segundoLugar);

            // Assert
            Assert.Equal(segundoLugar, campeonato.SegundoLugar);
        }
        [Fact]
        public void AddTerceiroLugar_Sets_TerceiroLugarCorrectly()
        {
            // Arrange
            var campeonato = new Campeonato("MeuCampeonato");
            string terceiroLugarNome = "TerceiroTime";

            // Act
            campeonato.AddTerceiroLugar(terceiroLugarNome);

            // Assert
            Assert.Equal(terceiroLugarNome, campeonato.TerceiroLugar);
        }

        [Fact]
        public void AddQuantoLugar_Sets_QuantoLugarCorrectly()
        {
            // Arrange
            var campeonato = new Campeonato("MeuCampeonato");
            string quantoLugarNome = "QuartoTime";

            // Act
            campeonato.AddQuantoLugar(quantoLugarNome);

            // Assert
            Assert.Equal(quantoLugarNome, campeonato.QuantoLugar);
        }

        [Fact]
        public void ColocarTimesEmAleatorios_Returns_EightRandomTeams()
        {
            // Arrange
            var campeonato = new Campeonato("MeuCampeonato");
            var times = new List<Time>
            {
                new Time("Time1"),
                new Time("Time2"),
                new Time("Time3"),
                new Time("Time4"),
                new Time("Time5"),
                new Time("Time6"),
                new Time("Time7"),
                new Time("Time8"),
                new Time("Time9"),
                new Time("Time10")
            };

            // Act
            var oitoTimesAleatorios = campeonato.ColocarTimesEmAleatorios(times);

            // Assert
            Assert.Equal(8, oitoTimesAleatorios.Count);

            // Verifica se a lista contém apenas times distintos
            Assert.Equal(8, oitoTimesAleatorios.Distinct().Count());
        }

        [Fact]
        public void SimularJogos_Returns_CorrectClassifiedTeams()
        {
            // Arrange
            var campeonato = new Campeonato("MeuCampeonato");
            var times = new List<Time>
            {
                new Time("TimeA"),
                new Time("TimeB"),
                new Time("TimeC"),
                new Time("TimeD"),
                new Time("TimeE"),
                new Time("TimeF"),
                new Time("TimeG"),
                new Time("TimeH")
            };

            // Act
            var classificados = campeonato.SimularJogos(times, 4, 8);

            // Assert
            Assert.Equal(4, classificados.Count);
            Assert.Equal(4, classificados.Distinct().Count());
        }

        [Fact]
        public void SimularJogos_Returns_ClassifiedTeamsForFinal()
        {
            // Arrange
            var campeonato = new Campeonato("MeuCampeonato");
            var times = new List<Time>
            {
                new Time("TimeA"),
                new Time("TimeB"),
                new Time("TimeC"),
                new Time("TimeD"),
                new Time("TimeE"),
                new Time("TimeF"),
                new Time("TimeG"),
                new Time("TimeH")
            };

            // Act
            var classificadosParaFinal = campeonato.SimularJogos(times, 4, 8, true);

            // Assert
            Assert.Equal(8, classificadosParaFinal.Count);
            Assert.Equal(8, classificadosParaFinal.Distinct().Count());
        }

        [Fact]
        public void DefinirPosicaoPrimeiroSegundo_Sets_FirstAndSecondPositionsCorrectly()
        {
            // Arrange
            var campeonatoSubstitute = Substitute.ForPartsOf<Campeonato>("MeuCampeonato");
            var timeA = Substitute.For<Time>("TimeA");
            var timeB = Substitute.For<Time>("TimeB");

            // Configurando o comportamento simulado do SimularPlacar()
            timeA.AdicionarPontos(campeonatoSubstitute.SimularPlacar());
            timeB.AdicionarPontos(campeonatoSubstitute.SimularPlacar());

            // Act
            campeonatoSubstitute.DefinirPosicaoPrimeiroSegundo(campeonatoSubstitute, timeA, timeB);

            // Assert
            Assert.Equal("TimeA", campeonatoSubstitute.PrimeiroLugar);
            Assert.Equal("TimeB", campeonatoSubstitute.SegundoLugar);
        }

        [Fact]
        public void DefinirPosicaoTerceiroQuarto_Sets_ThirdAndFourthPositionsCorrectly()
        {
            // Arrange
            var campeonatoSubstitute = Substitute.ForPartsOf<Campeonato>("MeuCampeonato");
            var campeonato = new Campeonato("MeuCampeonato");
            var timeA = new Time("TimeA");
            var timeB = new Time("TimeB");

            // Configurando o comportamento simulado do SimularPlacar()
            timeA.AdicionarPontos(campeonatoSubstitute.SimularPlacar());
            timeB.AdicionarPontos(campeonatoSubstitute.SimularPlacar());

            // Act
            campeonato.DefinirPosicaoTerceiroQuarto(campeonato, timeA, timeB);

            // Assert
            Assert.Equal("TimeA", campeonato.TerceiroLugar);
            Assert.Equal("TimeB", campeonato.QuantoLugar);
        }

        [Fact]
        public void SimularPlacar_Returns_ValuesBetweenOneAndFive()
        {
            // Arrange
            var campeonato = new Campeonato("MeuCampeonato");

            // Act
            int placarSimulado = campeonato.SimularPlacar();

            // Assert
            Assert.InRange(placarSimulado, 1, 5);
        }

        [Fact]
        public void DefinirPosicaoTerceiroQuarto_Uses_DesempateMethod()

        {
            // Arrange
            var campeonato = new Campeonato("MeuCampeonato");
            var timeA = new Time("TimeA");
            var timeB = new Time("TimeB");

            // Configurando os times com pontuação e data de inscrição
            timeA.AdicionarPontos(10);
            timeB.AdicionarPontos(10);
            timeA.RetornarDataInscricao(); // TimeA inscrito um dia antes do TimeB

            // Act
            var resultadoDesempate = campeonato.Desempate(timeA, timeB);

            // Assert
            Assert.Equal(timeA, resultadoDesempate); // Espera-se que TimeA seja escolhido devido à sua data de inscrição
        }

        [Fact]
        public void Desempate_Returns_CorrectTimeBasedOnCriteria()
        {
            // Arrange
            var campeonato = new Campeonato("MeuCampeonato");
            var timeA = new Time("TimeA");
            var timeB = new Time("TimeB");

            // Configurando os times com pontuação e data de inscrição
            timeA.AdicionarPontos(10);
            timeB.AdicionarPontos(10);
            timeA.RetornarDataInscricao(); // TimeA inscrito um dia antes do TimeB

            // Act
            var resultadoDesempate = campeonato.Desempate(timeA, timeB);

            // Assert
            Assert.Equal(timeA, resultadoDesempate); // Espera-se que TimeA seja escolhido devido à sua data de inscrição
        }

    }
}
