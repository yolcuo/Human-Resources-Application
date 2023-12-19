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
    public class PermissionTypeCFG:BaseEntityConfiguration<PermissionType>
    {
        public override void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Name).HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
            builder.HasData(
                new PermissionType { ID = 1,Name="Doğum İzni"},
                new PermissionType { ID = 2,Name="Babalık İzni", MaxDays=5},
                new PermissionType { ID = 3,Name="Hastalık İzni",MaxDays=10},
                new PermissionType { ID = 4,Name="Ölüm İzni",MaxDays=3},
                new PermissionType { ID = 5,Name="Evlilik İzni"},
                new PermissionType { ID = 6,Name="Evlat edinme İzni",MaxDays=40},
                new PermissionType { ID = 7,Name="Refakat İzni"},
                new PermissionType { ID = 8,Name="Ücretsiz İzni"},
                new PermissionType { ID = 9,Name="Yeni iş arama İzni"},
                new PermissionType { ID = 10,Name="Gebelik Kontrol İzni"},
                new PermissionType { ID = 11,Name="Süt İzni"}
                );


            base.Configure(builder);
        }
    }
}
