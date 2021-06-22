using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserMgmtAPI.Application.UserContext.Command.CreateNewUserCommand;
using UserMgmtAPI.Application.UserContext.Command.LoginCommand;
using UserMgmtAPI.Application.UserContext.Command.RefreshTokenCommand;

namespace UserMgmtAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("user/create")]
        public ActionResult CreateUser([FromBody] CreateNewUserCommandModel model)
        {
            _mediator.Send(model);
            return Ok("Created");
        }

        [HttpPost]
        [Route("user/login")]
        public async Task<ActionResult> Login([FromBody] LoginCommandModel model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("user/refreshtoken")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenCommandModel model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}
