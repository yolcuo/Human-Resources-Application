using AutoMapper;
using HR_Project.Application.Models.VMs;
using HR_Project.Application.Services.AdressService;
using HR_Project.Application.Services.CompanyService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using HR_Project.Presentation.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Presentation.Areas.AdminArea.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    [Area("AdminArea")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _webHostEnvironment;
        public CompanyController(IMapper mapper, ICompanyService companyService, IAddressService addressService, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _companyService = companyService;
            _addressService = addressService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> CompanyList()
        {
            try
            {
                var companies = await _companyService.GetCompaniesAsync();

                List<CompanyListVM> listCompanyModel = new List<CompanyListVM>();

                foreach (var company in companies)
                {
                    CompanyListVM companyVM = new CompanyListVM();
                    _mapper.Map(company, companyVM);

                    var adresses = await _addressService.GetAllAddressAsync(company.ID);
                    if(adresses != null)
                    {
                        foreach (var address in adresses)
                        {
                            companyVM.Addresses.Add(address);
                        }
                    }
                    
                    listCompanyModel.Add(companyVM);
                }
                return View(listCompanyModel);
            }
            catch (Exception ex)
            {
                //return RedirectToAction("Error"); // Örnek bir hata sayfasına yönlendirme
                return View();
            }
        }

        public async Task<IActionResult> GetDetails(int id)
        {
            try
            {
                var companyDetails = await _companyService.GetCompanyAsync(id);

                if (companyDetails == null)
                {
                    return NotFound();
                }

                var companyDetailsViewModel = new CompanyDetailsVM
                {
                    CompanyDetails = companyDetails,

                };

                return View(companyDetailsViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server fail: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateCompany()
        {
            var model = new CreateCompanyVM
            {
                Company = new Company(),
                Address = new AddressVM()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyVM vm, CompanyTitle companyTitle, IFormFile logoFile)
        {

            if (logoFile != null && logoFile.Length > 0)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + logoFile.FileName;
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await logoFile.CopyToAsync(stream);
                }

                vm.Company.LogoPath = uniqueFileName;
            }

            string mersisNo = vm.Company.MersisNo;
            string taxNumber = vm.Company.TaxNumber;
            if (taxNumber.Length != 10)
            {
                ModelState.AddModelError("Company.TaxNumber", "Tax Number must be 10 digits.");
                return View(vm);
            }

            if (mersisNo.Length != 16)
            {
                ModelState.AddModelError("Company.MersisNo", "MersisNo must be 16 digits.");
                return View(vm);
            }
            else
            {
                if (companyTitle == CompanyTitle.Sole)
                {
                    string tcNoPart = mersisNo.Substring(0, 11);
                    string controlPart = mersisNo.Substring(11, 3);
                    if (!IsTCNoValid(tcNoPart))
                    {
                        ModelState.AddModelError("Company.MersisNo", "The Mersis No is invalid for those with a Company Title of Sole.");
                        return View(vm);
                    }
                    if (controlPart != "000")
                    {
                        {
                            ModelState.AddModelError("Company.MersisNo", "The Mersis No is invalid for those with a Company Title of Sole.");
                            return View(vm);
                        }
                    }
                }
                else
                {
                    string firstPart = mersisNo.Substring(0, 1);
                    string taxNoPart = mersisNo.Substring(1, 10);
                    string controlPart = mersisNo.Substring(11, 3);
                    if (!(firstPart == "0" && taxNoPart == taxNumber && controlPart == "000"))
                    {

                        ModelState.AddModelError("Company.MersisNo", "The Mersis No is invalid for those with a Company Title of LTD or AŞ.");
                        return View(vm);
                    }
                }
            }

            vm.Company.CompanyTitle = companyTitle;
            await _companyService.CreateCompanyAsync(vm.Company);

            var result = await _companyService.GetCompanyAsync(vm.Company);


            Address address1 = new Address();
            address1.City = vm.Address.City;
            address1.District = vm.Address.District;
            address1.Neighbourhood = vm.Address.Neighbourhood;
            address1.Street = vm.Address.Street;
            address1.Detail = vm.Address.Detail;
            address1.CompanyID = result.ID;
            await _addressService.CreateAddressAsync(address1);


            return RedirectToAction("CompanyList");
        }


        public bool IsTCNoValid(string tcKimlikNo)
        {
            bool returnvalue = false;
            if (tcKimlikNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;
                TcNo = Int64.Parse(tcKimlikNo);
                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;
                C1 = ATCNO % 10;
                ATCNO = ATCNO / 10;
                C2 = ATCNO % 10;
                ATCNO = ATCNO / 10;
                C3 = ATCNO % 10;
                ATCNO = ATCNO / 10;
                C4 = ATCNO % 10;
                ATCNO = ATCNO / 10;
                C5 = ATCNO % 10;
                ATCNO = ATCNO / 10;
                C6 = ATCNO % 10;
                ATCNO = ATCNO / 10;
                C7 = ATCNO % 10;
                ATCNO = ATCNO / 10;
                C8 = ATCNO % 10;
                ATCNO = ATCNO / 10;
                C9 = ATCNO % 10;
                ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);
                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }

            return returnvalue;
        }


    }


}
