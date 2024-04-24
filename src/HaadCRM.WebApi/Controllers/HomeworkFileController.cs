using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkFiles;
using HaadCRM.Service.Services.HomeworkFiles;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

public class HomeworkFileController(IHomeworkFilesService homeworkFilesService) : BaseController
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
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeworkFilesService.GetAllAsync()
        });
    }
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeworkFilesService.GetByIdAsync(id)
        });
    }
}
