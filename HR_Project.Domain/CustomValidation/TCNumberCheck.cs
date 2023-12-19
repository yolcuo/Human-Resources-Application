using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.CustomValidation
{
    public class TCNumberCheck:ValidationAttribute
    {
        string TC = string.Empty;
        int[] TCNumbers = new int[11];
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            TC = (string)value;
            int counter = 0;

            if (TC.Length == 11)
            {
                int ilkKarakter = int.Parse(TC[0].ToString());
                if (ilkKarakter == 0)
                {
                    return new ValidationResult("The First Character of The TC Number's Cannot Be '0'!");
                }

                foreach (char i in TC)
                {
                    if (!char.IsDigit(i))
                    {
                        return new ValidationResult("TC Number Should Consist of Numbers Only!");
                    }
                    TCNumbers[counter] = int.Parse(i.ToString());
                    counter++;
                }

                return ValidationResult.Success;
            }
            return new ValidationResult("TC Number Must Be 11 Characters!");
        }
    }
}
