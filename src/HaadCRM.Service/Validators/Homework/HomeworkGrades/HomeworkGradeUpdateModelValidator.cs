using FluentValidation;
using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;

namespace HaadCRM.Service.Validators.Homework.HomeworkGrades;

public class HomeworkGradeUpdateModelValidator : AbstractValidator<HomeworkGradeUpdateModel>
{
    public HomeworkGradeUpdateModelValidator()
    {
        RuleFor(model => model.StudentId)
            .NotEmpty().WithMessage("Student ID must be specified.")
            .GreaterThan(0).WithMessage("Student ID must be greater than 0.");

        RuleFor(model => model.AssistantId)
            .NotEmpty().WithMessage("Assistant ID must be specified.")
            .GreaterThan(0).WithMessage("Assistant ID must be greater than 0.");

        RuleFor(model => model.HomeworkId)
            .NotEmpty().WithMessage("Homework ID must be specified.")
            .GreaterThan(0).WithMessage("Homework ID must be greater than 0.");

        RuleFor(model => model.Grade)
            .InclusiveBetween(0, 100).WithMessage("Grade must be between 0 and 100.");
    }
}
