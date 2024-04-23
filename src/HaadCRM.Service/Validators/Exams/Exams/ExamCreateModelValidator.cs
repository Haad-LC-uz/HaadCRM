using FluentValidation;
using HaadCRM.Service.DTOs.ExamDTOs.Exams;

namespace HaadCRM.Service.Validators.Exams.Exams;

public class ExamCreateModelValidator : AbstractValidator<ExamCreateModel>
{
    public ExamCreateModelValidator()
    {
        RuleFor(model => model.TeacherId)
            .NotEmpty().WithMessage("Teacher ID must be specified.")
            .GreaterThan(0).WithMessage("Teacher ID must be greater than 0.");

        RuleFor(model => model.AssistantId)
            .NotEmpty().WithMessage("Assistant ID must be specified.")
            .GreaterThan(0).WithMessage("Assistant ID must be greater than 0.");

        RuleFor(model => model.GroupId)
            .NotEmpty().WithMessage("Group ID must be specified.")
            .GreaterThan(0).WithMessage("Group ID must be greater than 0.");

        RuleFor(model => model.AssetId)
            .NotEmpty().WithMessage("Asset ID must be specified.")
            .GreaterThan(0).WithMessage("Asset ID must be greater than 0.");

        RuleFor(model => model.DateOfExam)
            .NotEmpty().WithMessage("Date of exam must be specified.")
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Date of exam must be in the future.");

        RuleFor(model => model.DeadLine)
            .NotEmpty().WithMessage("Deadline must be specified.")
            .GreaterThan(model => model.DateOfExam).WithMessage("Deadline must be after the date of exam.");
    }
}
