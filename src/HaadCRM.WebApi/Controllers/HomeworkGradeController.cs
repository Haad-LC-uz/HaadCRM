using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;
using HaadCRM.Service.Services.HomeworkGrades;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

public class HomeworkGradeController(IHomeworkGradeService homeworkGradeService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(HomeworkGradeCreateModel homeworkGrade)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeworkGradeService.CreateAsync(homeworkGrade)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] HomeworkGradeUpdateModel homeworkGrade)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeworkGradeService.UpdateAsync(id, homeworkGrade)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeworkGradeService.DeleteAsync(id)
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
            Data = await homeworkGradeService.GetAllAsync(@params, filter, search)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeworkGradeService.GetByIdAsync(id)
        });
    }
}
