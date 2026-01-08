using Duende.IdentityServer.Models;

namespace IdentityService.API
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> { new ApiScope("api1", "Web API Erişim Yetkisi") };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "web_client",

                    // ResourceOwnerPassword: Kullanıcı adı ve şifre ile giriş yapma yetkisi
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "api1", "openid", "profile" }
                }
            };
    }
}
