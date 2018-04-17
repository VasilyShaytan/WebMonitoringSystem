using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitoringSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserSurname{ get; set; }
        public string UserPhone { get; set; }
        public int UserRole { get; set; }
    }
}
