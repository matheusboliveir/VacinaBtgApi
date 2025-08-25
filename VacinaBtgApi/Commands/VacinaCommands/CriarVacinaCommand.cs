using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.VacinaCommands
{
    public record CriarVacinaCommand(string nome, TipoVacinaEnum tipo, int numeroDose, int numeroReforco, bool semLimiteDose) : IRequest<Vacina>;
}