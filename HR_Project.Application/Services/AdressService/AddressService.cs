using AutoMapper;
using HR_Project.Application.Models.DTOs;
using HR_Project.Application.Models.VMs;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Repositories;
using HR_Project.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.AdressService
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task CreateAddressAsync(Address address)
        {
            await _addressRepository.AddAsync(address);
        }

        public async Task<AddressVM> GetAddressAsync(int addressID)
        {
            var address = await _addressRepository.GetFirstOrDefaultAsync(x => x.ID == addressID);

            AddressVM addressVM = new AddressVM();
            _mapper.Map(address, addressVM);
            return addressVM;
        }

        public async Task<List<AddressVM>> GetAllAddressAsync(int companyID)
        {
            var addresses =  await _addressRepository.GetAllAsync(x => x.CompanyID == companyID && x.IsActive == true);
            List<AddressVM> listAddressVM = new List<AddressVM>();
            foreach (var address in addresses)
            {
                AddressVM addressVM = new AddressVM();
                _mapper.Map(address, addressVM);
                listAddressVM.Add(addressVM);
            }
            return listAddressVM;
        }


        public async Task<int> UpdateAddressAsync(UpdateAddressDTO addressDTO)
        {
            Address address = new Address();
            _mapper.Map(addressDTO, address);
            return await _addressRepository.UpdateAsync(address);
            
        }
    }
}
