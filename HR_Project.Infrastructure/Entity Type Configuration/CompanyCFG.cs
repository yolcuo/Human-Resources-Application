using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Infrastructure.Entity_Type_Configuration
{
    public class CompanyCFG : BaseEntityConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.CompanyName).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            builder.Property(x => x.MersisNo).HasColumnType("varchar").IsRequired().HasMaxLength(16);
            builder.Property(x => x.TaxNumber).HasColumnType("varchar").IsRequired().HasMaxLength(16);
            builder.Property(x => x.LogoPath).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar").IsRequired().HasMaxLength(16);
            builder.Property(x => x.TaxAdministration).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            builder.Property(x => x.EmailAddress).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            builder.Property(x => x.NumberOfEmployees).HasColumnType("int").IsRequired();
            builder.Property(x => x.YearOfEstablishment).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.ContactStartDate).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.ContactEndDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnType("bit");

            builder.HasData(
                new Company
                {
                    ID = 1,
                    CompanyName = "Bilge Adam",
                    CompanyTitle = CompanyTitle.Sole,
                    MersisNo = "123456789123456",
                    TaxNumber = "1234567890",
                    LogoPath = "icardi.jpg",
                    PhoneNumber = "1234567890",
                    TaxAdministration = "Kadıköy",
                    EmailAddress = "bilgeadam@bilgeadam.com",
                    NumberOfEmployees = 100,
                    YearOfEstablishment = DateTime.Now,
                    ContactStartDate = DateTime.Now
                });

            base.Configure(builder);
        }
    }
}
