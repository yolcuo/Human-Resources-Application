using HR_Project.Application.Models.VMs;
using HR_Project.Domain.CustomValidation;
using HR_Project.Domain.Entities.Concrete;

namespace HR_Project.Presentation.Models.VMs
{
    public class PersonnelUpdateVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        [PhoneNumberCheck]
        public string Phone { get; set; }
        public int AddressID { get; set; }
        public AddressVM? Address { get; set; }
    }
}
