using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;

namespace ASPNETCoreIdentitySample.Services.Contracts.Token
{
    public interface ITokenValidatorService
    {
        Task ValidateAsync(TokenValidatedContext context);
    }
}
