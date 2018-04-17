using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitoringSystem.Models
{
    public class Parameter
    {
        public int ParameterID { get; set; }
        public int VehicleID { get; set; }
        public int BasicParameterID { get; set; }
        
        public int BasicParameterValue { get; set; }
        public DateTime BasicParameterTimeValue { get; set; }

        public BasicParameter BasicParameter { get; set; }

    }
}
