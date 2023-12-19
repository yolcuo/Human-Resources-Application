using AutoMapper;
using HR_Project.Application.Models.VMs;
using HR_Project.Application.Services.PersonnelService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using HR_Project.Domain.Repositories;
using HR_Project.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.AdvanceService
{
	public class AdvanceService : IAdvanceService
	{
		private readonly IMapper _mapper;
		private readonly IAdvanceRepository _advanceRepository;
		private readonly IPersonnelRepository _personnelRepository;


		public AdvanceService(IMapper mapper, IAdvanceRepository advanceRepository, UserManager<Personnel> userManager, IPersonnelRepository personnelRepository)
		{

			_mapper = mapper;
			_advanceRepository = advanceRepository;
			_personnelRepository = personnelRepository;
		}

		public async Task CreateAdvanceAsync(Advance advance)
		{
			advance.CreateDate = DateTime.Now;
			await _advanceRepository.AddAsync(advance);
		}

		public async Task<List<Advance>> GetAllAdvanceAsync(int UserId)
		{
			
			return await _advanceRepository.GetAllAsync(x => x.PersonnelID == UserId && x.IsActive == true);

		}
		public async Task<List<Advance>> GetFilteredAdvanceAsync(int UserId, ApprovalStatus approvalStatus)
		{
			
				return await _advanceRepository.GetAllAsync(x => x.PersonnelID == UserId && x.ApprovalStatus == approvalStatus && x.IsActive == true);
		}

		public async Task<Advance> GetAdvanceAsync(int advanceId)
		{
			return await _advanceRepository.GetByIdAsync(advanceId);
		}

        public async Task DeleteAdvanceAsync(int advanceId)
        {
			 await _advanceRepository.DeleteAsync(advanceId);
        }
    }
}
