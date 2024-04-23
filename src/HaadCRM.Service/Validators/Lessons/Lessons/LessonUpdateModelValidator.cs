using FluentValidation;
using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;

namespace HaadCRM.Service.Validators.Lessons.Lessons;

public class LessonUpdateModelValidator : AbstractValidator<LessonUpdateModel>
{
    public LessonUpdateModelValidator()
    {
        RuleFor(model => model.GroupId)
            .NotEmpty().WithMessage("Group ID must be specified.")
            .GreaterThan(0).WithMessage("Group ID must be greater than 0.");

        RuleFor(model => model.DateOfLesson)
            .NotEmpty().WithMessage("Date of lesson must be specified.")
            .Must(date => date > DateTime.MinValue).WithMessage("Date of lesson must be a valid date.");

        RuleFor(model => model.Name)
            .NotEmpty().WithMessage("Lesson name must be specified.")
            .MaximumLength(255).WithMessage("Lesson name cannot exceed 255 characters.");
    }
}
