using Microsoft.AspNetCore.Authorization;

namespace API.Auth.AuthorizationHandlers
{
    public class JwtRequired:IAuthorizationRequirement
    {
        protected  JwtManager JwtManager { get; set; }

        public JwtRequired(JwtManager jwtManager)
        {
            JwtManager = jwtManager;
        }

        public bool IsValidJwt(string jwt)
        {

            return JwtManager.IsValidJwt(jwt);
        }

    }
}