using HR_Project.Application.AutoMapper;
using HR_Project.Application.Services.AdressService;
using HR_Project.Application.Services.CurrencyService;
using HR_Project.Application.Services.AdvanceService;
using HR_Project.Application.Services.AdvanceTypeService;
using HR_Project.Application.Services.CurrencyService;
using HR_Project.Application.Services.CurrencyService;
using HR_Project.Application.Services.ExpenseService;
using HR_Project.Application.Services.ExpenseTypeService;
using HR_Project.Application.Services.ExpenseTypeService;
using HR_Project.Application.Services.PermissionService;
using HR_Project.Application.Services.PermissionTypeService;
using HR_Project.Application.Services.PersonnelService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Repositories;
using HR_Project.Infrastructure;
using HR_Project.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using HR_Project.Application.Services.CompanyService;

namespace HR_Project.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Veritabaný eriþimi için yapýlan ayarlar
            builder.Services.AddDbContext<HR_Context>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
            builder.Services.AddIdentity<Personnel, AppRole>(x =>
            {
                x.Password.RequiredLength = 6;
                // Diðer ayarlar yazýlabilir.
            }).AddEntityFrameworkStores<HR_Context>();

            //Authorization için:
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("Admin");
                });
            });

            // Nesne silme iþlemi için yapýlan ayarlar
            builder.Services.AddTransient<IPersonnelService, PersonnelService>();
            builder.Services.AddTransient<IPersonnelRepository, PersonnelRepository>();

            builder.Services.AddTransient<IAdvanceService, AdvanceService>();
            builder.Services.AddTransient<IAdvanceRepository, AdvanceRepository>();

            builder.Services.AddTransient<IPermissionService, PermissionService>();
            builder.Services.AddTransient<IPermissionRepository, PermissionRepository>();

            builder.Services.AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();
            builder.Services.AddTransient<IPermissionTypeService, PermissionTypeService>();

            builder.Services.AddTransient<IAdvanceTypeService, AdvanceTypeService>();
            builder.Services.AddTransient<IAdvanceTypeRepository, AdvanceTypeRepository>();

            builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
            builder.Services.AddTransient<ICompanyService, CompanyService>();

            builder.Services.AddTransient<IAddressService, AddressService>();
            builder.Services.AddTransient<IAddressRepository, AddressRepository>();


            builder.Services.AddTransient<ICurrencyService, CurrencyService>();
            builder.Services.AddTransient<ICurrencyRepository, CurrencyRepository>();

            builder.Services.AddTransient<IExpenseTypeService, ExpenseTypeService>();
            builder.Services.AddTransient<IExpenseTypeRepository, ExpenseTypeRepository>();

            builder.Services.AddTransient<IExpenseService, ExpenseService>();
            builder.Services.AddTransient<IExpenseRepository, ExpenseRepository>();

            builder.Services.AddTransient<ICurrencyService, CurrencyService>();
            builder.Services.AddTransient<ICurrencyRepository, CurrencyRepository>();

            // AutoMapper için yapýlan ayarlar
            builder.Services.AddAutoMapper(typeof(HRMapper));

            //AutoMapper için bunu ekledik****
            builder.Services.AddAutoMapper(x => x.AddProfile(typeof(HRMapper)));
            //builder.Services.AddAutoMapper(typeof(HRMapper));
            /////////////////////

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // Varsayýlan HSTS deðeri 30 gündür. Üretim senaryolarý için bunu deðiþtirebilirsiniz, bkz. https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

    //        app.MapAreaControllerRoute(
    //name: "admin",
    //areaName: "Admin",
    //pattern: "AdminArea/{controller=Company}/{action=CompanyList}"
    //);
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areasRoute",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");
            });

                
            


            app.Run();

        }
    }
}
