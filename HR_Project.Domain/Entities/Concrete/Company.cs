using HR_Project.Domain.Entities.Abstract;
using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Entities.Concrete
{
    public class Company : IBaseEntity
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public CompanyTitle CompanyTitle { get; set; }
        public string MersisNo { get; set; }
        public string? TaxNumber { get; set; }
        public string? LogoPath { get; set; }
        public string PhoneNumber { get; set; }
        public string? TaxAdministration { get; set; }
        public string EmailAddress { get; set; }
        public int NumberOfEmployees { get; set; }
        public DateTime YearOfEstablishment { get; set; }
        public DateTime ContactStartDate { get; set; }
        public DateTime? ContactEndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Address>? Addresses { get; set; }
    }
}
