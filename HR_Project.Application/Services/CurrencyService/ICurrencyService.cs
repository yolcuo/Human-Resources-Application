
using HR_Project.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.CurrencyService
{
    public interface ICurrencyService
    {
        Task CreateCurrencyAsync(Currency currency);
        Task<List<Currency>> GetAllCurrenciesAsync();
        //Task<List<Currency>> GetAllCurrenciesAsync(Expression<Func<Currency, bool>> predicate);
        Task<Currency> GetCurrencyAsync(string currencyCode);
    }
}
