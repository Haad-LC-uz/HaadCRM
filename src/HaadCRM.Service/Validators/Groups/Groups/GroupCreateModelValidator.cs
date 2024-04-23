using FluentValidation;
using HaadCRM.Service.DTOs.GroupDTOs.Groups;

namespace HaadCRM.Service.Validators.Groups.Groups;

public class GroupCreateModelValidator : AbstractValidator<GroupCreateModel>
{
    public GroupCreateModelValidator()
    {
        RuleFor(model => model.CourseId)
            .NotEmpty().WithMessage("Course ID must be specified.")
            .GreaterThan(0).WithMessage("Course ID must be greater than 0.");

        RuleFor(model => model.TeacherId)
            .NotEmpty().WithMessage("Teacher ID must be specified.")
            .GreaterThan(0).WithMessage("Teacher ID must be greater than 0.");

        RuleFor(model => model.AssistantId)
            .NotEmpty().WithMessage("Assistant ID must be specified.")
            .GreaterThan(0).WithMessage("Assistant ID must be greater than 0.");

        RuleFor(model => model.Name)
            .NotEmpty().WithMessage("Group name must be specified.")
            .MaximumLength(255).WithMessage("Group name must not exceed 255 characters.");

        RuleFor(model => model.StartTime)
            .NotEmpty().WithMessage("Start time must be specified.")
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Start time must be in the future.");

        RuleFor(model => model.Duration)
            .NotEmpty().WithMessage("Duration must be specified.")
            .GreaterThan(0).WithMessage("Duration must be greater than 0.");

        RuleFor(model => model.EndTime)
            .NotEmpty().WithMessage("End time must be specified.")
            .GreaterThan(model => model.StartTime).WithMessage("End time must be after the start time.");

        RuleFor(model => model.Price)
            .NotEmpty().WithMessage("Price must be specified.")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0.");

        RuleFor(model => model.Room)
            .NotEmpty().WithMessage("Room must be specified.")
            .MaximumLength(50).WithMessage("Room must not exceed 50 characters.");
    }
}
