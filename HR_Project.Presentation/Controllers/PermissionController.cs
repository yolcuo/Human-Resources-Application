using HR_Project.Application.Models.VMs;
using HR_Project.Application.Services.PermissionService;
using HR_Project.Application.Services.PermissionTypeService;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Presentation.Controllers
{
    public class PermissionController : Controller
    {
        private readonly IPermissionService _permissionService;
        private readonly IPermissionTypeService _permissionTypeService;
        private readonly UserManager<Personnel> _userManager;

        public PermissionController(IPermissionService permissionService, UserManager<Personnel> userManager, IPermissionTypeService permissionTypeService)
        {
            _permissionService = permissionService;
            _userManager = userManager;
            _permissionTypeService = permissionTypeService;
        }

        public async Task<IActionResult> Index()
        {
            PermissionCreateVM permissionCreateVM = new PermissionCreateVM();
            permissionCreateVM.PermissionTypes = await _permissionTypeService.GetAllPermissionTypesAsync();
            return View(permissionCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(PermissionCreateVM permissionCreateVM)
        {
            Permission permission = new Permission();
            Personnel personnel = await _userManager.GetUserAsync(User);
            permission.PersonnelID = personnel.Id;
            permission.PermissionTypeID = permissionCreateVM.PermissionTypeID;
            permission.ApprovalStatus = ApprovalStatus.Pending;
            permission.IsActive = true;
            permission.StartDate = permissionCreateVM.StartDate;
            permission.ExpirationDate = permissionCreateVM.ExpirationDate;
            permission.RequestDate = DateTime.Now;
            permission.NumberOfDays = Convert.ToDecimal((permissionCreateVM.ExpirationDate - permissionCreateVM.StartDate).Days);
            _permissionService.CreatePermissionRequestAsync(permission);
            return RedirectToAction(nameof(ListPermissions));
        }


        public async Task<IActionResult> ListPermissions()
        {
            Personnel personnel = await _userManager.GetUserAsync(User);
            PermissionListVM permissionListVM = new PermissionListVM();
            permissionListVM.PendingPermissions = await _permissionService.GetPermissionsByApprovalStatusAsync(ApprovalStatus.Pending,personnel.Id,p=>p.PermissionType);
            permissionListVM.AcceptedPermissions = await _permissionService.GetPermissionsByApprovalStatusAsync(ApprovalStatus.Approved, personnel.Id,p=>p.PermissionType);
            permissionListVM.RejectedPermissions = await _permissionService.GetPermissionsByApprovalStatusAsync(ApprovalStatus.Rejected, personnel.Id,p=>p.PermissionType);
            return View(permissionListVM);
        }

        //Remove Permission
        [HttpPost]
        public ActionResult ListPermissions(int id)
        {
            _permissionService.RemovePermission(id);
            return RedirectToAction("ListPermissions");
        }
    }
}
