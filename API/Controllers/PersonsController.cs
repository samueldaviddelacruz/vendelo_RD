using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.DAL;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
  public class PersonsController : Controller
  {
      private MongoDAL<Persona> _mydal;

      [HttpGet]
      //[Authorize(Policy="JwtRequired")]
      [Authorize]
      public async Task<IEnumerable<Persona>> GetAll()
    {


      _mydal = new MongoDAL<Persona>();

      var personas =  await _mydal.GetAll();


      return personas;
    }

    [HttpGet("{id}")]
    public async Task<Persona> GetById(string id){
      _mydal = new MongoDAL<Persona>();
      var searchedPerson = await _mydal.FindByObjectIdString(id);
      return searchedPerson;
    }

  
  




  }
}