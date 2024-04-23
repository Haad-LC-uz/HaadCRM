using FluentValidation;
using HaadCRM.Service.DTOs.GroupDTOs.GroupStudents;

namespace HaadCRM.Service.Validators.Groups.GroupStudents;

public class GroupStudentCreateModelValidator : AbstractValidator<GroupStudentCreateModel>
{
    public GroupStudentCreateModelValidator()
    {
        RuleFor(model => model.GroupId)
            .NotEmpty().WithMessage("Group ID must be specified.")
            .GreaterThan(0).WithMessage("Group ID must be greater than 0.");

        RuleFor(model => model.StudentId)
            .NotEmpty().WithMessage("Student ID must be specified.")
            .GreaterThan(0).WithMessage("Student ID must be greater than 0.");
    }
}
