using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.CustomValidation
{
    public class PhoneNumberCheck : ValidationAttribute
    {
        string phoneNumber = string.Empty;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            phoneNumber = (string)value;

            foreach (char i in phoneNumber)
            {
                if (!char.IsDigit(i))
                {
                    return new ValidationResult("Phone Number Should Consist of Numbers Only!");
                }
            }
            //return base.IsValid(value, validationContext);
            //return GetValidationResult(value, validationContext);

            return ValidationResult.Success;
        }
    }
}
