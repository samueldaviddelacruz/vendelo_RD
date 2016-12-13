using System;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

using API.Auth;
using API.DAL;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {

        private JwtManager _jwtManager = new JwtManager();
        private LocalAuth _localAuthManager = new LocalAuth();

        [HttpPost]
        public async Task<IActionResult> LocalRegister([FromBody] Usuario newUsuario)
        {
            try
            {
                await _localAuthManager.RegisterUser(newUsuario);
                var token = _jwtManager.CreateJwt(newUsuario.email);

                var userCredentials = new {newUsuario.email, token};

                return StatusCode(200, userCredentials);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LocalLogin([FromBody] Usuario usuario)
        {
            try
            {
                if (await _localAuthManager.IsValidUser(usuario.email, usuario.password))
                {

                    return StatusCode(200, new{jwt=_jwtManager.CreateJwt(usuario.email)});
                }
            }
            catch (Exception e)
            {

                return StatusCode(401, new{error=e.Message});
            }

            return StatusCode(401, new{error="Invalid Username/password"});
        }

    }
}