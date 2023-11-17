using MediatR;
using MeuCampeonato.Application.Commands.Campeonato;
using MeuCampeonato.Application.Commands.Time.CriarTime;
using MeuCampeonato.Application.Queries.BuscarTime.BuscarTimePorId;
using MeuCampeonato.Application.Queries.Campeonato.BuscarPorId;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new BuscarCampeonatoPorIdQuery(id);

            var campeonato = await _mediator.Send(query);

            if (campeonato == null)
            {
                return NotFound();
            }

            return Ok(campeonato);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SimularCampeonatoCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }


    }
}
