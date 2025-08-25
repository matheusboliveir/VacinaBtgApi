using MediatR;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Commands.PessoaCommands
{
    public record CriarPessoaCommand(string nome, int idade, SexoEnum sexo) : IRequest<Pessoa>;
}
