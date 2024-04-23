using FluentValidation;
using HaadCRM.Service.DTOs.UserDTOs.UserRoles;

namespace HaadCRM.Service.Validators.Users.UserRoles;

public class UserRoleUpdateModelValidator : AbstractValidator<UserRoleUpdateModel>
{
    public UserRoleUpdateModelValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty().WithMessage("Name must be specified.");
    }
}
