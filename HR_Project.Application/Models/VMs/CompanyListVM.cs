using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Models.VMs
{
    public class CompanyListVM
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string LogoPath { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<AddressVM> Addresses { get; set; }
    }
}
