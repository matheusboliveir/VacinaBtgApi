using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands
{
    public record DeletarVacinaCommand(int id) : IRequest<Unit>;
}