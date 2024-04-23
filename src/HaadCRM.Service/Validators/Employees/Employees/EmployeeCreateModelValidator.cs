using FluentValidation;
using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;

namespace HaadCRM.Service.Validators.Employees.Employees;

public class EmployeeCreateModelValidator : AbstractValidator<EmployeeCreateModel>
{
    public EmployeeCreateModelValidator()
    {
        RuleFor(model => model.UserId)
            .NotEmpty().WithMessage("User ID must be specified.")
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");

        RuleFor(model => model.EmployeeRoleId)
            .NotEmpty().WithMessage("Employee role ID must be specified.")
            .GreaterThan(0).WithMessage("Employee role ID must be greater than 0.");

        RuleFor(model => model.AssetId)
            .NotEmpty().WithMessage("Asset ID must be specified.")
            .GreaterThan(0).WithMessage("Asset ID must be greater than 0.");

        RuleFor(model => model.Description)
            .NotEmpty().WithMessage("Description must be specified.");

        RuleFor(model => model.Salary)
            .NotEmpty().WithMessage("Salary must be specified.")
            .GreaterThan(0).WithMessage("Salary must be greater than 0.");
    }
}
