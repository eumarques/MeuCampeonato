using MediatR;
using MeuCampeonato.Application.Commands.Time.AtualizarTime;
using MeuCampeonato.Application.Commands.Time.CriarTime;
using MeuCampeonato.Application.Commands.Time.Excluir_Time;
using MeuCampeonato.Application.Commands.User.DeletarUser;
using MeuCampeonato.Application.Queries.BuscarTime.BuscarTimePorId;
using MeuCampeonato.Application.Queries.Time.BuscarTodos;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var query = new BuscarTimePorIdQuery(id);

            var time = await _mediator.Send(query);

            if (time == null)
            {
                return NotFound();
            }

            return Ok(time);
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> BuscarTodos()
        {
            var buscarTodosTimesQuery = new BuscarTodosTimesQuery();

            var times = await _mediator.Send(buscarTodosTimesQuery);

            return Ok(times);
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CriarTime([FromBody] CriarTimeCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(BuscarPorId), new { id = id }, command);
        }

        [HttpPut("AtualizarNomeTime")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> AtualizarTime([FromBody] AtualizarTimeCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> ExcluirTime(int id)
        {
            var query = new DeleteTimeCommand(id);

            await _mediator.Send(query);

            return NoContent();
        }
    }
}
