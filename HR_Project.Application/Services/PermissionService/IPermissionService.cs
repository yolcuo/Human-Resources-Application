using HR_Project.Application.Models.VMs;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.PermissionService
{
    public interface IPermissionService
    {
        Task CreatePermissionRequestAsync(Permission permission);
        Task<List<Permission>> GetPermissionsAsync();
        Task<Permission> GetPermissionAsync(int permissionId);
        Task<List<Permission>> GetPermissionsByApprovalStatusAsync(ApprovalStatus approvalStatus,int id);
        Task<List<Permission>> GetPermissionsByApprovalStatusAsync(ApprovalStatus approvalStatus,int id, params Expression<Func<Permission, object>>[] includes);
        Task RemovePermission(int id);
    }
}
