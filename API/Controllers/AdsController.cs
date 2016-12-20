using API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AdsController : Controller
    {
        public IEnumerable<Ad> GetAllAdds()
        {
            var ad = new Ad();

            ad.category.categoryName = "Hogar y Personal";
           
           
           
            var ads = new List<Ad>()
            {
               


            };

            return ads;

        }

    }
}
