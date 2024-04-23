using FluentValidation;
using HaadCRM.Service.DTOs.Courses;

namespace HaadCRM.Service.Validators.Cources;

public class CourseCreateModelValidator : AbstractValidator<CourseCreateModel>
{
    public CourseCreateModelValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty().WithMessage("Name must be specified.");

        RuleFor(model => model.Description)
            .NotEmpty().WithMessage("Description must be specified.");
    }
}
