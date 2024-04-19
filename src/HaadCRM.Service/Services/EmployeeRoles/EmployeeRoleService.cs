using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Service.DTOs.EmployeeDTOs.EmployeeRoles;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.EmployeeRoles
{
    public class EmployeeRoleService(IUnitOfWork unitOfWork, IMapper mapper) : IEmployeeRoleService
    {
        public async ValueTask<EmployeeRoleViewModel> CreateAsync(EmployeeRoleCreateModel createModel)
        {
            var existingRole = await unitOfWork.EmployeeRoles.SelectAsync(role => role.Name == createModel.Name);

            if (existingRole != null)
            {
                throw new AlreadyExistException("An employee role with the same name already exists.");
            }

            var employeeRole = mapper.Map<EmployeeRole>(createModel);

            var createdEmployeeRole = await unitOfWork.EmployeeRoles.InsertAsync(employeeRole);
            await unitOfWork.SaveAsync();

            return mapper.Map<EmployeeRoleViewModel>(createdEmployeeRole);
        }

        public async ValueTask<EmployeeRoleViewModel> UpdateAsync(long id, EmployeeRoleUpdateModel updateModel)
        {
            var employeeRole = await unitOfWork.EmployeeRoles.SelectAsync(role => role.Id == id)
                ?? throw new NotFoundException($"Employee role is not found with this ID={id}");

            mapper.Map(updateModel, employeeRole);

            await unitOfWork.EmployeeRoles.UpdateAsync(employeeRole);
            await unitOfWork.SaveAsync();

            return mapper.Map<EmployeeRoleViewModel>(employeeRole);
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var employeeRole = await unitOfWork.EmployeeRoles.SelectAsync(role => role.Id == id)
                ?? throw new NotFoundException($"Employee role is not found with this ID={id}");

            await unitOfWork.EmployeeRoles.DeleteAsync(employeeRole);
            await unitOfWork.SaveAsync();

            return true;
        }

        public async ValueTask<IEnumerable<EmployeeRoleViewModel>> GetAllAsync()
        {
            var employeeRoles = await unitOfWork.EmployeeRoles.SelectAsEnumerableAsync();
            return mapper.Map<IEnumerable<EmployeeRoleViewModel>>(employeeRoles);
        }

        public async ValueTask<EmployeeRoleViewModel> GetByIdAsync(long id)
        {
            var employeeRole = await unitOfWork.EmployeeRoles.SelectAsync(role => role.Id == id)
                ?? throw new NotFoundException($"Employee role is not found with this ID={id}");

            return mapper.Map<EmployeeRoleViewModel>(employeeRole);
        }
    }
}
