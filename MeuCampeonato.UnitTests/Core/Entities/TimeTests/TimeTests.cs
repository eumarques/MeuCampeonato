using MeuCampeonato.Core.Entities;
using Xunit;

namespace MeuCampeonato.UnitTests.Core.Entities.TimeTests
{
    public class TimeTests
    {
        [Fact]
        public void Time_Constructor_Sets_Values_Properly()
        {
            // Arrange
            string nomeTime = "MeuTime";

            // Act
            var time = new Time(nomeTime);

            // Assert
            Assert.Equal(nomeTime, time.NomeTime);
            Assert.Equal(0, time.Pontuacao);
            Assert.Equal(DateTime.Now.Date, time.DataInscricao.Date);
        }

        [Fact]
        public void AdicionarPontos_Increments_Pontuacao()
        {
            // Arrange
            var time = new Time("MeuTime");
            int pontuacao = 20;

            // Act
            time.AdicionarPontos(pontuacao);

            // Assert
            Assert.Equal(pontuacao, time.Pontuacao);
        }

        [Fact]
        public void RemoverPontos_Decrements_Pontuacao()
        {
            // Arrange
            var time = new Time("MeuTime");
            int pontuacaoInicial = 30;
            int pontuacaoRemovida = 15;
            time.AdicionarPontos(pontuacaoInicial);

            // Act
            time.RemoverPontos(pontuacaoRemovida);

            // Assert
            Assert.Equal(pontuacaoInicial - pontuacaoRemovida, time.Pontuacao);
        }

        [Fact]
        public void AtualizarNome_Updates_NomeTime()
        {
            // Arrange
            var time = new Time("MeuTime");
            string novoNome = "NovoNome";

            // Act
            time.AtualizarNome(novoNome);

            // Assert
            Assert.Equal(novoNome, time.NomeTime);
        }
    }
}

