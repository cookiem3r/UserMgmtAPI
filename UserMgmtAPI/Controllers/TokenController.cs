using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserMgmtAPI.Application.Context.Command.CreateJwtToken;

namespace UserMgmtAPI.Web.Controllers
{
    [ApiController]
    
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("user/authorise")]
        public async Task<ActionResult> authorise()
        {
            string token = await _mediator.Send(new CreateJwtTokenCommandModel());
            return Ok(token);
        }
    }
}
