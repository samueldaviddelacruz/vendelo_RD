using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
 
namespace API
{
  public class StartUp
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }
 
    public void Configure(IApplicationBuilder app)
    {
      app.UseMvc();
    }
  }
}