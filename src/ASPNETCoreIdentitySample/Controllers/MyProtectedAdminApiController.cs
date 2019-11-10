using ASPNETCoreIdentitySample.Common.GuardToolkit;
using ASPNETCoreIdentitySample.Services.Contracts.Identity;
using ASPNETCoreIdentitySample.Services.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASPNETCoreIdentitySample.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("CorsPolicy")]
    [Authorize(Policy = ConstantPolicies.DynamicPermission, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    // More info: https://www.dotnettips.info/post/2736/#comment-16140
    //[Authorize(Policy = ...., AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    // Or
    //[Authorize(Policy = ...., AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme + ", " + JwtBearerDefaults.AuthenticationScheme)]
    public class MyProtectedAdminApiController : Controller
    {
        private readonly IApplicationUserManager _usersService;

        public MyProtectedAdminApiController(IApplicationUserManager usersService)
        {
            _usersService = usersService;
            _usersService.CheckArgumentIsNull(nameof(usersService));
        }

        public async Task<IActionResult> Get()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            //var userDataClaim = claimsIdentity.FindFirst(ClaimTypes.UserData);
            //var userId = userDataClaim.Value;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(new
            {
                Id = 1,
                Title = "Hello from My Protected Admin Api Controller! [Authorize(Policy = CustomRoles.Admin)]",
                Username = this.User.Identity.Name,
                UserData = userId,
                TokenSerialNumber = await _usersService.GetSerialNumberAsync(int.Parse(userId)),
                Roles = claimsIdentity.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList()
            });
        }
    }
}