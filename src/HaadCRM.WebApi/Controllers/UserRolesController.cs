using HaadCRM.Service.DTOs.UserDTOs.UserRoles;
using HaadCRM.Service.Services.UserRoles;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

public class UserRolesController(IUserRoleService userRoleService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] UserRoleCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userRoleService.CreateAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] UserRoleUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userRoleService.UpdateAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userRoleService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userRoleService.GetByIdAsync(id)
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userRoleService.GetAllAsync()
        });
    }
}

