using HR_Project.Application.Models.VMs;
using HR_Project.Application.Services.AdressService;
using HR_Project.Application.Services.PersonnelService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HR_Project.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAddressService _addressService;
        private readonly UserManager<Personnel> _userManager;
        private readonly IPersonnelService _personnelService;

        public HomeController(ILogger<HomeController> logger, IAddressService addressService, UserManager<Personnel> userManager, IPersonnelService personnelService)
        {
            _logger = logger;
            _addressService = addressService;
            _userManager = userManager;
            _personnelService = personnelService;
        }

        public async Task<IActionResult> Index()
        {
            Personnel personnel = await _userManager.GetUserAsync(User);
            PersonnelMainVM model = new PersonnelMainVM();
            model.PersonnelMain = personnel;
            model.Address = await _addressService.GetAddressAsync((int)personnel.AddressID);

            return View(model);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}