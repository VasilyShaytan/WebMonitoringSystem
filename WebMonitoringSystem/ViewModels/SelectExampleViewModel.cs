using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitoringSystem.ViewModels
{
    public class SelectExampleViewModel1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SelectExampleViewModel2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SelectExampleViewModels
    {
        public List<SelectExampleViewModel1> ViewModels1;
        public List<SelectExampleViewModel2> ViewModels2;
    }
}
