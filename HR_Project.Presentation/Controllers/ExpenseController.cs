
using HR_Project.Application.Services.ExpenseService;
using AutoMapper;
using HR_Project.Application.Models.VMs;
using HR_Project.Application.Services.CurrencyService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HR_Project.Application.Services.ExpenseTypeService;
using HR_Project.Application.Models.DTOs;


namespace HR_Project.Presentation.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseTypeService _expenseTypeService;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<Personnel> _userManager;
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseService expenseService, IWebHostEnvironment webHostEnvironment, UserManager<Personnel> userManager, ICurrencyService currencyService, IMapper mapper, IExpenseTypeService expenseTypeService)
        {
            _expenseService = expenseService;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _currencyService = currencyService;
            _mapper = mapper;
            _expenseTypeService = expenseTypeService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var expenses = await _expenseService.GetAllExpensesAsync(user.Id);

                List<ExpenseVM> listExpenseModel = new List<ExpenseVM>();
                foreach (var expense in expenses)
                {
                    ExpenseVM expenseVM = new ExpenseVM();
                    _mapper.Map(expense, expenseVM);
                    expenseVM.Currency = await _currencyService.GetCurrencyAsync(expenseVM.CurrencyCode);
                    if (expenseVM.ExpenseTypeID != null)
                        expenseVM.ExpenseType = await _expenseTypeService.GetExpenseTypeAsync(expense.ExpenseTypeID);
                    listExpenseModel.Add(expenseVM);
                }
                return View(listExpenseModel);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Hata oluştu: {Message}", ex.Message);
                // Hata günlüğüne kayıt atılır, ayrıca kullanıcıya bir hata sayfası gösterilebilir
                //return RedirectToAction("Error"); // Örnek bir hata sayfasına yönlendirme
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> CreateExpenseRequest()
        {
            var model = new CreateExpenseDTO();

            model.CurrencyCodeOptions = await _currencyService.GetAllCurrenciesAsync();
            model.ExpenseTypes = await _expenseTypeService.GetAllExpenseTypesAsync();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> CreateExpenseRequest(CreateExpenseDTO expense, IFormFile documentFile)
        {
            if (User.Identity.IsAuthenticated)
            {
                var personnelId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(personnelId))
                {
                    expense.PersonnelID = int.Parse(personnelId);
                }
            }

            if (documentFile != null && documentFile.Length > 0)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + documentFile.FileName;
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await documentFile.CopyToAsync(stream);
                }

                expense.DocumentPath = uniqueFileName;
            }


            var selectedExpenseType = await _expenseTypeService.GetExpenseTypeAsync(expense.ExpenseTypeID);

            if (selectedExpenseType != null && (expense.Amount < selectedExpenseType.MinAmount || expense.Amount > selectedExpenseType.MaxAmount))
            {
                ModelState.AddModelError("Amount", $"The Amount must be between {selectedExpenseType.MinAmount} and {selectedExpenseType.MaxAmount}.");
                expense.CurrencyCodeOptions = await _currencyService.GetAllCurrenciesAsync();
                expense.ExpenseTypes = await _expenseTypeService.GetAllExpenseTypesAsync();

                return View(expense);
            }


            await _expenseService.CreateExpenseRequestAsync(expense);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> GetByFilteredExpense(ApprovalStatus approvalStatus)
        {
            var user = await _userManager.GetUserAsync(User);
            var expenses = await _expenseService.GetFilteredExpenseAsync(user.Id, approvalStatus);
            List<ExpenseVM> listExpenseModel = new List<ExpenseVM>();
            foreach (var expense in expenses)
            {
                ExpenseVM expenseVM = new ExpenseVM();
                _mapper.Map(expense, expenseVM);
                expenseVM.Currency = await _currencyService.GetCurrencyAsync(expense.CurrencyCode);
                //expenseVM.ExpenseType = await _expenseTypeService.GetExpenseTypeAsync(expense.ExpenseTypeID);
                listExpenseModel.Add(expenseVM);
            }
            return View(listExpenseModel);
        }


        public async Task<IActionResult> GetExpenseDocument(int id)
        {
            var expense = await _expenseService.GetExpenseAsync(id);

            if (expense == null)
            {
                return NotFound();
            }
            //string filePath = expense.DocumentPath;
            //Projedeki Dosya yolu
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", expense.DocumentPath);
            //string filePath = Path.Combine("~/images", expense.DocumentPath);

            //string filePath = "C://Users//gulde//source//repos//HR_Project//HR_Project//HR_Project.Presentation//wwwroot//images//f0190444-4e81-4219-9d8b-50f1453528ca_1.jpg";
            //string filePath = "C:/Users/gulde/source/repos/HR_Project/HR_Project/HR_Project.Presentation/wwwroot/images/f0190444-4e81-4219-9d8b-50f1453528ca_1.jpg";
            //string filePath = "C:\\Users\\gulde\\source\\repos\\HR_Project\\HR_Project\\HR_Project.Presentation\\wwwroot\\images\\f0190444-4e81-4219-9d8b-50f1453528ca_1.jpg";


            if (!System.IO.File.Exists(filePath))
            {
                // Dosya yoksa hata ver veya başka bir işlem yap
                return NotFound();
            }


            // Dosyayı döndürün.
            //return PhysicalFile(filePath, "application/octet-stream");

            // Dosyayı döndürmek için File metodunu kullanın
            // "application/pdf" gibi doğru MIME türünü belirtmelisiniz
            //return File(filePath, "application/pdf", "dosya_adi.pdf");


            string mimeType = "image/jpg";
            //return File(filePath, "image/png", "dosya_adi.png");

            // Dosyayı döndürmek için File metodunu kullanın
           // return File(filePath, mimeType, expense.DocumentPath);

            return View(expense);
        }

        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenseService.RemoveExpense(id);
            return View("Index");
        }

    }

}

