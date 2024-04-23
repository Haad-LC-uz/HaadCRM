using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkFiles;
using HaadCRM.Service.Services.HomeworkFiles;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeworkFileController(IHomeworkFilesService homeworkFilesService) : ControllerBase
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] HomeworkFileCreateModel homeworkFile)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeworkFilesService.CreateAsync(homeworkFile)
        });
    }
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] HomeworkFileUpdateModel homeworkFile)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeworkFilesService.UpdateAsync(id, homeworkFile)
        });
    }
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeworkFilesService.DeleteAsync(id)
        });
    }
}
