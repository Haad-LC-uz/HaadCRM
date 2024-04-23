using FluentValidation;
using HaadCRM.Service.DTOs.EmployeeDTOs.EmployeeRoles;

namespace HaadCRM.Service.Validators.Employees.EmployeeRoles;

public class EmployeeRoleCreateModelValidator : AbstractValidator<EmployeeRoleCreateModel>
{
    public EmployeeRoleCreateModelValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty().WithMessage("Name must be specified.");
    }
}
