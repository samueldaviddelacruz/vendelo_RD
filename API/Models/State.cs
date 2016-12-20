using API.DAL;
using System.Collections.Generic;

namespace API.Models
{
    public class State : MongoEntity
    {
        public string StateName { get; set; }
        public List<City> cities { get; set; }

    }
}