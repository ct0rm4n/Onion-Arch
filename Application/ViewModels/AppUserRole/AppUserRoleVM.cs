using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.AppUser;
using ViewModels.AppRole;

namespace ViewModels.AppUserRole
{
    public class AppUserRoleVM
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        //public bool isAssigned { get; set; }
        public AppUserVM AppUserVM { get; set; }
        public AppRoleVM AppRoleVM { get; set; }
    }
}
