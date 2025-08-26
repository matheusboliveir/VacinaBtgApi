
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Commands.DoseCommands;
using VacinaBtgApi.Commands.PessoaCommands;
using VacinaBtgApi.Data;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]
    public class DosesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DosesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<Dose>> Criar([FromBody] CriarDoseCommand command)
        {
            Dose dose = await _mediator.Send(command);
            return StatusCode(201, dose);
        }

    }

}
