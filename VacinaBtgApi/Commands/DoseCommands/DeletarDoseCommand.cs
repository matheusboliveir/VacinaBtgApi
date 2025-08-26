using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.DoseCommands
{
    public record DeletarDoseCommand(int id) : IRequest<Unit>;
}
