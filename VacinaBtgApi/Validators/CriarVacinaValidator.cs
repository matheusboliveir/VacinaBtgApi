using FluentValidation;
using VacinaBtgApi.Commands;

namespace VacinaBtgApi.Validators
{
    public class CriarVacinaValidator : AbstractValidator<CriarVacinaCommand>
    {
        public CriarVacinaValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.DataAplicacao).LessThanOrEqualTo(DateTime.Today);
            RuleFor(x => x.Lote).NotEmpty();
            RuleFor(x => x.Fabricante).NotEmpty();
        }
    }
}
