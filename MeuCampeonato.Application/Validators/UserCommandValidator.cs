using FluentValidation;
using MeuCampeonato.Application.Commands.User.CriarUser;
using System.Text.RegularExpressions;

namespace MeuCampeonato.Application.Validators
{
    public class UserCommandValidator : AbstractValidator<CriarUsuarioCommand>
    {
        public UserCommandValidator()
        {
            RuleFor(x => x.NomeCompleto)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(55)
                .WithMessage("Campo Nome Obrigatorio com no minimo 3 caracteres e com seu tamanho maximo de 55 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("E-mail não valido");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data é obrigatória.")
                .Must(date => date < DateTime.Now.Date).WithMessage("A data deve ser uma data Anterior a data de Hoje.");

            RuleFor(x => x.Senha)
               .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, " +
                             "um número, uma letra maiúscula e um caracter especial!");

            RuleFor(x => x.Funcao)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(25)
                .WithMessage("Campo Funcao Obrigatorio com no minimo 4 caracteres e com seu tamanho maximo de 25 caracteres");
        }

        public bool ValidPassword(string senha)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(senha);
        }
    }
}
