using FluentValidation;
using VacinaBtgApi.Commands;

namespace VacinaBtgApi.Validators
{
    public class CriarVacinaValidator : AbstractValidator<CriarVacinaCommand>
    {
        public CriarVacinaValidator()
        {
            RuleFor(x => x.nome).NotEmpty();
            RuleFor(x => x.tipo).IsInEnum();
            RuleFor(x => x.numeroDose).GreaterThan(0);
            RuleFor(x => x.numeroReforco).NotNull();
            RuleFor(x => x.semLimiteDose).NotNull();
        }
    }
}
