using HR_Project.Application.Models.DTOs;
using HR_Project.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.PersonnelService
{
    public interface IPersonnelService
    {
        Task<SignInResult> LoginAsync(LoginDTO loginDTO);
        Task Logout();
        Task<Personnel> GetPersonnelDetailsAsync(int personnelId);
        Task<Personnel> GetPersonnelAsync(Expression<Func<Personnel, bool>> predicate);
        Task<IdentityResult> UpdatePersonnelAsync(UpdatePersonnelDTO personnelDTO);
        Task<IdentityResult> UpdatePasswordAsync(UpdatePasswordDTO updatePasswordDTO);
        Task<IdentityResult> CreateManagerAsync(CreateManagerDTO ceateManagerDTO, string email);
		Task<List<Personnel>> GetAllManagerAsync();
		Task<List<Personnel>> GetAllPersonnels(Expression<Func<Personnel, bool>> predicate);
		Task RemovePersonnel(Personnel personnel);


	}
 
	
}
