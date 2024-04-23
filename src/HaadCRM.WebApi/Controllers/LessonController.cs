using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;
using HaadCRM.Service.Services.Lessons;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonController(ILessonService lessonService) : ControllerBase
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
    public async ValueTask<IActionResult> PutAsync([FromBody] long id, LessonUpdateModel lesson)
    {

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonService.UpdateAsync(id, lesson)
        });
    }
}

