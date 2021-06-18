using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UserMgmtAPI.Web.Controllers
{
  
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("values/secret")]
        public ActionResult SecretString()
        {
            var user = User.Identity;
            return Ok("SECRET STRING");
        }
    }
}
