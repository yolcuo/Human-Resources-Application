using HR_Project.Application.Models.DTOs;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.CompanyService
{
    public interface ICompanyService
    {
        Task CreateCompanyAsync(Company company);
        Task<List<Company>> GetCompaniesAsync();
        Task<List<Company>> GetCompaniesAsync(Expression<Func<Company, bool>> predicate, params Expression<Func<Company, object>>[] includes);
        Task<Company> GetCompanyAsync(int companyID);
        Task RemoveCompany(int id);
        Task<Company> GetCompanyAsync(Company company);
    }
}
