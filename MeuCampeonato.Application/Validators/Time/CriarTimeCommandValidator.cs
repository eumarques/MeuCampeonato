using FluentValidation;
using MeuCampeonato.Application.Commands.Time.CriarTime;

namespace MeuCampeonato.Application.Validators.Time
{
    public class CriarTimeCommandValidator : AbstractValidator<CriarTimeCommand>
    {
        public CriarTimeCommandValidator()
        {
            RuleFor(x => x.NomeTime)
                   .NotEmpty().WithMessage("O nome do time é obrigatório.")
                   .MinimumLength(5)
                   .MaximumLength(50).WithMessage("O nome do time não pode ser menor que 5 caracteres e nao " +
                                       "deve ter mais que 50 caracteres.");
        }
    }
}
