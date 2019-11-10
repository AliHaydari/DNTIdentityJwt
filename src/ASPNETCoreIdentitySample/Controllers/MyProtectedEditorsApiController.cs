using ASPNETCoreIdentitySample.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreIdentitySample.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("CorsPolicy")]
    [Authorize(Policy = ConstantPolicies.DynamicPermission, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MyProtectedEditorsApiController : Controller
    {
        public IActionResult Get()
        {
            return Ok(new
            {
                Id = 1,
                Title = "Hello from My Protected Editors Controller! [Authorize(Policy = CustomRoles.Editor)]",
                Username = this.User.Identity.Name
            });
        }
    }
}