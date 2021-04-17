using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerTrials.Data
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="oauthClient",
                    ClientName="Example client application using client credentials",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets= new List<Secret>{new Secret("SuperSecretPassword".Sha256())},
                    AllowedScopes= new List<string>{"api1.read"}
                },
                new Client
                {
                    ClientId="oidcClient",
                    ClientName="Example Client Application",
                    ClientSecrets= new List<Secret>{new  Secret("SuperSecretPassword".Sha256())},
                    AllowedGrantTypes= GrantTypes.Code,
                    RedirectUris= new List<string>{ "https://localhost:44327/signin-oidc" },
                    AllowedScopes= new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "api1.read"
                    },
                    RequirePkce=true,
                    AllowPlainTextPkce=false
                },
                new Client
                {
                    ClientId="oidcClient1",
                    ClientName="Example Client Application1",
                    ClientSecrets= new List<Secret>{new  Secret("SuperSecretPassword1".Sha256())},
                    AllowedGrantTypes= GrantTypes.Code,
                    RedirectUris= new List<string>{ "https://localhost:44339/signin-oidc" },
                    AllowedScopes= new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "api1.read"
                    },
                    RequirePkce=true,
                    AllowPlainTextPkce=false
                }
            };
        }
    }
}
