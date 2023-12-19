using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.CurrencyService
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }


        public async Task CreateCurrencyAsync(Currency currency)
        {
            await _currencyRepository.AddAsync(currency);
        }

        public async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            //return await _currencyRepository.GetAllAsync(predicate);
            return await _currencyRepository.GetAllAsync(x => x.IsActive == true);
        }


        public async Task<Currency> GetCurrencyAsync(string currencyCode)
        {
            return await _currencyRepository.GetByCodeAsync(currencyCode);
        }


    }
}
