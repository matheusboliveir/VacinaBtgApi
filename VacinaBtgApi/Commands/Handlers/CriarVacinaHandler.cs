using MediatR;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.Handlers
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
                Nome = request.Nome,
                DataAplicacao = request.DataAplicacao,
                Lote = request.Lote,
                Fabricante = request.Fabricante
            };

            _context.Vacinas.Add(vacina);
            await _context.SaveChangesAsync(cancellationToken);

            return vacina;
        }
    }
}
