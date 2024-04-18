using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.UserDTOs.UserRoles;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.UserRoles;
public class UserRoleService : IUserRoleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserRoleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async ValueTask<UserRoleViewModel> CreateAsync(UserRoleCreateModel createModel)
    {
        var userRole = _mapper.Map<UserRole>(createModel);
        var createdUserRole = await _unitOfWork.UserRoles.InsertAsync(userRole);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserRoleViewModel>(createdUserRole);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var userRole = await _unitOfWork.UserRoles.SelectAsync(role => role.Id == id) 
            ?? throw new NotFoundException($"UserRole is not found with this ID={id}");
        await _unitOfWork.UserRoles.DeleteAsync(userRole);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<UserRoleViewModel>> GetAllAsync()
    {
        var userRoles = await _unitOfWork.UserRoles.SelectAsEnumerableAsync();
        return _mapper.Map<IEnumerable<UserRoleViewModel>>(userRoles);
    }

    public async ValueTask<UserRoleViewModel> GetByIdAsync(long id)
    {
        var userRole = await _unitOfWork.UserRoles.SelectAsync(role => role.Id == id) 
            ?? throw new NotFoundException($"UserRole is not found with this ID={id}");
        return _mapper.Map<UserRoleViewModel>(userRole);
    }

    public async ValueTask<UserRoleViewModel> UpdateAsync(long id, UserRoleUpdateModel updateModel)
    {
        var userRole = await _unitOfWork.UserRoles.SelectAsync(role => role.Id == id) 
            ?? throw new NotFoundException($"UserRole is not found with this ID={id}");
        _mapper.Map(updateModel, userRole);

        await _unitOfWork.UserRoles.UpdateAsync(userRole);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserRoleViewModel>(userRole);
    }
}
