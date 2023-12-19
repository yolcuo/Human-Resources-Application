using AutoMapper;
using HR_Project.Application.Models.DTOs;
using HR_Project.Application.Services.ExpenseTypeService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using HR_Project.Domain.Repositories;
using HR_Project.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services.ExpenseService
{
    public class ExpenseService : IExpenseService
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IExpenseRepository _expenseRepository;

        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper, IPersonnelRepository personnelRepository)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _personnelRepository = personnelRepository;
        }

        public async Task CreateExpenseRequestAsync(CreateExpenseDTO expense)
        {
            Expense newExpense = new Expense();
            _mapper.Map(expense, newExpense);
            await _expenseRepository.AddAsync(newExpense);
        }


        public async Task<List<Expense>> GetAllExpensesAsync(int UserId)
        {
            return await _expenseRepository.GetAllAsync(x => x.PersonnelID == UserId && x.IsActive == true);
        }

        public async Task UploadExpenseDocumentAsync(int expenseID, string documentPath)
        {
            var expense = await _expenseRepository.GetByIdAsync(expenseID);
            if (expense != null)
            {
                expense.DocumentPath = documentPath;
                await _expenseRepository.UpdateAsync(expense);
            }
        }

        public async Task<Expense> GetExpenseAsync(int expenseID)
        {
            return await _expenseRepository.GetByIdAsync(expenseID);
        }

        public async Task<List<Expense>> GetFilteredExpenseAsync(int UserId, ApprovalStatus approvalStatus)
        {
            return await _expenseRepository.GetAllAsync(x => x.PersonnelID == UserId && x.ApprovalStatus == approvalStatus && x.IsActive == true);
        }

        public async Task RemoveExpense(int id)
        {
            await _expenseRepository.RemoveFromTableAsync(id);
        }
    }
}
