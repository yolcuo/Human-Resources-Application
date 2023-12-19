using HR_Project.Domain.Entities.Abstract;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Entities.Concrete
{
    public class Permission : IBaseEntity
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ReplyDate { get; set; }
        public decimal NumberOfDays { get; set; } //yarım gün izinler için decimal olarak oluşturuldu.
        public ApprovalStatus? ApprovalStatus { get; set; }
        public int PersonnelID { get; set; }
        public int PermissionTypeID { get; set; }
        public PermissionType? PermissionType { get; set; }
		public Personnel? Personnel { get; set; }
	}
}
