using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.PessoaCommands
{
    public record DeletarPessoaCommand(int id) : IRequest<Unit>;
}
