using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitoringSystem.Models
{
    public class VehicleToVehicleGroup
    {
        public int VehicleToVehicleGroupID { get; set; }
        public int VehicleGroupID { get; set; }
        public int VehicleID { get; set; }

        public VehicleGroup VehicleGroup { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
