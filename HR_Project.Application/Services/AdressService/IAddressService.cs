using HR_Project.Application.Models.DTOs;
using HR_Project.Application.Models.VMs;
using HR_Project.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.AdressService
{
    public interface IAddressService
    {
        Task<int> UpdateAddressAsync(UpdateAddressDTO addressDTO);
        Task<AddressVM> GetAddressAsync(int addressID);
        Task CreateAddressAsync(Address address);
        Task<List<AddressVM>> GetAllAddressAsync(int companyID);
    }
}
