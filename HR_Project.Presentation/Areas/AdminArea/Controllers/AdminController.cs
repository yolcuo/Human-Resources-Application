using HR_Project.Application.Models.DTOs;
using HR_Project.Application.Services.AdressService;
using HR_Project.Application.Services.CompanyService;
using HR_Project.Application.Services.PersonnelService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Presentation.Models.VMs;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Presentation.Areas.AdminArea.Controllers
{
	[Authorize(Policy = "AdminOnly")]
	[Area("AdminArea")]
	public class AdminController : Controller
	{

		private readonly UserManager<Personnel> _userManager;

		private readonly IPersonnelService _personnelService;
		private readonly ICompanyService _companyService;
		private readonly IAddressService _addressService;
		private IWebHostEnvironment _webHostEnvironment;


		public AdminController(IPersonnelService personnelService, ICompanyService companyService, IAddressService addressService, IWebHostEnvironment webHostEnvironment, UserManager<Personnel> userManager)
		{
			_personnelService = personnelService;
			_companyService = companyService;
			_addressService = addressService;
			_webHostEnvironment = webHostEnvironment;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _personnelService.GetAllManagerAsync();
			foreach (var item in result)
			{
				item.Company = await _companyService.GetCompanyAsync((int)item.CompanyID);
			}

			return View(result);
		}
		public async Task<IActionResult> CreateManager()
		{
			CreateManagerDTO dto = new CreateManagerDTO();
			dto.Companies = await _companyService.GetCompaniesAsync();
			return View(dto);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteManager(int id)
		{
			var personnel = await _personnelService.GetPersonnelAsync(x => x.Id == id);
			_personnelService.RemovePersonnel(personnel);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> GetPersonnelDetails(int id)
		{
			try
			{
				var personnelDetails = await _personnelService.GetPersonnelAsync(x => x.Id == id);

				if (personnelDetails == null)
				{
					return NotFound();
				}
				int addressId = personnelDetails.AddressID ?? 0;
				var address = await _addressService.GetAddressAsync(addressId);
				var personnelDetailsViewModel = new PersonnelDetailsVM
				{
					PersonnelDetails = personnelDetails,
					Address = address
				};

				return View(personnelDetailsViewModel);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Server fail: {ex.Message}");
			}
		}



		[HttpPost]
		public async Task<IActionResult> CreateManager(CreateManagerDTO dto, IFormFile? profileImage)
		{
			dto.Companies = await _companyService.GetCompaniesAsync();
			if (ModelState.IsValid)
			{
				if (profileImage != null && profileImage.Length > 0)
				{
					var uniqueFileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName;

					var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await profileImage.CopyToAsync(stream);
					}

					dto.Photo = uniqueFileName;
				}
				string email = dto.Email;
				dto.Company = await _companyService.GetCompanyAsync(dto.CompanyID);
				dto.Email = await UniqueEmailCreate(dto);
				
				var result = await _personnelService.CreateManagerAsync(dto, email);

				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}


			}
			return View(dto);
			
			
			

		}
		private async Task<bool> EmailControl(string email)
		{
			var user = await _userManager.FindByNameAsync(email);
			if (user != null)
				return true;
			else
				return false;

		}
		private async Task<string> UniqueEmailCreate(CreateManagerDTO dto)
		{
			dto.Email = dto.Name.ToLower().Replace(" ", "") + dto.Surname.ToLower().Replace(" ", "") + "@" + dto.Company.CompanyName.ToLower().Replace(" ", "") + ".com";
			var postfix = 1;

			while (true)
			{
				var check = await EmailControl(dto.Email);

				if (!check)
				{

					return dto.Email;
				}


				postfix++;
				dto.Email = dto.Name.ToLower().Replace(" ", "") + dto.Surname.ToLower().Replace(" ", "") + postfix + "@" + dto.Company.CompanyName.ToLower().Replace(" ", "") + ".com";
			}
		}

	}
}





