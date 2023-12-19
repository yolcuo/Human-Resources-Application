using HR_Project.Application.Models.VMs;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;

namespace HR_Project.Presentation.Models.VMs
{
    public class CreateCompanyVM
    {
        public AddressVM Address { get; set; }
        public Company Company { get; set; }
        public List<CompanyTitle> CompanyTitles { get; set; }
        public CreateCompanyVM()
        {
            CompanyTitles = Enum.GetValues(typeof(CompanyTitle))
                    .Cast<CompanyTitle>()
                    .ToList();
        }
    }
}
