using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.PessoaCommands
{
    public record EditarPessoaCommand(int Id, string nome, int idade, SexoEnum sexo) : IRequest<Pessoa>;
}
