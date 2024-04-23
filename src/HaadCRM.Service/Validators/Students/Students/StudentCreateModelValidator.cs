using FluentValidation;
using HaadCRM.Service.DTOs.StudentDTOs.Students;

namespace HaadCRM.Service.Validators.Students.Students;

public class StudentCreateModelValidator : AbstractValidator<StudentCreateModel>
{
    public StudentCreateModelValidator()
    {
        RuleFor(model => model.UserId)
            .NotEmpty().WithMessage("User ID must be specified.")
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");

        RuleFor(model => model.AssetId)
            .NotEmpty().WithMessage("Asset ID must be specified.")
            .GreaterThan(0).WithMessage("Asset ID must be greater than 0.");
    }
}
