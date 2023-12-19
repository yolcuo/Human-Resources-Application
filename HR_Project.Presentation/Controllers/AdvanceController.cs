using AutoMapper;
using HR_Project.Application.Models.DTOs;
using HR_Project.Application.Models.VMs;
using HR_Project.Application.Services.AdvanceService;
using HR_Project.Application.Services.AdvanceTypeService;
using HR_Project.Application.Services.CurrencyService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Presentation.Controllers
{
    public class AdvanceController : Controller
    {
        private readonly UserManager<Personnel> _userManager;
        private readonly IAdvanceService _advanceService;
        private readonly IMapper _mapper;
        private readonly ICurrencyService _currencyService;
        private readonly IAdvanceTypeService _advanceTypeService;

        public AdvanceController(IAdvanceService advanceService, UserManager<Personnel> userManager, IMapper mapper, IAdvanceTypeService advanceTypeService, ICurrencyService currencyService)
        {
            _advanceService = advanceService;
            _userManager = userManager;
            _mapper = mapper;
            _advanceTypeService = advanceTypeService;
            _currencyService = currencyService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var advance = await _advanceService.GetAllAdvanceAsync(user.Id);
            List<AdvanceVM> listAdvanceModel = new List<AdvanceVM>();
            foreach (var item in advance)
            {
                AdvanceVM advanceVM = new AdvanceVM();
                _mapper.Map(item, advanceVM);
                advanceVM.Currency = await _currencyService.GetCurrencyAsync(advanceVM.CurrencyCode);
                advanceVM.AdvanceType = await _advanceTypeService.GetAdvanceTypeAsync(item.AdvanceTypeID);
                listAdvanceModel.Add(advanceVM);
            }
            return View(listAdvanceModel);
        }
        public async Task<IActionResult> CreateAdvance()
        {
            AdvanceCreateDTO model = new AdvanceCreateDTO();
            model.Personnel = await _userManager.GetUserAsync(User);
            model.Currencies = await _currencyService.GetAllCurrenciesAsync();
            model.AdvanceTypes = await _advanceTypeService.GetAllAdvanceTypeAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvance(AdvanceCreateDTO model)
        {
            //bireysel maas 3 kat, kurumsalda ise max min 
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                model.Personnel = user;
                Advance advance = new Advance();

                if (user != null)
                {
                    model.PersonnelID = user.Id;
                    model.ApprovalStatus = ApprovalStatus.Pending;
                }
                var selectedAdvanceType = await _advanceTypeService.GetAdvanceTypeAsync(model.AdvanceTypeID);
                if (model.AdvanceTypeID == 2)
                {

                    if (model.Amount < selectedAdvanceType.MaxAmount && model.Amount > selectedAdvanceType.MinAmount)
                    {

                        _mapper.Map(model, advance);
                        advance.AdvanceType = selectedAdvanceType;
                        advance.RequestDate = DateTime.Now;
                        advance.ReplyDate = DateTime.Now.AddDays(2);
                        await _advanceService.CreateAdvanceAsync(advance);
                    }
                    else
                    {
                        ModelState.AddModelError("Amount", $"The Amount must be between {selectedAdvanceType.MinAmount} and {selectedAdvanceType.MaxAmount}.");
                        model.Currencies = await _currencyService.GetAllCurrenciesAsync();
                        model.AdvanceTypes = await _advanceTypeService.GetAllAdvanceTypeAsync();
                        return View(model);

                    }
                }
                if (model.AdvanceTypeID == 1)
                {
                    if (model.Personnel.Salary * 3 < model.Amount && model.Amount > 0)
                    {

                        ModelState.AddModelError("Amount", $"The advance amount cannot exceed 3 times the person's salary,It must be less than  {model.Personnel.Salary * 3}.");
                        model.Currencies = await _currencyService.GetAllCurrenciesAsync();
                        model.AdvanceTypes = await _advanceTypeService.GetAllAdvanceTypeAsync();
                        return View(model);
                    }
                    else
                    {
                        _mapper.Map(model, advance);
                        advance.AdvanceType = selectedAdvanceType;
                        advance.RequestDate = DateTime.Now;
                        advance.ReplyDate = DateTime.Now.AddDays(2);
                        await _advanceService.CreateAdvanceAsync(advance);
                    }
                }

            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetByFilteredAdvance(ApprovalStatus approvalStatus)
        {
            var user = await _userManager.GetUserAsync(User);
            var advance = await _advanceService.GetFilteredAdvanceAsync(user.Id, approvalStatus);
            List<AdvanceVM> listAdvanceModel = new List<AdvanceVM>();
            foreach (var item in advance)
            {
                AdvanceVM advanceVM = new AdvanceVM();
                _mapper.Map(item, advanceVM);
                advanceVM.Currency = await _currencyService.GetCurrencyAsync(advanceVM.CurrencyCode);
                advanceVM.AdvanceType = await _advanceTypeService.GetAdvanceTypeAsync(item.AdvanceTypeID);
                listAdvanceModel.Add(advanceVM);
            }
            return View(listAdvanceModel);
        }
        public async Task<IActionResult> deleteAdvance(int id)
        {
            Advance deletedAdvance = await _advanceService.GetAdvanceAsync(id);
            if (deletedAdvance != null)
            {
                await _advanceService.DeleteAdvanceAsync(id);

            }


            return RedirectToAction("Index");

        }

    }
}
