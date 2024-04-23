using FluentValidation;
using HaadCRM.Service.DTOs.UserDTOs.UserPermissions;

namespace HaadCRM.Service.Validators.Users.UserPermissions;

public class UserPermissionUpdateModelValidator : AbstractValidator<UserPermissionUpdateModel>
{
    public UserPermissionUpdateModelValidator()
    {
        RuleFor(model => model.UserId)
            .NotEmpty().WithMessage("User ID must be specified.")
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");

        RuleFor(model => model.PermissionId)
            .NotEmpty().WithMessage("Permission ID must be specified.")
            .GreaterThan(0).WithMessage("Permission ID must be greater than 0.");
    }
}
