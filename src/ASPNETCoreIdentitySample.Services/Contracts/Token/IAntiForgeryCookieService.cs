using System.Collections.Generic;
using System.Security.Claims;

namespace ASPNETCoreIdentitySample.Services.Contracts.Token
{
    public interface IAntiForgeryCookieService
    {
        void RegenerateAntiForgeryCookies(IEnumerable<Claim> claims);
        void DeleteAntiForgeryCookies();
    }
}
