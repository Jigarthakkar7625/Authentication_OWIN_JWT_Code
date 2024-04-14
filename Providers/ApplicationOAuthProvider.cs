using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Authentication_OWIN_JWT_API.Models;

namespace Authentication_OWIN_JWT_API.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Logic to validate client
            context.Validated();
            return Task.CompletedTask;
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Database >> Username and password

            using (var db = new ATCGSA_WithoutASPNETAuthEntities())
            {
                var username = context.UserName;
                var password = context.Password;

                var getUser = db.tblUsers.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();

                if (getUser != null)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("Age", "16"));
                    identity.AddClaim(new Claim("UserName", getUser.UserName));
                    identity.AddClaim(new Claim("Role", "Admin"));
                    context.Validated(identity);

                    // Role base
                    // Calling method after generating token
                }
                else
                {
                    context.SetError("Invalid", "Invaid Username and password");
                    context.Rejected();
                }

            }


        }

    }
}