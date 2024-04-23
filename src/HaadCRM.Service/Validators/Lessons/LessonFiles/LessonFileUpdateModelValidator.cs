using FluentValidation;
using HaadCRM.Service.DTOs.LessonsDTOs.LessonFiles;

namespace HaadCRM.Service.Validators.Lessons.LessonFiles;

public class LessonFileUpdateModelValidator : AbstractValidator<LessonFileUpdateModel>
{
    public LessonFileUpdateModelValidator()
    {
        RuleFor(x => x.LessonId)
            .NotEmpty().WithMessage("Lesson ID must be specified.")
            .GreaterThan(0).WithMessage("Lesson ID must be greater than 0.");
        RuleFor(x => x.AssetId)
            .NotEmpty().WithMessage("Asset ID must be specified.")
            .GreaterThan(0).WithMessage("Asset ID must be greater than 0.");
    }
}
