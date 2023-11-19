using MediatR;
using MeuCampeonato.Application.Commands.Campeonato;
using MeuCampeonato.Application.Queries.Campeonato.BuscarPorId;
using MeuCampeonato.Application.Queries.Campeonato.BuscarTodos;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> BuscarTodosCampeonatos()
        {
            var getAllQuery = new BuscarTodosCampeonatoQuery();

            var campeonatos = await _mediator.Send(getAllQuery);

            return Ok(campeonatos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> BuscarCameponatoPorId(int id)
        {
            var query = new BuscarCampeonatoPorIdQuery(id);

            var campeonato = await _mediator.Send(query);

            if (campeonato == null)
            {
                return NotFound();
            }

            return Ok(campeonato);
        }


        [HttpPost("IniciarCampeonato")]
        [AllowAnonymous]
        //[Authorize(Roles = "Client")]
        public async Task<IActionResult> Post([FromBody] SimularCampeonatoCommand command)
        {
            var campeonatoId = await _mediator.Send(command);

            if (campeonatoId == null)
            {
                return NotFound();
            }
            return Ok(campeonatoId);
        }


    }
}
