using FluentValidation;
using HaadCRM.Service.DTOs.UserDTOs.Permissions;

namespace HaadCRM.Service.Validators.Users.Permissions;

public class PermissionUpdateModelValidator : AbstractValidator<PermissionUpdateModel>
{
    public PermissionUpdateModelValidator()
    {
        RuleFor(model => model.Method)
            .NotEmpty().WithMessage("Method must be specified.");

        RuleFor(model => model.Controller)
            .NotEmpty().WithMessage("Controller must be specified.");
    }
}
