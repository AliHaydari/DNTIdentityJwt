using ASPNETCoreIdentitySample.Entities.AuditableEntity;
using System;

namespace ASPNETCoreIdentitySample.Entities.Identity
{
    public class JwtUserToken : IAuditableEntity
    {
        public int Id { get; set; }

        public string AccessTokenHash { get; set; }

        public DateTimeOffset AccessTokenExpiresDateTime { get; set; }

        public string RefreshTokenIdHash { get; set; }

        public string RefreshTokenIdHashSource { get; set; }

        public DateTimeOffset RefreshTokenExpiresDateTime { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
