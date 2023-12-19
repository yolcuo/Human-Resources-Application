using HR_Project.Application.Models.VMs;
using HR_Project.Application.Services.ExpenseService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using HR_Project.Domain.Repositories;
using HR_Project.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly UserManager<Personnel> _userManager;

        public PermissionService(IPermissionRepository permissionRepository, UserManager<Personnel> userManager)
        {
            _permissionRepository = permissionRepository;
            _userManager = userManager;
        }

        public async Task CreatePermissionRequestAsync(Permission permission)
        {
            permission.CreateDate = DateTime.Now;
            await _permissionRepository.AddAsync(permission);
        }

        public async Task<Permission> GetPermissionAsync(int permissionId)
        {
            return await _permissionRepository.GetByIdAsync(permissionId);
        }

        public async Task<List<Permission>> GetPermissionsAsync()
        {
            return await _permissionRepository.GetAllAsync(x => x.IsActive == true);
        }

        public async Task<List<Permission>> GetPermissionsByApprovalStatusAsync(ApprovalStatus approvalStatus,int id)
        {
            var permissions = await _permissionRepository.GetAllAsync(x => x.IsActive == true);
            return permissions.Where(p => p.ApprovalStatus == approvalStatus && p.PersonnelID == id).ToList();
        }

        public async Task<List<Permission>> GetPermissionsByApprovalStatusAsync(ApprovalStatus approvalStatus, int id, params Expression<Func<Permission, object>>[] includes)
        {
            var permissions = await _permissionRepository.GetAllAsync(x => x.IsActive == true,p => p.PermissionType);
            return permissions.Where(p => p.ApprovalStatus == approvalStatus && p.PersonnelID == id).ToList();
        }

        public async Task RemovePermission(int id)
        {
            await _permissionRepository.RemoveFromTableAsync(id);
        }
    }
}
