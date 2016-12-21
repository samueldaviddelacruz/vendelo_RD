using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Location
    {
        public string type { get; set; } = "Point";
        public double[] coordinates { get; set; } = { 0, 0 };
     
        public Location(double longitude, double latitude)
        {
            coordinates[0] = longitude;
            coordinates[1] = latitude;
        }

        public double getLongitude()
        {
            return coordinates[0];
        }

        public double getLatitude()
        {
            return coordinates[1];
        }

    }
}
