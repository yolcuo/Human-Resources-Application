using HR_Project.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Infrastructure.Entity_Type_Configuration
{
    public class PersonnelCFG : BaseEntityConfiguration<Personnel>
    {

        public override void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(20).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.SecondName).HasMaxLength(20).HasColumnType("varchar").IsRequired(false);
            builder.Property(x => x.Surname).HasMaxLength(20).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.SecondSurname).HasMaxLength(20).HasColumnType("varchar").IsRequired(false);
            builder.Property(x => x.TC).HasMaxLength(11).HasColumnType("varchar").IsRequired();
            
            builder.Property(x => x.Phone).HasMaxLength(13).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Photo).IsRequired(false).HasMaxLength(200).HasColumnType("varchar");


            builder.Property(x => x.BirthPlace).HasMaxLength(20).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.BirthDate).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DateOfStartWorking).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DateOfStopWorking).HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Title).HasMaxLength(20).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.CompanyName).HasMaxLength(40).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Department).HasMaxLength(40).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Email).HasMaxLength(40).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Salary).HasMaxLength(20).HasColumnType("decimal(18,4)").IsRequired();
            builder.HasOne(x=>x.Address).WithMany(x=>x.Personnels).HasForeignKey(x => x.AddressID);

            PasswordHasher<Personnel> hashPwd = new PasswordHasher<Personnel>();

            Personnel admin = new Personnel()
            {
                Id = 1,
                Name = "Admin",
                Surname = "Admin",
                Email = "admin@bilgeadam.com",
                UserName = "admin@bilgeadam.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                TC = "11111111111",
                Phone = "05555555555",
                BirthPlace = "Istanbul",
                BirthDate = DateTime.Parse("2001-01-01"),
                DateOfStartWorking = DateTime.Now,
                Title = "Software Developer",
                CompanyName = "Bilge Adam",
                Department = "Software Development",
                Salary = 35500,
                AddressID = 1,
                Photo = "icardi.jpg"
            };
            admin.NormalizedUserName = admin.UserName.ToUpper();
            admin.NormalizedEmail = admin.Email.ToUpper();
            admin.PasswordHash = hashPwd.HashPassword(admin, "AdmiN_123");


            builder.HasData(admin);

            Personnel user = new Personnel()
            {
                Id = 2,
                Name = "Root",
                Surname = "Root",
                Email = "root@bilgeadamboost.com",
                UserName = "root@bilgeadamboost.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                TC = "22222222222",
                Phone = "05555555555",
                BirthPlace = "Istanbul",
                BirthDate = DateTime.Parse("2001-01-01"),
                DateOfStartWorking = DateTime.Now,
                Title = "Software Developer",
                CompanyName = "Bilge Adam",
                Department = "Software Development",
                Salary = 27500,
                AddressID = 1,
                Photo = "icardi.jpg"
            };
            user.NormalizedUserName = user.UserName.ToUpper();
            user.NormalizedEmail = user.Email.ToUpper();
            user.PasswordHash = hashPwd.HashPassword(user, "RooT_123");


            builder.HasData(user);

            base.Configure(builder);
        }

    }

}
