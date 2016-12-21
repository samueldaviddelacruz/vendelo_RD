using API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
            ad.Id = new ObjectId();
            ad.category = new Category();
            ad.category.Id = new ObjectId();
            ad.category.categoryName = "Hogar y Personal";
            ad.title = "Mueble rojo";
            ad.description = "Mueble rojo en buenas condiciones";
            ad.price = 1500;
            ad.postedBy = new Usuario() {
                email ="alphaelena@gmail.com",
                phoneNumber="809-594-9550",
                displayName="Samuel David"
            };
            ad.location = new Location(18.4894982, -69.8499001);

            ad.uploadDate = DateTime.Now;
           
            var ads = new List<Ad>()
            {
               ad
            };

            return ads;

        }

    }
}
