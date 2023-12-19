using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.CustomValidation
{
    public class LoginPasswordCheck : ValidationAttribute
    {
        string password;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            password = (string)value;

            if (password == null)
                return new ValidationResult("Username can't be empty");
            return base.IsValid(value, validationContext);
        }
    }
}
