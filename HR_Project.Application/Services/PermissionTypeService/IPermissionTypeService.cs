using HR_Project.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.PermissionTypeService
{
    public interface IPermissionTypeService
    {
        Task CreatePermissionType(PermissionType permissionType);
        Task<PermissionType> GetPermissionTypeAsync(int permissionTypeId);
        Task<PermissionType> GetPermissionTypeByNameAsync(string Name);
        Task<List<PermissionType>> GetAllPermissionTypesAsync();
    }
}
