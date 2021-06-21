using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserMgmtAPI.Application.UserContext.Command.CreateNewUserCommand;

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
        public ActionResult SecretString([FromBody] CreateNewUserCommandModel model)
        {
            _mediator.Send(model);
            return Ok("Created");
        }
    }
}
