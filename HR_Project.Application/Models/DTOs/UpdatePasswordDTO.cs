using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR_Project.Application.Models.DTOs
{
    public class UpdatePasswordDTO
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Old Password")]
        public string LastPassword { get; set; }
        [Required]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [Display(Name = "New Password Again")]
        [Compare("NewPassword", ErrorMessage = "New Password Don't Match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
