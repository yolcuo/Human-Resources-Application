using HR_Project.Domain.CustomValidation;
using HR_Project.Domain.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Entities.Concrete
{
    public class Personnel : IdentityUser<int>,IBaseEntity
    {
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string Photo { get; set; }

        [PersonnelAgeCheck]
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }

        [TCNumberCheck]
        public string TC { get; set; } //ID olarak kullanılabilir
        public DateTime DateOfStartWorking { get; set; }
        public DateTime? DateOfStopWorking { get; set; }
        public string Title { get; set; }
        public string? CompanyName { get; set; }
        public Company? Company { get; set; }
        public int? CompanyID { get; set; }
        public string Department { get; set; }
  
        public string Email { get; set; }

        //[PhoneNumberCheck]
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        //public string Password { get; set; }
        public int? AddressID { get; set; }
        public Address? Address {get; set;}
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Expense>? Expenses { get; set; }
        public ICollection<Permission>? Permissions { get; set; }

    }
}
