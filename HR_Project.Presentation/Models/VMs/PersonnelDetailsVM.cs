using HR_Project.Application.Models.VMs;
using HR_Project.Domain.Entities.Concrete;

namespace HR_Project.Presentation.Models.VMs
{
    public class PersonnelDetailsVM
    {
        public Personnel PersonnelDetails { get; set; }
        public AddressVM Address { get; set; }
    }
}
