using MediatR;
using VacinaBtgApi.Commands.VacinaCommands;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.VacinaCommands.Handlers
{
    public class CriarVacinaHandler : IRequestHandler<CriarVacinaCommand, Vacina>
    {
        private readonly VacinaDbContext _context;

        public CriarVacinaHandler(VacinaDbContext context)
        {
            _context = context;
        }

        public async Task<Vacina> Handle(CriarVacinaCommand request, CancellationToken cancellationToken)
        {
            var vacina = new Vacina
            {
                nome = request.nome,
                tipo = request.tipo,
                numeroDose = request.numeroDose,
                numeroReforco = request.numeroReforco,
                semLimiteDose = request.semLimiteDose,
            };

            _context.Vacinas.Add(vacina);
            await _context.SaveChangesAsync(cancellationToken);

            return vacina;
        }
    }
}