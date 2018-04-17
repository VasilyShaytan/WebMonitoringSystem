using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitoringSystem.Models
{
    public class BasicParameter
    {
        public int BasicParameterID { get; set; }
        public int PGN { get; set; }
        public int PGL { get; set; }
        public string Acronym { get; set; }
        public string SPNName { get; set; }
        public string SPNNameRu { get; set; }
        public string DataRange { get; set; }
        public string DataSource { get; set; }
    }
}
