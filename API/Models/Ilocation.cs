using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    interface Ilocation
    {
        string type { get; set; }
        double[] coordinates { get; set; }
        double getLongitude();
        double getLatitude();
    }
}
