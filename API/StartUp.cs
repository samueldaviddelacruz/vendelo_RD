using API.Auth;
using API.Auth.AuthorizationHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
 
namespace API
{
  public class StartUp
  {
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddAuthorization(options =>
        {
        options.AddPolicy("JwtRequired", policy =>
        {
           policy.Requirements.Add(new JwtRequired(new JwtManager()));
        });
        });

        services.AddSingleton<IAuthorizationHandler, JwtRequiredHandler>();
    }
 
    public void Configure(IApplicationBuilder app)
    {
      app.UseMvc();
    }
  }
}