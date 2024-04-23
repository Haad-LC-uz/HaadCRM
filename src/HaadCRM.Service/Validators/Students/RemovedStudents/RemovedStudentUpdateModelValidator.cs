using FluentValidation;
using HaadCRM.Service.DTOs.StudentDTOs.RemovedStudents;

namespace HaadCRM.Service.Validators.Students.RemovedStudents;

public class RemovedStudentUpdateModelValidator : AbstractValidator<RemovedStudentUpdateModel>
{
    public RemovedStudentUpdateModelValidator()
    {
        RuleFor(model => model.StudentId)
            .NotEmpty().WithMessage("Student ID must be specified.")
            .GreaterThan(0).WithMessage("Student ID must be greater than 0.");

        RuleFor(model => model.GroupId)
            .NotEmpty().WithMessage("Group ID must be specified.")
            .GreaterThan(0).WithMessage("Group ID must be greater than 0.");

        RuleFor(model => model.Reason)
            .NotEmpty().WithMessage("Reason must be specified.");
    }
}
