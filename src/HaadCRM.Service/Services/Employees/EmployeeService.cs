using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // Creates a new employee
        public async ValueTask<EmployeeViewModel> CreateAsync(EmployeeCreateModel createModel)
        {
            // Check if an employee with the same user ID already exists
            var existEmployee = await unitOfWork.Employees.SelectAsync(employee => employee.UserId == createModel.UserId);
            if (existEmployee != null)
            {
                throw new AlreadyExistException("An employee with the same user ID already exists.");
            }

            // Map the createModel to an Employee entity
            var employee = mapper.Map<Employee>(createModel);

            // Retrieve the associated employee role based on the provided ID
            employee.EmployeeRole = await unitOfWork.EmployeeRoles.SelectAsync(id => id.Id == createModel.EmployeeRoleId);

            // Insert the new employee into the database
            var createdEmployee = await unitOfWork.Employees.InsertAsync(employee);
            await unitOfWork.SaveAsync();

            // Map the created employee back to a view model and return
            return mapper.Map<EmployeeViewModel>(createdEmployee);
        }

        // Updates an existing employee
        public async ValueTask<EmployeeViewModel> UpdateAsync(long id, EmployeeUpdateModel updateModel)
        {
            // Find the employee by ID, throw NotFoundException if not found
            var employee = await unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
                ?? throw new NotFoundException($"Employee is not found with this ID={id}");

            // Map properties from updateModel to the retrieved employee entity
            mapper.Map(updateModel, employee);

            // Update the employee in the database
            await unitOfWork.Employees.UpdateAsync(employee);
            await unitOfWork.SaveAsync();

            // Map the updated employee back to a view model and return
            return mapper.Map<EmployeeViewModel>(employee);
        }

        // Deletes an employee by ID
        public async ValueTask<bool> DeleteAsync(long id)
        {
            // Find the employee by ID, throw NotFoundException if not found
            var employee = await unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
                ?? throw new NotFoundException($"Employee is not found with this ID={id}");

            // Delete the employee from the database
            await unitOfWork.Employees.DeleteAsync(employee);
            await unitOfWork.SaveAsync();

            return true; // Deletion successful
        }

        // Gets all employees
        public async ValueTask<IEnumerable<EmployeeViewModel>> GetAllAsync()
        {
            // Retrieve all employees from the database
            var employees = await unitOfWork.Employees.SelectAsEnumerableAsync();

            // Map the list of employees to a list of view models and return
            return mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
        }

        // Gets an employee by ID
        public async ValueTask<EmployeeViewModel> GetByIdAsync(long id)
        {
            // Find the employee by ID, throw NotFoundException if not found
            var employee = await unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
                ?? throw new NotFoundException($"Employee is not found with this ID={id}");

            // Map the retrieved employee to a view model and return
            return mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
