using HR_Project.Domain.Entities.Concrete;

namespace HR_Project.Presentation.Models.VMs
{
    public class CompanyDetailsVM
    {
        public Company  CompanyDetails { get; set; }
        public Address  AddressDetails { get; set; }
    }
}
