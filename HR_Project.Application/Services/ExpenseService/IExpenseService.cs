using HR_Project.Application.Models.DTOs;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.ExpenseService
{
    public interface IExpenseService
    {
        Task CreateExpenseRequestAsync(CreateExpenseDTO expense);

        Task<List<Expense>> GetAllExpensesAsync(int UserId);
        Task<List<Expense>> GetFilteredExpenseAsync(int UserId, ApprovalStatus approvalStatus);
        Task UploadExpenseDocumentAsync(int expenseID, string documentPath);
        Task<Expense> GetExpenseAsync(int expenseID);

        Task RemoveExpense(int id);

        //Task<List<Currency>> GetAllCurrenciesAsync(Expression<Func<Currency, bool>> predicate);
        //Task<List<ExpenseType>> GetAllExpenseTypesAsync(Expression<Func<ExpenseType, bool>> predicate);
    }
}
