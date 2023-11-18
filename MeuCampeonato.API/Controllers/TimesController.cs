using MediatR;
using MeuCampeonato.Application.Commands.Time.CriarTime;
using MeuCampeonato.Application.Queries.BuscarTime.BuscarTimePorId;
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



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new BuscarTimePorIdQuery(id);

            var time = await _mediator.Send(query);

            if (time == null)
            {
                return NotFound();
            }

            return Ok(time);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarTimeCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
