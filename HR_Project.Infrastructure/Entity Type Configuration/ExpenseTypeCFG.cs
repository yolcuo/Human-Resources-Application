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
    public class ExpenseTypeCFG : BaseEntityConfiguration<ExpenseType>
    {
        public override void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Name).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(et => et.MinAmount).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(et => et.MaxAmount).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.MinAmount).IsRequired().HasColumnType("decimal");
            builder.Property(x => x.MaxAmount).IsRequired().HasColumnType("decimal");
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnType("bit");

            builder.HasData(
                new ExpenseType
                {
                    ID = 1,
                    Name = "Travel",
                    MinAmount = 1000,
                    MaxAmount = 5000,
                    CreateDate = DateTime.Now,
                    IsActive = true
                },
                new ExpenseType
                {
                    ID = 2,
                    Name = " Accommodation",
                    MinAmount = 1000,
                    MaxAmount = 3000,
                    CreateDate = DateTime.Now,
                    IsActive = true
                },
                new ExpenseType
                {
                    ID = 3,
                    Name = "Meals",
                    MinAmount = 300,
                    MaxAmount = 500,
                    CreateDate = DateTime.Now,
                    IsActive = true
                },
                new ExpenseType
                {
                    ID = 4,
                    Name = "Education",
                    MinAmount = 1000,
                    MaxAmount = 5000,
                    CreateDate = DateTime.Now,
                    IsActive = true
                },
                new ExpenseType
                {
                    ID = 5,
                    Name = "Fuel",
                    MinAmount = 1000,
                    MaxAmount = 3000,
                    CreateDate = DateTime.Now,
                    IsActive = true
                },
                new ExpenseType
                {
                    ID = 6,
                    Name = "Entertainment",
                    MinAmount = 1000,
                    MaxAmount = 5000,
                    CreateDate = DateTime.Now,
                    IsActive = true
                });


            base.Configure(builder);

        }
           
        
    }
}
