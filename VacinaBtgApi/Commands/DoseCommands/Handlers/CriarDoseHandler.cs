using MediatR;
using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.DoseCommands.Handlers
{
    public class CriarDoseHandler : IRequestHandler<CriarDoseCommand, Dose>
    {
        private readonly VacinaDbContext _context;

        public CriarDoseHandler(VacinaDbContext context)
        {
            _context = context;
        }

        public async Task<Dose> Handle(CriarDoseCommand request, CancellationToken cancellationToken)
        {
            Vacina? vacina = await _context.Vacinas.FirstOrDefaultAsync(v => v.Id == request.vacinaId, cancellationToken);

            if (vacina == null) {
                throw new Exception("Vacina não cadastrada.");
            }

            Pessoa? pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == request.pessoaId, cancellationToken);

            if (pessoa == null) {
                throw new Exception("Pessoa não existe.");
            }

            int quantidadeDoses = await _context.Doses
                .CountAsync(d => d.VacinaId == request.vacinaId && d.PessoaId == request.pessoaId && d.tipo == request.tipo, cancellationToken); ;

            int limiteDose = request.tipo == TipoDoseEnum.COMUM ? vacina.numeroDose : vacina.numeroReforco;

            if (!vacina.semLimiteDose && quantidadeDoses >= limiteDose)
            {
                throw new Exception("Limite de doses desta vacina e tipo atingido para essa pessoa.");
            }

            Dose dose = new Dose
            {
                numero = quantidadeDoses + 1,
                Pessoa = pessoa,
                Vacina = vacina,
                tipo = request.tipo,
            };

            _context.Doses.Add(dose);
            await _context.SaveChangesAsync(cancellationToken);

            return dose;
        }
    }
}
