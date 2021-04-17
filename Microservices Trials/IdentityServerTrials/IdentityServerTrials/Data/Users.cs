using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerTrials.Data
{
    internal class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="5BE86359-073C-434B-ADZD-A3932222DABE",
                    Username="RUCHIT",
                    Password="Lolpass@123",
                    Claims= new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email,"ruchit@bn.sys"),
                        new Claim(JwtClaimTypes.Role,"admin")
                    }
                }
            };
        }
    }
}
