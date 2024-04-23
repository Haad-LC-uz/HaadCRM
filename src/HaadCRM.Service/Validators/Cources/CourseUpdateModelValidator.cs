using FluentValidation;
using HaadCRM.Service.DTOs.Courses;

namespace HaadCRM.Service.Validators.Attendances;

public class CourseUpdateModelValidator : AbstractValidator<CourseUpdateModel>
{
    public CourseUpdateModelValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty().WithMessage("Name must be specified.");

        RuleFor(model => model.Description)
            .NotEmpty().WithMessage("Description must be specified.");
    }
}
