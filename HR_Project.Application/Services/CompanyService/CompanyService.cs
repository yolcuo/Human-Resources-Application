using AutoMapper;
using HR_Project.Application.Models.DTOs;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task CreateCompanyAsync(Company company)
        {
            
            await companyRepository.AddAsync(company);
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await companyRepository.GetAllAsync(x => x.IsActive == true);
        }

        public async Task<List<Company>> GetCompaniesAsync(Expression<Func<Company, bool>> predicate, params Expression<Func<Company, object>>[] includes)
        {
            return await companyRepository.GetAllAsync(c=>c.IsActive == true,c => c.Addresses);
        }

        public async Task<Company> GetCompanyAsync(int companyID)
        {
            return await companyRepository.GetByIdAsync(companyID);
        }

        public async Task RemoveCompany(int id)
        {
            await companyRepository.DeleteAsync(id);
        }

        public async Task<Company> GetCompanyAsync(Company company)
        {
            return await companyRepository.GetFirstOrDefaultAsync(c=>c.CompanyName==company.CompanyName);
        }

    }
}
