using MediatR;
using MeuCampeonato.Application.Commands.User.AtualizarUser;
using MeuCampeonato.Application.Commands.User.CriarUser;
using MeuCampeonato.Application.Commands.User.DeletarUser;
using MeuCampeonato.Application.Commands.User.LoginUser;
using MeuCampeonato.Application.Queries.User.BuscarPorId;
using MeuCampeonato.Application.Queries.User.BuscarTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var query = new BuscarUserQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> BuscarTods()
        {
            var buscarTodosTimesQuery = new BuscarTodosUserQuery();

            var users = await _mediator.Send(buscarTodosTimesQuery);

            return Ok(users);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SimuladorDeJogos([FromBody] CriarUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(BuscarPorId), new { id = id }, command);
        }


        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserviewModel = await _mediator.Send(command);

            if (loginUserviewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginUserviewModel);
        }

        [HttpPut("Atualizar")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> AtualizarUser([FromBody] AtualizarCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> ExcluirUser(int id)
        {
            var query = new DeleteUserCommand(id);

            await _mediator.Send(query);

            return NoContent();
        }
    }
}
