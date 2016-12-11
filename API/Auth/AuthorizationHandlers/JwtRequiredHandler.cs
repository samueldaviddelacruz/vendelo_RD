using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace API.Auth.AuthorizationHandlers
{
    public class JwtRequiredHandler:AuthorizationHandler<JwtRequired>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, JwtRequired requirement)
        {
            var mvcContext = GetMvcContext(context);
            try
            {
                if (mvcContext == null) return Task.CompletedTask; //Request.Headers["Authorization"]

                var authHeader = GetAuthHeader(mvcContext);
                if (IsHeaderEmpty(authHeader))
                {

                    SendStatusCode(mvcContext,401,"Token Not Found",context,requirement);
                    return Task.CompletedTask;

                }

                var jwt = GetJwtFromHeader(authHeader);
                if (!requirement.IsValidJwt(jwt))
                {
                    SendStatusCode(mvcContext,401,"Unathorized/Invalid Token",context,requirement);
                    return Task.CompletedTask;

                }
                context.Succeed(requirement);

            }
            catch (Exception e)
            {
                SendStatusCode(mvcContext,500,e.Message,context,requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;

        }

        private static void SendStatusCode(AuthorizationFilterContext mvcContext,int statusCode,string message,AuthorizationHandlerContext authContext,IAuthorizationRequirement requirement)
        {
            mvcContext.HttpContext.Response.StatusCode = statusCode;
            mvcContext.Result = new ContentResult
            {
                Content = message
            };
            authContext.Succeed(requirement);

        }

        private static string GetJwtFromHeader(string authHeader)
        {
            return authHeader.Split(' ')[1];
        }

        private static bool IsHeaderEmpty(string authHeader)
        {
            return string.IsNullOrEmpty(authHeader);
        }

        private static string GetAuthHeader(AuthorizationFilterContext mvcContext)
        {
            var authHeader = mvcContext.HttpContext.Request.Headers["Authorization"];
            return authHeader;
        }

        private static AuthorizationFilterContext GetMvcContext(AuthorizationHandlerContext context)
        {
            // Examine MVC specific things like routing data.
            var mvcContext = context.Resource as AuthorizationFilterContext;
            return mvcContext;
        }
    }
}