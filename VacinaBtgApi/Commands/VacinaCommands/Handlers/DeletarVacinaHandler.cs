using MediatR;
using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Commands.VacinaCommands;
using VacinaBtgApi.Data;
using VacinaBtgApi.Exceptions;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.VacinaCommands.Handlers
{
    public class DeletarVacinaHandler : IRequestHandler<DeletarVacinaCommand,Unit>
    {
        private readonly VacinaDbContext _context;

        public DeletarVacinaHandler(VacinaDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletarVacinaCommand request, CancellationToken cancellationToken)
        {

            Vacina? vacina = await _context.Vacinas
                .Include(v => v.Doses)
                .FirstOrDefaultAsync(v => v.Id == request.id, cancellationToken);

            if (vacina == null)
            {
                throw new DomainException("Vacina não encontrada");
            }

            _context.Doses.RemoveRange(vacina.Doses);
            _context.Vacinas.Remove(vacina);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}