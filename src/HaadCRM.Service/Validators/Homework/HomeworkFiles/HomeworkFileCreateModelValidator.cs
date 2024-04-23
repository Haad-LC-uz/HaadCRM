using FluentValidation;
using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkFiles;
using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;

namespace HaadCRM.Service.Validators.Homework.HomeworkFiles;

public class HomeworkFileCreateModelValidator : AbstractValidator<HomeworkFileCreateModel>
{
    public HomeworkFileCreateModelValidator()
    {
        RuleFor(x => x.HomeworkId)
            .NotEmpty().WithMessage("Homework ID must be specified.")
            .GreaterThan(0).WithMessage("Homework ID must be greater than 0.");
        RuleFor(x => x.AssetId)
            .NotEmpty().WithMessage("Asset ID must be specified.")
            .GreaterThan(0).WithMessage("Homework ID must be greater than 0.");
    }
}
