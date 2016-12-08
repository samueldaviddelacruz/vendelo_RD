using System.Collections.Generic;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.DAL;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        MongoDAL<Persona> mydal;

        [HttpPost]
        public IActionResult LocalRegister([FromBody] Usuario newUsuario)
        {
            return Created("LocalLogin", new { newUsr = newUsuario });
        }

        [HttpGet]
        public IActionResult LocalLogin()
        {
            return StatusCode(200);
        }

    }
}