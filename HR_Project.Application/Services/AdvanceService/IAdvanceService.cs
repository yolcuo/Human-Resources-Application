using HR_Project.Application.Models.VMs;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.AdvanceService
{
	public interface IAdvanceService
	{
		Task CreateAdvanceAsync(Advance advance);
		Task<List<Advance>> GetAllAdvanceAsync(int UserId);
		Task<List<Advance>> GetFilteredAdvanceAsync(int UserId, ApprovalStatus approvalStatus);
		Task<Advance> GetAdvanceAsync(int advanceId);
		Task DeleteAdvanceAsync(int advanceId);

		
	}
}
