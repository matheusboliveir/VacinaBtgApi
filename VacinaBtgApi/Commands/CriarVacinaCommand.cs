using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands
{
    public record CriarVacinaCommand(string Nome, DateTime DataAplicacao, string Lote, string Fabricante) : IRequest<Vacina>;
}
