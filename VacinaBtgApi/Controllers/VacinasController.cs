
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacinaBtgApi.Commands;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]
    public class VacinasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacinasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<Vacina>> Criar([FromBody] CriarVacinaCommand command)
        {
            Vacina vacina = await _mediator.Send(command);
            return StatusCode(201, vacina);
        }

        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult<Vacina>> GetById(int id, [FromServices] VacinaDbContext context)
        {
            var vacina = await context.Vacinas.FindAsync(id);
            return vacina is not null ? Ok(vacina) : NotFound();
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Vacina>>> Listar([FromQuery] ListarVacinaCommand command)
        {
            IEnumerable<Vacina> vacinas = await _mediator.Send(command);
            return vacinas is not null && vacinas.Any() ? Ok(vacinas) : NotFound();

        }
    }

}
