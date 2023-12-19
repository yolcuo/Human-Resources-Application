using HR_Project.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Entities.Concrete
{
    public class PermissionType:IBaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsPaid { get; set; }
        public int? MaxDays { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
