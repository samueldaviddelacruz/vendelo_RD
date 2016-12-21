using API.DAL;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Ad:MongoEntity
    {
        public Category category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public IEnumerable<byte[]> pictures { get; set; }
        //public GeoJsonPoint<GeoJson2DGeographicCoordinates> location { get; set; }
        public Location location { get; set; }
        public Usuario postedBy { get; set; }
        public DateTime uploadDate { get; set; }
     
    }
}
