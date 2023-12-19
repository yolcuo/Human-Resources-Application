using HR_Project.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.ExpenseTypeService
{
    public interface IExpenseTypeService
    {
        Task CreateExpenseTypeAsync(ExpenseType expenseType);
        Task<List<ExpenseType>> GetAllExpenseTypesAsync();
        //Task<List<ExpenseType>> GetAllExpenseTypesAsync(Expression<Func<ExpenseType, bool>> predicate);
        Task<ExpenseType> GetExpenseTypeAsync(int expenseTypeId);
    }
}
