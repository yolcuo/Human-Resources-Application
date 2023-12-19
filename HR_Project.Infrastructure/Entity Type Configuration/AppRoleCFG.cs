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
    public class AppRoleCFG : BaseEntityConfiguration<AppRole>
    {
        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(30);

            builder.HasData(
                new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole { Id = 2, Name = "User", NormalizedName = "USER" },
                new AppRole { Id = 3, Name = "Manager", NormalizedName = "MANAGER" }
                );

            base.Configure(builder);//configure çalıştığında baseden miras aldığı sınıfın configure ünü override edeceksin diyoruz.
        }
    }
}
