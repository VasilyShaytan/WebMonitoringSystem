using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitoringSystem.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Mark { get; set; }
        public string ModelType { get; set; }
        public int СarryingСapacity { get; set; }
        public int YearIssue { get; set; }
        public int UsefulVolume { get; set; }
        public string VehicleType { get; set; }
        public string OverallDimensions { get; set; }


        //public string PlaceName { get; set; } // название места
        //public double Traffic { get; set; } // пассажиропоток
        //public string Line { get; set; } // линия метро
        //public double GeoLong { get; set; } // долгота - для карт google
        //public double GeoLat { get; set; } // широта - для карт google
    }
}
