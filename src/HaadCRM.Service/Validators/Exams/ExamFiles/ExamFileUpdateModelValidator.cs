using FluentValidation;
using HaadCRM.Service.DTOs.ExamDTOs.ExamFiles;

namespace HaadCRM.Service.Validators.Exams.ExamFiles;

public class ExamFileUpdateModelValidator : AbstractValidator<ExamFileUpdateModel>
{
    public ExamFileUpdateModelValidator()
    {
        RuleFor(model => model.ExamId)
            .NotEmpty().WithMessage("Exam ID must be specified.")
            .GreaterThan(0).WithMessage("Exam ID must be greater than 0.");

        RuleFor(model => model.AssetId)
            .NotEmpty().WithMessage("Asset ID must be specified.")
            .GreaterThan(0).WithMessage("Asset ID must be greater than 0.");
    }
}
