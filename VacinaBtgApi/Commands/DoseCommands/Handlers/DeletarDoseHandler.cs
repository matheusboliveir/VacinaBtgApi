using MediatR;
using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Commands.PessoaCommands;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.DoseCommands.Handlers
{
    public class DeletarDoseHandler : IRequestHandler<DeletarDoseCommand, Unit>
    {
        private readonly VacinaDbContext _context;

        public DeletarDoseHandler(VacinaDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletarDoseCommand request, CancellationToken cancellationToken)
        {

            Dose? dose = await _context.Doses.FirstOrDefaultAsync(p => p.Id == request.id, cancellationToken);

            if (dose == null)
            {
                throw new Exception("Dose não encontrada");
            }

            _context.Doses.Remove(dose);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}