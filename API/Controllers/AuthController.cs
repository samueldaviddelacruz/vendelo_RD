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
                return StatusCode(200, new {newUser = newUsuario, jwt = token});
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
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

                return StatusCode(400, new{error=e.Message});
            }

            return StatusCode(400, new{error="Invalid Username/password"});
        }

    }
}