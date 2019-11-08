using System;

namespace ASPNETCoreIdentitySample.Services.Contracts.Token
{
    public interface ISecurityService
    {
        string GetSha256Hash(string input);
        Guid CreateCryptographicallySecureGuid();
    }
}