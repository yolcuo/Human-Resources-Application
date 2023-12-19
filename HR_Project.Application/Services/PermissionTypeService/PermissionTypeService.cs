using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Repositories;
using HR_Project.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.PermissionTypeService
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public PermissionTypeService(IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task CreatePermissionType(PermissionType permissionType)
        {
            await _permissionTypeRepository.AddAsync(permissionType);
        }

        public async Task<List<PermissionType>> GetAllPermissionTypesAsync()
        {
            return await _permissionTypeRepository.GetAllAsync(p => p.IsActive==true);
        }

        public async Task<PermissionType> GetPermissionTypeAsync(int permissionTypeId)
        {
            return await _permissionTypeRepository.GetByIdAsync(permissionTypeId);
        }

        public async Task<PermissionType> GetPermissionTypeByNameAsync(string Name)
        {
            return await _permissionTypeRepository.GetFirstOrDefaultAsync(p => p.Name == Name);
        }
    }
}
