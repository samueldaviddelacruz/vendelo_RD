using System;
using System.Collections.Generic;
using Jose;

namespace API.Auth
{
    public  class JwtManager
    {
        readonly byte[] _secretKey = {164,60,194,0,161,189,41,38,130,89,141,164,45,170,159,209,69,137,243,216,191,131,47,250,32,107,231,117,37,158,225,234};

        public  string CreateJwt(string sub)
        {
            var payload = new Dictionary<string, object>
            {
                { "sub", sub },
                { "exp", 1300819380 }
            };

            return JWT.Encode(payload, _secretKey, JwsAlgorithm.HS256);

        }

        public bool IsValidJwt(string jwt)
        {

            var payload = JWT.Decode<Dictionary<string, object>>(jwt, _secretKey,JwsAlgorithm.HS256);

            return CreateJwt(payload["sub"].ToString()).Equals(jwt);
        }


    }
}