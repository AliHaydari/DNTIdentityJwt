using ASPNETCoreIdentitySample.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreIdentitySample.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("CorsPolicy")]
    [Authorize(Policy = ConstantPolicies.DynamicPermission, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MyProtectedApiController : Controller
    {
        public IActionResult Get()
        {
            return Ok(new
            {
                Id = 1,
                Title = "Hello from My Protected Controller! [Authorize]",
                Username = this.User.Identity.Name
            });
        }
    }
}