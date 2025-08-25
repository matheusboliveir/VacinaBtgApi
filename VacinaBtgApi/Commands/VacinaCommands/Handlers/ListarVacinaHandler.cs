using MediatR;
using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Commands.VacinaCommands;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.VacinaCommands.Handlers
{
    public class ListarVacinaHandler : IRequestHandler<ListarVacinaCommand, IEnumerable<Vacina>>
    {
        private readonly VacinaDbContext _context;

        public ListarVacinaHandler(VacinaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vacina>> Handle(ListarVacinaCommand request, CancellationToken cancellationToken)
        {
            if (request.pessoaId is null)
            {
                return await _context.Vacinas
                    .AsNoTracking()
                    .ToListAsync();
            }
            return await _context.Vacinas
                .AsNoTracking()
                .Include(v => v.Doses.Where(d => d.PessoaId == request.pessoaId))
                .ToListAsync();
        }
    }
}