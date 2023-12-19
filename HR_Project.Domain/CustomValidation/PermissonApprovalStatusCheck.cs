using HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.CustomValidation
{
    public class PermissonApprovalStatusCheck : ValidationAttribute
    {
        ApprovalStatus approvalStatus;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            approvalStatus = (ApprovalStatus)value;

            if (approvalStatus==ApprovalStatus.Pending)
                return new ValidationResult("You cannot make a new request while you have pending approvals");
            return base.IsValid(value, validationContext);
        }
    }
}
