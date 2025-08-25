using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.VacinaCommands
{
    public record DeletarVacinaCommand(int id) : IRequest<Unit>;
}