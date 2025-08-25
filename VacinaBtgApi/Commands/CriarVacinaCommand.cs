using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands
{
    public record CriarVacinaCommand(string nome, TipoVacinaEnum tipo, int numeroDose, int numeroReforco, bool semLimiteDose) : IRequest<Vacina>;
}