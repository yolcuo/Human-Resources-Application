using HR_Project.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Entities.Concrete
{
    public class Address:IBaseEntity
    {
        public int ID { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Neighbourhood { get; set; }
        public string? Street { get; set; }
        public string? Detail { get; set; }
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }
        public ICollection<Personnel>? Personnels { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
