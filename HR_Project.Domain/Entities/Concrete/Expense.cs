using HR_Project.Domain.Entities.Abstract;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Entities.Concrete
{
    public class Expense :IBaseEntity
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Pending;
        public DateTime? RequestDate { get; set; }= DateTime.Now;
        public DateTime? ReplyDate { get; set; }
        public string? DocumentPath { get; set; }

        public int ExpenseTypeID { get; set; }
        public ExpenseType?  ExpenseType { get; set; }

        public string? CurrencyCode { get; set; }
        public Currency? Currency { get; set; }

        public DateTime CreateDate { get; set; }=DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
		public int? PersonnelID { get; set; }
		public Personnel? Personnel { get; set; }
	}
}
