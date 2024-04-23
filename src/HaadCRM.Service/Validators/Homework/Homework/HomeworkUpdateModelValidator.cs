using FluentValidation;
using HaadCRM.Service.DTOs.HomeworkDTOs.Homework;

namespace HaadCRM.Service.Validators.Homework.Homework;

public class HomeworkUpdateModelValidator : AbstractValidator<HomeworkUpdateModel>
{
    public HomeworkUpdateModelValidator()
    {
        RuleFor(model => model.LessonId)
            .NotEmpty().WithMessage("Lesson ID must be specified.")
            .GreaterThan(0).WithMessage("Lesson ID must be greater than 0.");

        RuleFor(model => model.AssistantId)
            .NotEmpty().WithMessage("Assistant ID must be specified.")
            .GreaterThan(0).WithMessage("Assistant ID must be greater than 0.");

        RuleFor(model => model.Title)
            .NotEmpty().WithMessage("Title must be specified.");

        RuleFor(model => model.Description)
            .NotEmpty().WithMessage("Description must be specified.");

        RuleFor(model => model.DeadLine)
            .NotEmpty().WithMessage("Deadline must be specified.")
            .GreaterThan(DateTime.Now).WithMessage("Deadline must be in the future.");
    }
}
