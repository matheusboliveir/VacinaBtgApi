
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Commands.PessoaCommands;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PessoasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<Pessoa>> Criar([FromBody] CriarPessoaCommand command)
        {
            Pessoa pessoa = await _mediator.Send(command);
            return StatusCode(201, pessoa);
        }

        [HttpPut("Editar")]
        public async Task<ActionResult<Pessoa>> Editar([FromBody] EditarPessoaCommand command)
        {
            Pessoa pessoa = await _mediator.Send(command);
            return Ok(pessoa);
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            await _mediator.Send(new DeletarPessoaCommand(id));
            return NoContent();
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> Listar([FromServices] VacinaDbContext context)
        {
            return await context.Pessoas.ToListAsync();
        }


    }

}
