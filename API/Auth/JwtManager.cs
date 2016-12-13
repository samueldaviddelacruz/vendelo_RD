using System;
using System.Collections.Generic;
using System.Text;
using Jose;

namespace API.Auth
{
    public  class JwtManager
    {
        readonly byte[] _secretKey = Encoding.UTF8.GetBytes("this is my secret key from the server");
        public static long ToUnixTime(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }
        public  string CreateJwt(string sub)
        {
            var payload = new Dictionary<string, object>
            {
                {"sub", sub },
                //{"nbf",1476997029},
                //{"exp", ToUnixTime(DateTime.Now.Add(TimeSpan.FromDays(20))) },
                //{"iat",1476997029}
            };

            return JWT.Encode(payload, _secretKey, JwsAlgorithm.HS256);

        }

        public bool IsValidJwt(string jwt)
        {

            var payload = JWT.Decode<Dictionary<string, object>>(jwt, _secretKey,JwsAlgorithm.HS256);

            return CreateJwt( payload["sub"].ToString() ).Equals(jwt);
        }


    }
}