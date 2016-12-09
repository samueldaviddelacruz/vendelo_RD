using Microsoft.AspNetCore.Authorization;

namespace API.Auth.AuthorizationHandlers
{
    public class JwtRequired:IAuthorizationRequirement
    {
        protected  JwtManager _jwtManager { get; set; }

        public JwtRequired(JwtManager jwtManager)
        {
            _jwtManager = jwtManager;
        }

    }
}