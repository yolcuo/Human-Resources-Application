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
    public class ExpenseCFG : BaseEntityConfiguration<Expense>
    {
        public override void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.ID);
           
            builder.Property(x => x.RequestDate).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.ReplyDate).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal");
            builder.Property(x => x.ApprovalStatus).IsRequired().HasColumnType("varchar").HasMaxLength(20); 
            builder.Property(x => x.RequestDate).IsRequired(false).HasColumnType("datetime");
            builder.Property(x => x.ReplyDate).IsRequired(false).HasColumnType("datetime");
            builder.Property(x => x.DocumentPath).IsRequired(false).HasColumnType("varchar").HasMaxLength(75);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnType("bit");

            builder.HasOne(x => x.ExpenseType).WithMany(x => x.Expenses).HasForeignKey(x => x.ExpenseTypeID);
            builder.HasOne(x => x.Currency).WithMany(x => x.Expenses).HasForeignKey(x => x.CurrencyCode);
            builder.HasOne(x => x.Personnel).WithMany(x => x.Expenses).HasForeignKey(x => x.PersonnelID);

            Expense expense = new Expense()
            {
                ID=1,
                Amount=1000,
                ApprovalStatus=ApprovalStatus.Pending,
                RequestDate=DateTime.Now,
                ReplyDate=DateTime.Now,
                DocumentPath="deneme.jpg",
                CreateDate=DateTime.Now,
                ExpenseTypeID=1,
                CurrencyCode="TL",
                IsActive=true,
                PersonnelID=1,
            };
            builder.HasData(expense);

            base.Configure(builder);
        }
    }
}
