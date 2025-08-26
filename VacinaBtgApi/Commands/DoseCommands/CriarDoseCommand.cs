using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.DoseCommands
{
    public record CriarDoseCommand(TipoDoseEnum tipo, int pessoaId, int vacinaId) : IRequest<Dose>;
}
