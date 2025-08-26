using MediatR;
using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Data;
using VacinaBtgApi.Exceptions;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.PessoaCommands.Handlers
{
    public class DeletarPessoaHandler : IRequestHandler<DeletarPessoaCommand,Unit>
    {
        private readonly VacinaDbContext _context;

        public DeletarPessoaHandler(VacinaDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletarPessoaCommand request, CancellationToken cancellationToken)
        {

            Pessoa? pessoa = await _context.Pessoas
                .Include(p => p.Doses)
                .FirstOrDefaultAsync(p => p.Id == request.id, cancellationToken);

            if (pessoa == null)
            {
                throw new DomainException("Pessoa não encontrada");
            }

            _context.Doses.RemoveRange(pessoa.Doses);
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}