using FluentValidation;
using HaadCRM.Service.DTOs.ExamDTOs.ExamGrades;

namespace HaadCRM.Service.Validators.Exams.ExamGrades;

public class ExamGradeCreateModelValidator : AbstractValidator<ExamGradeCreateModel>
{
    public ExamGradeCreateModelValidator()
    {
        RuleFor(model => model.StudentId)
            .NotEmpty().WithMessage("Student ID must be specified.")
            .GreaterThan(0).WithMessage("Student ID must be greater than 0.");

        RuleFor(model => model.ExamId)
            .NotEmpty().WithMessage("Exam ID must be specified.")
            .GreaterThan(0).WithMessage("Exam ID must be greater than 0.");

        RuleFor(model => model.TeacherId)
            .NotEmpty().WithMessage("Teacher ID must be specified.")
            .GreaterThan(0).WithMessage("Teacher ID must be greater than 0.");

        RuleFor(model => model.AssistantId)
            .NotEmpty().WithMessage("Assistant ID must be specified.")
            .GreaterThan(0).WithMessage("Assistant ID must be greater than 0.");

        RuleFor(model => model.Grade)
            .InclusiveBetween(0, 100).WithMessage("Grade must be between 0 and 100.");
    }
}
