using Microsoft.AspNetCore.Mvc;
using HaadCRM.Service.DTOs.GroupDTOs.GroupStudents;
using HaadCRM.Service.Services.GroupStudents;
using HaadCRM.WebApi.Models;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupStudentsController(IGroupStudentService groupStudentService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] GroupStudentCreateModel createModel)
    {
        var createdGroupStudent = await groupStudentService.CreateAsync(createModel);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = createdGroupStudent
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] GroupStudentUpdateModel updateModel)
    {
        var updatedGroupStudent = await groupStudentService.UpdateAsync(id, updateModel);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = updatedGroupStudent
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result = await groupStudentService.DeleteAsync(id);
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
        var groupStudents = await groupStudentService.GetAllAsync();
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = groupStudents
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var groupStudent = await groupStudentService.GetByIdAsync(id);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = groupStudent
        });
    }
}
