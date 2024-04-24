using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;
using HaadCRM.Service.Services.Lessons;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

public class LessonController(ILessonService lessonService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] LessonCreateModel lesson)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonService.CreateAsync(lesson)
        });
    }
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] LessonUpdateModel lesson)
    {

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonService.UpdateAsync(id, lesson)
        });
    }
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonService.DeleteAsync(id)
        });
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync(
        [FromQuery] PaginationParams @params,
        [FromQuery] Filter filter,
        [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonService.GetAllAsync(@params, filter, search)
        });
    }
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonService.GetByIdAsync(id)
        });
    }
}

