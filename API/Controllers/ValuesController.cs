using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
 
namespace aspnetcoreapp.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    [HttpGet]
    public IEnumerable<string> Get()
    {
      //new comment
      return new string[] { "value1", "value2" };
    }
  }
}