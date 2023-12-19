using AutoMapper;
using HR_Project.Application.Models.DTOs;
using HR_Project.Application.Models.VMs;
using HR_Project.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.AutoMapper
{
    public class HRMapper :Profile
    {
        public HRMapper()
        {
            CreateMap<Address, AddressVM>()
                .ForMember(x => x.ID, x => x.MapFrom(y => y.ID))
                .ForMember(x => x.City, x => x.MapFrom(y => y.City))
                .ForMember(x => x.District, x => x.MapFrom(y => y.District))
                .ForMember(x => x.Neighbourhood, x => x.MapFrom(y => y.Neighbourhood))
                .ForMember(x => x.Street, x => x.MapFrom(y => y.Street))
                .ForMember(x => x.Detail, x => x.MapFrom(y => y.Detail))
                .ReverseMap();

            CreateMap<Address, UpdateAddressDTO>()
                .ForMember(x => x.ID, x => x.MapFrom(y => y.ID))
                .ForMember(x => x.City, x => x.MapFrom(y => y.City))
                .ForMember(x => x.District, x => x.MapFrom(y => y.District))
                .ForMember(x => x.Neighbourhood, x => x.MapFrom(y => y.Neighbourhood))
                .ForMember(x => x.Street, x => x.MapFrom(y => y.Street))
                .ForMember(x => x.Detail, x => x.MapFrom(y => y.Detail))
                .ReverseMap();
            CreateMap<Advance, AdvanceVM>().ReverseMap();
            CreateMap<Advance, AdvanceCreateDTO>().ReverseMap();

            CreateMap<Expense, ExpenseVM>().ReverseMap();
            
            CreateMap<Expense, CreateExpenseDTO>().ReverseMap();

            CreateMap<Company, CreateCompanyDTO>().ReverseMap();

            CreateMap<Company, CompanyListVM>().ReverseMap();
            CreateMap<Personnel, CreateManagerDTO>().ReverseMap();
        }
    }
}
