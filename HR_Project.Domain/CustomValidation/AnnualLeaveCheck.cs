using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.CustomValidation
{
    public class AnnualLeaveCheck : ValidationAttribute
    {
        DateTime DateOfStartWorking;
        int personnelWorkingDay;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateOfStartWorking = (DateTime)value;
           TimeSpan personnelWorkingDay = DateTime.Now-DateOfStartWorking;
            int daysWorked=personnelWorkingDay.Days;
           
            if (daysWorked <365) 
            {
             return new ValidationResult("The required working days for annual leave have not been fulfilled.");
            }
            return base.IsValid(value, validationContext);
        }
    }
}
