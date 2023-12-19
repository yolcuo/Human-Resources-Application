using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Infrastructure.Entity_Type_Configuration
{
    public class PermissionCFG : BaseEntityConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.ID);
            builder.HasOne(p => p.PermissionType).WithMany(p=>p.Permissions).HasForeignKey(p=>p.PermissionTypeID);
            builder.HasOne(p => p.Personnel).WithMany(p=>p.Permissions).HasForeignKey(p=>p.PersonnelID);
            builder.HasData(
                new Permission {ID=1,PersonnelID=1,PermissionTypeID =1,CreateDate=DateTime.Now,IsActive=true,StartDate=DateTime.Now,ExpirationDate=DateTime.Now,RequestDate=DateTime.Now,NumberOfDays=1,ApprovalStatus=ApprovalStatus.Pending}
                );
            base.Configure(builder);
        }
    }
}
