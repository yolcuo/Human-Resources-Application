
using HR_Project.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Models.VMs
{
    public class PersonnelMainVM
    {
        public Personnel PersonnelMain { get; set; }
        public AddressVM Address { get; set; }

    }
}
