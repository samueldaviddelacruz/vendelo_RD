using API.DAL;
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
        private MongoDAL<Ad> _mydal;
        public async Task<IEnumerable<Ad>> GetAllAdds()
        {
            //var ad = new Ad();
            ////ad.Id = new ObjectId();
          
            //ad.categoryId = new ObjectId();
            
            //ad.title = "Mueble rojo";
            //ad.description = "Mueble rojo en buenas condiciones";
            //ad.price = 1500;
            //ad.postedBy = new Usuario() {
            //    email ="alphaelena@gmail.com",
            //    phoneNumber="809-594-9550",
            //    displayName="Samuel David"
            //};
            //ad.location = new Location(18.4894982, -69.8499001);
            //ad.uploadDate = DateTime.Now;     
            //var ads = new List<Ad>()
            //{
            //   ad
            //};
            _mydal = new MongoDAL<Ad>();
            var dbAds = await _mydal.GetAll();


            return dbAds;

        }

        [HttpGet("{id}")]
        public async Task<Ad> GetAdById(string id)
        {
            //ObjectId.
            _mydal = new MongoDAL<Ad>();

            var foundAd = await _mydal.FindByObjectIdString(id);

            return foundAd;
        }

        [HttpPost]
        public async Task<IEnumerable<Ad>> GetAdsByProximity([FromBody]Location loc)
        {
            _mydal = new MongoDAL<Ad>();
            var founAds = await _mydal.FindByProximity(loc.getLongitude(),loc.getLatitude(), 5000,ad => ad.location );
            return founAds;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAd([FromBody]Ad ad)
        {
            _mydal = new MongoDAL<Ad>();
            var category = new Category();
            category.categoryName = "Muebles";
            ad.postedBy = new Usuario()
            {
                email = "alphaelena@gmail.com",
                phoneNumber = "809-594-9550",
                displayName = "Samuel David"
            };
            ad.uploadDate = DateTime.Now;
            await _mydal.Insert(ad);
            return StatusCode(200);
        }




    }
}
