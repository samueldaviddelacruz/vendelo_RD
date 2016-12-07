using System.Collections.Generic;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.DAL;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
  public class PersonsController : Controller
  {
    MongoDAL<Persona> mydal;
    public PersonsController()
    {
      
    }
    [HttpGet]
    public async Task<IEnumerable<Persona>> GetAll()
    {
     // var newPersona = new Persona(){nombre="Ada",apellido="de la cruz"};
      mydal = new MongoDAL<Persona>();
      //await  mydal.Insert(newPersona);
      var personas =  await mydal.GetAll();

      var searchedPerson = await mydal.FindByObjectID(personas[0].Id);
      return personas;
    }

    [HttpGet("{id}")]
    public async Task<Persona> GetById(string id){
      mydal = new MongoDAL<Persona>();
      var searchedPerson = await mydal.FindByObjectIDString(id);
      return searchedPerson;
    }

  
  




  }
}