using Xunit;
using UserEntity = MeuCampeonato.Core.Entities.User;

namespace MeuCampeonato.UnitTests.Core.Entities.User
{
    public class UserTests
    {
        [Fact]
        public void User_Constructor_Sets_Values_Properly()
        {
            // Arrange
            string nomeCompleto = "Fulano";
            string email = "fulano@example.com";
            DateTime dataNascimento = new DateTime(1990, 1, 1);
            string senha = "senha123";
            string funcao = "admin";

            // Act
            var user = new UserEntity(nomeCompleto, email, dataNascimento, senha, funcao);

            // Assert
            Assert.Equal(nomeCompleto, user.NomeCompleto);
            Assert.Equal(email, user.Email);
            Assert.Equal(dataNascimento, user.DataNascimento);
            Assert.True(user.Ativo);
            Assert.Equal(senha, user.Senha);
            Assert.Equal(funcao, user.Funcao);
        }
        [Fact]
        public void TestAtualizarEmail()
        {
            // Arrange
            string nomeCompleto = "Fulano";
            string email = "fulano@example.com";
            DateTime dataNascimento = new DateTime(1990, 1, 1);
            string senha = "senha123";
            string funcao = "admin";
            var user = new UserEntity(nomeCompleto, email, dataNascimento, senha, funcao);

            string newEmail = "novofulano@example.com";

            // Act
            user.Atualizar(newEmail);

            // Assert
            Assert.Equal(newEmail, user.Email);
        }
    }
}

