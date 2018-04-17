using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitoringSystem.Models
{
    public class UserToRole
    {
        public int UserToRoleID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
