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
        [HttpGet()]
        public async Task<IEnumerable<Ad>> GetAllAdds()
        {
           
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

        [HttpGet("{lng}|{lat}|{distanceInMeters}")]
        public async Task<IEnumerable<Ad>> GetAdsByProximity(double lng,double lat,int distanceInMeters=3000)
        {
            _mydal = new MongoDAL<Ad>();
            var founAds = await _mydal.FindByProximity(lng, lat, distanceInMeters, ad => ad.location );
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
                displayName = "Samuel David-"
            };
            ad.uploadDate = DateTime.Now;
            await _mydal.Insert(ad);
            return StatusCode(200);
        }




    }
}
