using HaadCRM.Service.DTOs.StudentDTOs.RemovedStudents;
using HaadCRM.Service.Services.RemovedStudents;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RemovedStudentsController(IRemovedStudentService removedStudentService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] RemovedStudentCreateModel createModel)
    {
        var createdRemovedStudent = await removedStudentService.CreateAsync(createModel);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = createdRemovedStudent
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] RemovedStudentUpdateModel updateModel)
    {
        var updatedRemovedStudent = await removedStudentService.UpdateAsync(id, updateModel);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = updatedRemovedStudent
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result = await removedStudentService.DeleteAsync(id);
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
        var removedStudents = await removedStudentService.GetAllAsync();
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = removedStudents
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var removedStudent = await removedStudentService.GetByIdAsync(id);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = removedStudent
        });
    }
}
