using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.ExpenseTypeService
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly    IExpenseTypeRepository _expenseTypeRepository;


        public ExpenseTypeService(IExpenseTypeRepository expenseTypeRepository)
        {
            _expenseTypeRepository = expenseTypeRepository;
        }

        public async Task CreateExpenseTypeAsync(ExpenseType expenseType)
        {
            await _expenseTypeRepository.AddAsync(expenseType);
        }


        public async Task<List<ExpenseType>> GetAllExpenseTypesAsync()
        {
            return await _expenseTypeRepository.GetAllAsync(x=> x.IsActive == true);
        }

        //public async Task<List<ExpenseType>> GetAllExpenseTypesAsync(Expression<Func<ExpenseType, bool>> predicate)
        //{
        //    return await _expenseTypeRepository.GetAllAsync(predicate);
        //}

        public async Task<ExpenseType> GetExpenseTypeAsync(int expenseTypeId)
        {
            return await _expenseTypeRepository.GetByIdAsync(expenseTypeId);
        }
    }
}
