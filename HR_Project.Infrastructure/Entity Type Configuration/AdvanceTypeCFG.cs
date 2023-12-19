using HR_Project.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Infrastructure.Entity_Type_Configuration
{
    public class AdvanceTypeCFG:BaseEntityConfiguration<AdvanceType>
    {
        public override void Configure(EntityTypeBuilder<AdvanceType> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            base.Configure(builder);
        }
    }
}
