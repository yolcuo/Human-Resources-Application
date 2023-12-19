using HR_Project.Domain.CustomValidation;
using HR_Project.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Models.DTOs
{
    public class CreateManagerDTO
    {
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string? Photo { get; set; }

        public DateTime? BirthDate { get; set; }

        [TCNumberCheck]
        public string TC { get; set; } 
        public DateTime? DateOfStartWorking { get; set; }
        public string? Title { get; set; }
        public Company? Company { get; set; }
        public int CompanyID { get; set; }
        public List<Company>? Companies { get; set; }

        public string Email { get; set; }

        [PhoneNumberCheck]
        public string Phone { get; set; }
        public CreateManagerDTO()
        {
            Companies= new List<Company>();
        }

       
    }
}
