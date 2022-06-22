using System.Text;
using CPTM.ABI.WebApi;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace CPTM.ABI.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost/ABI", //some string, normally web url,  
                    ValidAudience = "http://localhost/ABI",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DESABI_TOKEN_DEV"))
                }
            });
        }
    }
}