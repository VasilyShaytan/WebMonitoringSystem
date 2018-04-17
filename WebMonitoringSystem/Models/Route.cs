using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitoringSystem.Models
{
    public class Route
    {
        public int RouteID { get; set; }
        public int VehicleID { get; set; }
        public double CoordinateLatitude { get; set; }
        public double CoordinateLongitude { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
