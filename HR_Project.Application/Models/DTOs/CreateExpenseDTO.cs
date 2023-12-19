using HR_Project.Domain.CustomValidation;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR_Project.Application.Models.DTOs
{
    public class CreateExpenseDTO
    {
        
        public decimal Amount { get; set; }
        public int ExpenseTypeID { get; set; }
        public string CurrencyCode { get; set; }
        public List<Currency> CurrencyCodeOptions { get; set; }
        public List<ExpenseType> ExpenseTypes { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public int PersonnelID { get; set; }
        public string DocumentPath { get; set; }
        public IFormFile DocumentFile { get; set; }
        public CreateExpenseDTO()
        {
            CurrencyCodeOptions = new List<Currency>();
            ExpenseTypes = new List<ExpenseType>();
        }

    }
}
