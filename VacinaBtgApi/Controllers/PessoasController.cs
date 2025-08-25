
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacinaBtgApi.Commands.PessoaCommands;
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

        //[HttpGet("Listar")]
        //public async Task<ActionResult<IEnumerable<Vacina>>> Listar([FromQuery] ListarVacinaCommand command)
        //{
        //    IEnumerable<Vacina> Pessoas = await _mediator.Send(command);
        //    return Pessoas is not null && Pessoas.Any() ? Ok(Pessoas) : NotFound();

        //}


    }

}
