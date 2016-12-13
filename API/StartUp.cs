using System;
using System.Text;
using API.Auth;
using API.Auth.AuthorizationHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API
{
  public class StartUp
  {
      byte[] tokenSecretKey = Encoding.UTF8.GetBytes("this is my secret key from the server");
      public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

//        services.AddAuthorization(options =>
//        {
//        options.AddPolicy("JwtRequired", policy =>
//        {
//           policy.Requirements.Add(new JwtRequired(new JwtManager()));
//        });
//        });
//
//        services.AddSingleton<IAuthorizationHandler, JwtRequiredHandler>();
    }

      public TokenValidationParameters GettokenValidationParameters()
      {
          return new TokenValidationParameters
          {
              // Token signature will be verified using a private key.
              ValidateIssuerSigningKey = true,
              RequireSignedTokens = true,
              IssuerSigningKey = new SymmetricSecurityKey(tokenSecretKey),

              // Token will only be valid if contains "accelist.com" for "iss" claim.
              ValidateIssuer = false,
             // ValidIssuer = "accelist.com",

              // Token will only be valid if contains "accelist.com" for "aud" claim.
              ValidateAudience = false,
             // ValidAudience = "accelist.com",

              // Token will only be valid if not expired yet, with 5 minutes clock skew.
              //ValidateLifetime = true,
              //RequireExpirationTime = true,
              //ValidateLifetime = true,
              //ClockSkew = new TimeSpan(0, 60, 0),
              //ClockSkew = TimeSpan.Zero,
              ValidateActor = false,
          };
      }
 
    public void Configure(IApplicationBuilder app)
    {
        app.UseJwtBearerAuthentication(new JwtBearerOptions
        {
            AutomaticAuthenticate = true,
            TokenValidationParameters = GettokenValidationParameters(),
        });
        app.UseMvc();
    }
  }
}