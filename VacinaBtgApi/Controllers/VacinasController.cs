using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace VacinaBtgApi.Controllers
{
    public class VacinasController : ControllerBase
    {

        private readonly IMediator _mediator;

        public VacinasController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}
