using Microsoft.AspNetCore.Mvc;
using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.Services.Employees;

namespace HaadCRM.WebApi.Controllers;

public class EmployeeController(
    IEmployeeService employeeService) : BaseController
{
    [HttpPost("api/[controller]")]
    public async ValueTask<IActionResult> CreateAsync([FromBody] EmployeeCreateModel createModel)
    {
        try
        {
            var createdEmployee = await employeeService.CreateAsync(createModel);
            return Ok(createdEmployee);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("api/[controller]/{id}")]
    public async ValueTask<IActionResult> UpdateAsync(long id, [FromBody] EmployeeUpdateModel updateModel)
    {
        try
        {
            var updatedEmployee = await employeeService.UpdateAsync(id, updateModel);
            return Ok(updatedEmployee);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("api/[controller]/{id}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        try
        {
            var result = await employeeService.DeleteAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("api/[controller]")]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        try
        {
            var employees = await employeeService.GetAllAsync();
            return Ok(employees);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("api/[controller]/{id}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        try
        {
            var employee = await employeeService.GetByIdAsync(id);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
