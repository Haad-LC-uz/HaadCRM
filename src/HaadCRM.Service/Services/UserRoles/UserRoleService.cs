using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.UserDTOs.UserRoles;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.UserRoles;
public class UserRoleService(IUnitOfWork unitOfWork, IMapper mapper) : IUserRoleService
{
    public async ValueTask<UserRoleViewModel> CreateAsync(UserRoleCreateModel createModel)
    {
        var existingRole = await unitOfWork.UserRoles.SelectAsync(role => role.Name == createModel.Name);

        if (existingRole != null)
        {
            throw new AlreadyExistException("A role with the same name already exists.");
        }

        var userRole = mapper.Map<UserRole>(createModel);

        var createdUserRole = await unitOfWork.UserRoles.InsertAsync(userRole);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserRoleViewModel>(createdUserRole);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var userRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"UserRole is not found with this ID={id}");
        await unitOfWork.UserRoles.DeleteAsync(userRole);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<UserRoleViewModel>> GetAllAsync()
    {
        var userRoles = await unitOfWork.UserRoles.SelectAsEnumerableAsync();
        return mapper.Map<IEnumerable<UserRoleViewModel>>(userRoles);
    }

    public async ValueTask<UserRoleViewModel> GetByIdAsync(long id)
    {
        var userRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"UserRole is not found with this ID={id}");
        return mapper.Map<UserRoleViewModel>(userRole);
    }

    public async ValueTask<UserRoleViewModel> UpdateAsync(long id, UserRoleUpdateModel updateModel)
    {
        var userRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"UserRole is not found with this ID={id}");
        mapper.Map(updateModel, userRole);

        await unitOfWork.UserRoles.UpdateAsync(userRole);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserRoleViewModel>(userRole);
    }
}
