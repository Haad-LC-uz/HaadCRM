using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Employees;
public class EmployeeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async ValueTask<EmployeeViewModel> CreateAsync(EmployeeCreateModel createModel)
    {
        var existEmployee = await _unitOfWork.Employees.SelectAsync(employee => employee.UserId == createModel.UserId);

        if (existEmployee != null)
        {
            throw new AlreadyExistException("An employee with the same user ID already exists.");
        }

        var employee = _mapper.Map<Employee>(createModel);

        // Assuming EmployeeRoleId is the ID of the employee role
        employee.EmployeeRole = await _unitOfWork.EmployeeRoles.SelectAsync(id => id.Id == createModel.EmployeeRoleId);

        var createdEmployee = await _unitOfWork.Employees.InsertAsync(employee);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<EmployeeViewModel>(createdEmployee);
    }

    public async ValueTask<EmployeeViewModel> UpdateAsync(long id, EmployeeUpdateModel updateModel)
    {
        var employee = await _unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
            ?? throw new NotFoundException($"Employee is not found with this ID={id}");

        _mapper.Map(updateModel, employee);

        await _unitOfWork.Employees.UpdateAsync(employee);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<EmployeeViewModel>(employee);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var employee = await _unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
            ?? throw new NotFoundException($"Employee is not found with this ID={id}");

        await _unitOfWork.Employees.DeleteAsync(employee);
        await _unitOfWork.SaveAsync();

        return true;
    }

    
}
