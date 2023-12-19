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
    public class AddressCFG : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(c => c.Company).WithMany(c => c.Addresses).HasForeignKey(c => c.CompanyID);
            builder.Property(x => x.City).HasMaxLength(20).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.District).HasMaxLength(30).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Neighbourhood).HasMaxLength(20).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Street).HasMaxLength(30).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Detail).HasMaxLength(300).HasColumnType("varchar").IsRequired();

            builder.HasOne(x => x.Company).WithMany(x => x.Addresses).HasForeignKey(x => x.CompanyID);

            builder.HasData(
                new Address
                {
                    ID = 1,
                    City = "Istanbul",
                    District = "Kadikoy",
                    Neighbourhood = "Caferaga Mah.",
                    Street = "Muhurdar",
                    Detail = "Bilge Adam Akademi Kadikoy Subesi",
                    CreateDate = DateTime.Now
                },
                new Address
                {
                    ID = 2,
                    City = "Istanbul",
                    District = "Kartal",
                    Neighbourhood = "ÇAvuşoğlu Mah.",
                    Street = "Muhurdar",
                    Detail = "Menekşe Sk No:1",
                    CompanyID = 1,
                    CreateDate = DateTime.Now
                }
           );

            base.Configure(builder);
        }
    }
}