using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;
using UserMgmtAPI.Application.Context.Command.CreateJwtToken;

namespace UserMgmtAPI.Web.Controllers
{
    [ApiController]
    
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public TokenController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        [Route("user/authorise")]
        public async Task<ActionResult> authorise()
        {
            _logger.Information("Test");
            string token = await _mediator.Send(new CreateJwtTokenCommandModel());
            return Ok(token);
        }
    }
}
