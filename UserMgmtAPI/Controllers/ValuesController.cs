using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace UserMgmtAPI.Web.Controllers
{

    [ApiController]
    
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("values/firstnameMS")]
        [Authorize(AuthenticationSchemes= "Microsoft")]
        public ActionResult MicrosoftName()
        {
            //return Ok();
            var claims = User.Identities.First().Claims.ToList();
            var name = claims?.FirstOrDefault(x => x.Type.Equals("name", StringComparison.OrdinalIgnoreCase))?.Value;
            return Ok(new { firstname = name });
        }

        [HttpGet]
        [Route("values/firstnameCustom")]
        [Authorize(AuthenticationSchemes = "Custom")]
        public ActionResult CustomName()
        {            
            var claims = User.Identities.First().Claims.ToList();
            var name = claims?.FirstOrDefault(x => x.Type.Equals("unique_name", StringComparison.OrdinalIgnoreCase))?.Value;
            return Ok(new { firstname = name });
        }
    }
}
