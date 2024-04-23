using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;
using HaadCRM.Service.Services.HomeworkGrades;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeworkGradeController(IHomeworkGradeService homeworkGradeService) : ControllerBase
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
}
