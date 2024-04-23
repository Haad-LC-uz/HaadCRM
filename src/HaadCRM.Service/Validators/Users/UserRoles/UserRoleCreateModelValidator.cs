using FluentValidation;
using HaadCRM.Service.DTOs.UserDTOs.UserRoles;

namespace HaadCRM.Service.Validators.Users.UserRoles;

public class UserRoleCreateModelValidator : AbstractValidator<UserRoleCreateModel>
{
    public UserRoleCreateModelValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty().WithMessage("Name must be specified.");
    }
}
