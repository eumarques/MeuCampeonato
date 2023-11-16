using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.API.Controllers
{
    [ApiController]
    [Route("api/times")]
    public class TimesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {


            return Ok();
        }
    }
}
