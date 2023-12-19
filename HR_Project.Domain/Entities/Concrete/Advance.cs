using HR_Project.Domain.Entities.Abstract;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Entities.Concrete
{
    public class Advance : IBaseEntity
    {
		public int ID { get; set; }
		public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ReplyDate { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public string Description { get; set; }
        public int AdvanceTypeID { get; set; }
        public AdvanceType AdvanceType { get; set; }
        public string CurrencyCode { get; set; }
        public Currency Currency { get; set; }
        public int? PersonnelID { get; set; }
        public Personnel? Personnel { get; set; }

    }
}
