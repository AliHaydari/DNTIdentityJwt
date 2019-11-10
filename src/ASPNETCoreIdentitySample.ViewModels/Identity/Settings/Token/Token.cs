using System.Text.Json.Serialization;

namespace ASPNETCoreIdentitySample.ViewModels.Identity.Settings.Token
{
    public class Token
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
