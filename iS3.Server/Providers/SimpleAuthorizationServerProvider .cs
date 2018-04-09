using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iS3.Server.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        class User
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        private User[] users = new User[]
        {
            new User{username="linxiaodong", password="lxd"},
            new User{username="lixiaojun", password="lxj"},
            new User{username="yudenghua", password="ydh"},
            new User{username="zhuweijia", password="zwj"},
            new User{username="chenchao", password="cc"},
            new User{username="xiyue", password="xy"}
        };
        
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            User user = users.FirstOrDefault((u) => u.username == context.UserName && u.password == context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            //identity.AddClaim(new Claim("sub", context.UserName));
            //identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);

        }
    }
}