using HR_Project.Application.Models.DTOs;
using HR_Project.Application.Services.PersonnelService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

namespace HR_Project.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPersonnelService _personnelService;
        private readonly HR_Context _HRContext;
        private readonly UserManager<Personnel> _userManager;
        public LoginController(IPersonnelService appUserService, HR_Context hRContext, UserManager<Personnel> userManager)
        {
            _personnelService = appUserService;
            _HRContext = hRContext;
            _userManager = userManager;
        }
        public IActionResult Index() //Login
        {
            return View();
        }
        //public async Task<IActionResult> CreateUser()
        //{

        //    Personnel adminUye = new Personnel()

        //    {
        //        Name = "Root",
        //        Surname = "Root",
        //        Email = "rootUser@deneme.com",
        //        UserName = "rootUser@deneme.com",
        //        TC = " ",
        //        Phone = " ",
        //        BirthPlace = " ",
        //        BirthDate = DateTime.Now,
        //        DateOfStartWorking = DateTime.Now,
        //        Title = " ",
        //        CompanyName = " ",
        //        Department = " ",
        //        Salary = 0
        //    };

        //    await _userManager.CreateAsync(adminUye, "rooT_123");

        //    await _userManager.AddToRoleAsync(adminUye, "Admin");

        //    return Content("Root Admin olustu.");
        //    //return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _personnelService.LoginAsync(loginDTO);

                if (result.Succeeded)
                {
                    return Redirect("~/Home");
                }
                else
                {

                    ModelState.AddModelError("Password", "Username or password is wrong");

                    return View(loginDTO);
                }

            }
            
            return View(loginDTO);
        }

        public IActionResult UpdatePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _personnelService.UpdatePasswordAsync(updatePasswordDTO); 
                if (result.Succeeded)
                {
					TempData["SuccessMessage"] = "Şifre değiştirme işlemi başarıyla tamamlandı.";
					return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(updatePasswordDTO);
        }
        public IActionResult Success() //şifre değiştirme başarılı olduktan sonra bu action ile bir view e yönlendirilebilir.
        {
            return Content("Oldu");
        }

        public IActionResult Logout()
        {
            _personnelService.Logout();
            return Redirect("~/Login");
        }
    }
}