
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Models.VMs
{
    public class PermissionCreateVM
    {
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int PermissionTypeID { get; set; }
        public List<PermissionType> PermissionTypes { get; set; }
    }
}
