using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserMgmtAPI.Web.Controllers
{

    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("values/firstname")]
        public ActionResult SecretString()
        {          
            return Ok(new { firstname = User.Identity.Name  });
        }
    }
}
