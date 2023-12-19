using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.AdvanceTypeService
{
	public interface IAdvanceTypeService
	{
		Task CreateAdvanceTypeAsync(AdvanceType advanceType);
		Task<List<AdvanceType>> GetAllAdvanceTypeAsync();
		Task<AdvanceType> GetAdvanceTypeAsync(int advanceTypeId);
	}
}
