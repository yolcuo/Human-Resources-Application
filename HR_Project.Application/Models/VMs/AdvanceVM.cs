using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Models.VMs
{
	public class AdvanceVM
	{
		public int ID { get; set; }
		public decimal Amount { get; set; }
		public DateTime RequestDate { get; set; }
		public DateTime? ReplyDate { get; set; }
		public ApprovalStatus ApprovalStatus { get; set; }
		public string Description { get; set; }
		public int AdvanceTypeID { get; set; }
		public AdvanceType? AdvanceType { get; set; }
		public string CurrencyCode { get; set; }
		public Currency? Currency { get; set; }
	}
}
