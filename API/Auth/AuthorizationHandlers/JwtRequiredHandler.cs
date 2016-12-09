using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;

namespace API.Auth.AuthorizationHandlers
{
    public class JwtRequiredHandler:AuthorizationHandler<JwtRequired>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, JwtRequired requirement)
        {
            var mvcContext = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;

            if (mvcContext == null) return Task.CompletedTask; //Request.Headers["Authorization"]
            // Examine MVC specific things like routing data.
            var authHeader = mvcContext.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader))
            {
                return Task.CompletedTask;
            }




            Console.WriteLine("Token? "+authHeader);
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}