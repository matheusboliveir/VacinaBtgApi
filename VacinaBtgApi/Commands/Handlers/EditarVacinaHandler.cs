using MediatR;
using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.Handlers
{
    public class EditarVacinaHandler : IRequestHandler<EditarVacinaCommand, Vacina>
    {
        private readonly VacinaDbContext _context;

        public EditarVacinaHandler(VacinaDbContext context)
        {
            _context = context;
        }

        public async Task<Vacina> Handle(EditarVacinaCommand request, CancellationToken cancellationToken)
        {
            Vacina? vacina = await _context.Vacinas.FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);

            if (vacina == null)
            {
                throw new Exception("Vacina não encontrada");
            }

            vacina.nome = request.nome;
            vacina.tipo = request.tipo;
            vacina.numeroDose = request.numeroDose;
            vacina.numeroReforco = request.numeroReforco;
            vacina.semLimiteDose = request.semLimiteDose;

            await _context.SaveChangesAsync(cancellationToken);

            return vacina;
        }
    }
}