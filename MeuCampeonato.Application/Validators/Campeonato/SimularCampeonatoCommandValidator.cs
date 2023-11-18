using FluentValidation;
using MeuCampeonato.Application.Commands.Campeonato;

namespace MeuCampeonato.Application.Validators.Campeonato
{
    public class SimularCampeonatoCommandValidator : AbstractValidator<SimularCampeonatoCommand>
    {
        public SimularCampeonatoCommandValidator()
        {
            RuleFor(x => x.nomeComapeonato)
                .NotEmpty().WithMessage("O nome do campeonato é obrigatório.")
                .MinimumLength(5)
                .MaximumLength(50).WithMessage("O nome do campeonato não pode ter menos que 5 caracteres e mais que 50 caracteres.");

            RuleForEach(x => x.Times)
                .Must(p => p.NomeTime.Length >= 3 && p.NomeTime.Length <= 50)
                .WithMessage("Nome do Time deve ser maior doque 3 caracteres e menor que 50 caracteres");


            RuleFor(x => x.Times)
            .Must(x => x.Count == 8).WithMessage("São Permitido somente 8 times por campeonato");
        }
    }
}
