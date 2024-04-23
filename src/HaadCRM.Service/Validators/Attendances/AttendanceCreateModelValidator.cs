using FluentValidation;
using HaadCRM.Service.DTOs.Attendances;

namespace HaadCRM.Service.Validators.Attendances;

public class AttendanceCreateModelValidator : AbstractValidator<AttendanceCreateModel>
{
    public AttendanceCreateModelValidator()
    {
        RuleFor(model => model.StudentId)
            .NotEmpty().WithMessage("StudentId must be specified.");

        RuleFor(model => model.LessonId)
            .NotEmpty().WithMessage("LessonId must be specified.");

        RuleFor(model => model.IsAttended)
            .NotNull().WithMessage("IsAttended must be specified.");
    }
}
