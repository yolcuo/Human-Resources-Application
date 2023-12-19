using HR_Project.Domain.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Models.DTOs
{
    public class LoginDTO
    {
        //[LoginUserNameCheck]
        //[Required(ErrorMessage = "Alan boş geçilemez")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Alan boş geçilemez")]
        public string Password { get; set; }
    }
}
