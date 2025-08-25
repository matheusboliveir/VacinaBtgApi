using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.VacinaCommands
{
    public record ListarVacinaCommand(int? pessoaId) : IRequest<IEnumerable<Vacina>>;
}