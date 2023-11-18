using FluentValidation;
using MeuCampeonato.Application.Commands.User.LoginUser;
using System.Text.RegularExpressions;

namespace MeuCampeonato.Application.Validators.User
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
              .NotEmpty().WithMessage("O e-mail é obrigatório.")
              .EmailAddress().WithMessage("Por favor, informe um e-mail válido.");

            RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .Must(ValidPassword)
            .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.");
        }

        public bool ValidPassword(string senha)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(senha);
        }
    }
}
