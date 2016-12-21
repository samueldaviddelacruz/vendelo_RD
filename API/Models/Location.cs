using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Location
    {
        public string type { get; } = "Point";
        public double[] coordinates { get; } = { 0, 0 };

        public Location(double longitude, double latitude)
        {
            coordinates[0] = longitude;
            coordinates[1] = latitude;
        }

    }
}
