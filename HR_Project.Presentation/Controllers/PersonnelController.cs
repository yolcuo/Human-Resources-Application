using HR_Project.Application.Models.VMs;
using HR_Project.Application.Services.AdressService;
using HR_Project.Application.Services.PersonnelService;
using Microsoft.AspNetCore.Identity;
using HR_Project.Presentation.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HR_Project.Application.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Hosting;
using HR_Project.Domain.Entities.Concrete;

namespace HR_Project.Presentation.Controllers
{
    [Authorize]
    public class PersonnelController : Controller
    {
        private readonly IPersonnelService _personnelService;
        private readonly IAddressService _addressService;
        private readonly UserManager<Personnel> _userManager;
		private IWebHostEnvironment _webHostEnvironment;

		public PersonnelController(IPersonnelService personnelService, IAddressService addressService, UserManager<Personnel> userManager, IWebHostEnvironment webHostEnvironment)
		{
			_personnelService = personnelService;
			_addressService = addressService;
			_userManager = userManager;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<IActionResult> UpdatePersonnel()
        {
            Personnel personnel = await _userManager.GetUserAsync(User);

			UpdatePersonnelDTO updatePersonnelVM = new UpdatePersonnelDTO()
            {
                ID = personnel.Id,
                Name = personnel.Name,
                SecondName = personnel.SecondName,
                Surname = personnel.Surname,
                SecondSurname = personnel.SecondSurname,
                Title = personnel.Title,
                Phone = personnel.Phone,
                Photo = personnel.Photo,
                AddressID =(int) personnel.AddressID
            };
            updatePersonnelVM.Address = await _addressService.GetAddressAsync(updatePersonnelVM.AddressID);

            return View(updatePersonnelVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePersonnel(UpdatePersonnelDTO updatePersonnelDTO, IFormFile? profileImage)
        {
            if(ModelState.IsValid)
            {
				if (profileImage != null && profileImage.Length > 0)
				{
					var uniqueFileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName; 

					var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await profileImage.CopyToAsync(stream);
					}

                    updatePersonnelDTO.Photo = uniqueFileName;
				}
				var result = await _personnelService.UpdatePersonnelAsync(updatePersonnelDTO);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Personel güncelleme başarısız oldu.");
                    return View(updatePersonnelDTO);
                }
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error);
            }
            return RedirectToAction("Index","Home");
        }

        
        public async Task<IActionResult> GetPersonnelDetails()
        {
            
            try
            {
                var personnelDetails = await _userManager.GetUserAsync(User);

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
    }
}