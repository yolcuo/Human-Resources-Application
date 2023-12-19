using HR_Project.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rebus.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Infrastructure.Entity_Type_Configuration
{

    public class CurrencyCFG : BaseEntityConfiguration<Currency>
    {
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(c => c.Code);
            builder.Property(c => c.Code).IsRequired().HasMaxLength(3);
            builder.Property(c => c.Name) .IsRequired().HasMaxLength(255);
            builder.Property(c => c.ExchangeRate).IsRequired(); //hoca gerek olmadığını söylemişti
            builder.Property(x => x.Code).IsRequired().HasColumnType("varchar").HasMaxLength(3);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.ExchangeRate).IsRequired().HasColumnType("decimal");
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnType("bit");

            builder.HasData(
                new Currency
                {
                    Code = "TL",
                    Name = "Turkish Lira",
                    ExchangeRate = 1,
                    CreateDate = DateTime.Now,
                    IsActive = true

                },
                new Currency
                {
                    Code = "USD",
                    Name = "US Dollar",
                    ExchangeRate = 27,
                    CreateDate = DateTime.Now,
                    IsActive = true
                },
                new Currency
                {
                    Code = "EUR",
                    Name = "EURO",
                    ExchangeRate = 30,
                    CreateDate = DateTime.Now,
                    IsActive = true
                },
                new Currency
                {
                    Code = "JPY",
                    Name = "Japanese Yen",
                    ExchangeRate = 18,
                    CreateDate = DateTime.Now,
                    IsActive = true
                });

            base.Configure(builder);
        }
    }
}
