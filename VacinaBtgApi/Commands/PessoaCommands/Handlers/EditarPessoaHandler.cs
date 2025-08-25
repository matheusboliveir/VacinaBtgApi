using MediatR;
using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Commands.PessoaCommands;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.VacinaCommands.Handlers
{
    public class EditarPessoaHandler : IRequestHandler<EditarPessoaCommand, Pessoa>
    {
        private readonly VacinaDbContext _context;

        public EditarPessoaHandler(VacinaDbContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> Handle(EditarPessoaCommand request, CancellationToken cancellationToken)
        {
            Pessoa? pessoa = await _context.Pessoas.FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);

            if (pessoa == null)
            {
                throw new Exception("Pessoa não encontrada");
            }

            pessoa.nome = request.nome;
            pessoa.idade = request.idade;
            pessoa.sexo = request.sexo;

            await _context.SaveChangesAsync(cancellationToken);

            return pessoa;
        }
    }
}