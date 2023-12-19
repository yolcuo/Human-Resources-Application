using HR_Project.Application.Models.VMs;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Repositories;
using HR_Project.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.AdvanceTypeService
{
	public class AdvanceTypeService : IAdvanceTypeService
	{
		private readonly IAdvanceTypeRepository _advanceTypeRepository;

		public AdvanceTypeService(IAdvanceTypeRepository advanceTypeRepository)
		{
			_advanceTypeRepository = advanceTypeRepository;
		}

		public Task CreateAdvanceTypeAsync(AdvanceType advanceType)
		{
			throw new NotImplementedException();
		}

		public async Task<AdvanceType> GetAdvanceTypeAsync(int advanceTypeId)
		{
			return await _advanceTypeRepository.GetByIdAsync(advanceTypeId);
		}

		public async Task<List<AdvanceType>> GetAllAdvanceTypeAsync()
		{
			return await _advanceTypeRepository.GetAllAsync(x=>x.IsActive==true);
		}
	}
}
