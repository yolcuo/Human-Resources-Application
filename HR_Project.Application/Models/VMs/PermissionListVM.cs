using HR_Project.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Models.VMs
{
    public class PermissionListVM
    {
        public List<Permission>? PendingPermissions { get; set; }
        public List<Permission>? AcceptedPermissions { get; set; }
        public List<Permission>? RejectedPermissions { get; set; }
    }
}
