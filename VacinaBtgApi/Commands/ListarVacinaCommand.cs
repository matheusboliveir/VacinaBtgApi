using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands
{
    public record ListarVacinaCommand(string? pessoaId) : IRequest<IEnumerable<Vacina>>;
}