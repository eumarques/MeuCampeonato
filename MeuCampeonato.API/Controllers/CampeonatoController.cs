using MediatR;
using MeuCampeonato.Application.Commands.Time.CriarTime;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.API.Controllers
{
    [ApiController]
    [Route("api/compeonato")]
    public class CampeonatoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CampeonatoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarTimeCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
