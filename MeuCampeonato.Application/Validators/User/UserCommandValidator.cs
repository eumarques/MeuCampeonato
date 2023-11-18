using FluentValidation;
using MeuCampeonato.Application.Commands.User.CriarUser;
using System.Text.RegularExpressions;

namespace MeuCampeonato.Application.Validators.User
{
    public class UserCommandValidator : AbstractValidator<CriarUsuarioCommand>
    {
        public UserCommandValidator()
        {
            RuleFor(x => x.NomeCompleto)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("Campo Nome é obrigatorio com no minimo 3 caracteres e com seu tamanho maximo de 50 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Por favor, informe um e-mail válido.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data é obrigatória.")
                .Must(date => date < DateTime.Now.Date).WithMessage("A data deve ser uma data Anterior a data de Hoje.");

            RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .Must(ValidPassword)
            .MinimumLength(8).WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");

            RuleFor(x => x.Funcao)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(25)
                .WithMessage("Campo Funcao é obrigatorio com no minimo 4 caracteres e com seu tamanho maximo de 25 caracteres");
        }

        public bool ValidPassword(string senha)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(senha);
        }
    }
}
