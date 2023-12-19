using HR_Project.Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Infrastructure.Entity_Type_Configuration
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreateDate).HasColumnType("datetime").IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ModifiedDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.DeleteDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

        }
    }

}
