using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.CustomValidation
{
    public class PersonnelAgeCheck : ValidationAttribute
    {
        DateTime birthDate;
        int personnelAge;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            birthDate = (DateTime)value;
            personnelAge = DateTime.Now.Year - birthDate.Year;
            if (personnelAge >= 18)
                return new ValidationResult("The Age of the Personnel Cannot Be Younger Than '18'!");
            return base.IsValid(value, validationContext);
        }
    }
}
