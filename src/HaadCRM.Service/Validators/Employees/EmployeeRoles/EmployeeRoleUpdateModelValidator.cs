using FluentValidation;
using HaadCRM.Service.DTOs.EmployeeDTOs.EmployeeRoles;

namespace HaadCRM.Service.Validators.Employees.EmployeeRoles;

public class EmployeeRoleUpdateModelValidator : AbstractValidator<EmployeeRoleUpdateModel>
{
    public EmployeeRoleUpdateModelValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty().WithMessage("Name must be specified.");
    }
}
