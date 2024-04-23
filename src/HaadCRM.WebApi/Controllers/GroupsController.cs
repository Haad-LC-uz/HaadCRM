using Microsoft.AspNetCore.Mvc;
using HaadCRM.Service.DTOs.GroupDTOs.Groups;
using HaadCRM.Service.Services.GroupService;
using HaadCRM.WebApi.Models;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupsController(IGroupService groupService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] GroupCreateModel createModel)
    {
        var createdGroup = await groupService.CreateAsync(createModel);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = createdGroup
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] GroupUpdateModel updateModel)
    {
        var updatedGroup = await groupService.UpdateAsync(id, updateModel);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = updatedGroup
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result = await groupService.DeleteAsync(id);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var groups = await groupService.GetAllAsync();
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = groups
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var group = await groupService.GetByIdAsync(id);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = group
        });
    }
}
