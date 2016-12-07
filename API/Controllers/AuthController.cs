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
    public void LocalRegister()
    {
    
    }

    [HttpPost]
    public void Login()
    {
    
    }

  }
}