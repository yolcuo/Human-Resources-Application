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
    public class AdvanceCFG : BaseEntityConfiguration<Advance>
    {
        public override void Configure(EntityTypeBuilder<Advance> builder)
        {
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
            
            base.Configure(builder);
        }
    }
}
