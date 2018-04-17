using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitoringSystem.ViewModels
{
    public class VehicleGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class VehicleGroupViewModels
    {
        public List<VehicleGroupModel> VehicleGroupViewModelList;
    }
}
