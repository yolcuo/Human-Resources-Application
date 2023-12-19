using HR_Project.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Models.DTOs
{
    public class CreateCompanyDTO
    {
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string MersisNo { get; set; }
        public string TaxNumber { get; set; }
        public string LogoPath { get; set; }
        public IFormFile LogoFile { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxAdministration { get; set; }
        public string EmailAddress { get; set; }
        public int NumberOfEmployees { get; set; }
        public DateTime YearOfEstablishment { get; set; }
        public DateTime ContactStartDate { get; set; }
        public ICollection<Address>? Addresses { get; set; }
       
    }
}
