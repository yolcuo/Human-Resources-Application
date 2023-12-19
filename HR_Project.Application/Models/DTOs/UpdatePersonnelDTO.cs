using HR_Project.Application.Models.VMs;
using HR_Project.Domain.CustomValidation;
using HR_Project.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Models.DTOs
{
    public class UpdatePersonnelDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string? Surname { get; set; }
        public string? SecondSurname { get; set; }


        public string? Title { get; set; }
        public string? Photo { get; set; }
        [PhoneNumberCheck]
        public string Phone { get; set; }
        public int AddressID { get; set; }
        public AddressVM? Address { get; set; }
    }
}
