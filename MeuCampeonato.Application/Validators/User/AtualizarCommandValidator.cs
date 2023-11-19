using FluentValidation;
using MeuCampeonato.Application.Commands.User.AtualizarUser;

namespace MeuCampeonato.Application.Validators.User
{
    public class AtualizarCommandValidator : AbstractValidator<AtualizarCommand>
    {
        public AtualizarCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Por favor, informe um e-mail válido.");
        }
    }
}
