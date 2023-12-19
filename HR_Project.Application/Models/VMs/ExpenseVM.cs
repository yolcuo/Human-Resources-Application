using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Models.VMs
{
    public class ExpenseVM
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime? RequestDate { get; set; } = DateTime.Now;
        public DateTime? ReplyDate { get; set; }
        public string? DocumentPath { get; set; }

        public int? ExpenseTypeID { get; set; }
        public ExpenseType? ExpenseType { get; set; }

        public string? CurrencyCode { get; set; }
        public Currency? Currency { get; set; }
    }
}
