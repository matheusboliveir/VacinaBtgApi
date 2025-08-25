using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands
{
    public record ListarVacinaCommand(int? pessoaId) : IRequest<IEnumerable<Vacina>>;
}