using MediatR;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.PessoaCommands.Handlers
{
    public class CriarPessoaHandler : IRequestHandler<CriarPessoaCommand, Pessoa>
    {
        private readonly VacinaDbContext _context;

        public CriarPessoaHandler(VacinaDbContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> Handle(CriarPessoaCommand request, CancellationToken cancellationToken)
        {
            Pessoa pessoa = new Pessoa
            {
                nome = request.nome,
                idade = request.idade,
                sexo = request.sexo
            };

            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync(cancellationToken);

            return pessoa;
        }
    }
}