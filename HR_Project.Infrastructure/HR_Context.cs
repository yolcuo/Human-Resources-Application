using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using HR_Project.Infrastructure.Entity_Type_Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HR_Project.Infrastructure
{
    //Bu class ın oluşturulması gerekir.
    public class HR_Context : IdentityDbContext<Personnel, AppRole, int>
    {
        public HR_Context()
        {

        }
        public HR_Context(DbContextOptions<HR_Context> options) : base(options)
        {

        }



        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Advance> Advances { get; set; }
        public DbSet<AdvanceType> AdvanceTypes { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Cloud Database için:
            // optionsBuilder.UseSqlServer("Server=tcp:hr-project.database.windows.net,1433;Initial Catalog=HR_ProjectDB;Persist Security Info=False;User ID=hr_project_admin;Password=HR.123123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False");

            optionsBuilder.UseSqlServer("Data source=.;Initial catalog=HR_DB; integrated security = true; Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //CFG'ler gelecek.
            builder.ApplyConfiguration<AppRole>(new AppRoleCFG());
            builder.ApplyConfiguration<Personnel>(new PersonnelCFG());
            builder.ApplyConfiguration<Address>(new AddressCFG());
            builder.ApplyConfiguration<PermissionType>(new PermissionTypeCFG());
            builder.ApplyConfiguration<Permission>(new PermissionCFG());
            builder.ApplyConfiguration<Expense>(new ExpenseCFG());
            builder.ApplyConfiguration<ExpenseType>(new ExpenseTypeCFG());
            builder.ApplyConfiguration<Currency>(new CurrencyCFG());
            builder.ApplyConfiguration<Company>(new CompanyCFG());
            builder.ApplyConfiguration<Advance>(new AdvanceCFG());
            builder.ApplyConfiguration<AdvanceType>(new AdvanceTypeCFG());




            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,//admin rolünde
                UserId = 1
            },
            new IdentityUserRole<int>
            {
                RoleId = 2,//user rolünde
                UserId = 2
            }); //oluşturulan rol ve kullanıcıların ilişkisini kurduk.


            base.OnModelCreating(builder);
        }
    }
}