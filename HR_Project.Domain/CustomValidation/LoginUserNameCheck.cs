using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.CustomValidation
{
    public class LoginUserNameCheck : ValidationAttribute
    {
        string userName;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           userName = (string)value;
       
            if (userName==null)
                return new ValidationResult("Username can't be empty");
            return ValidationResult.Success;
        }
    }
}
