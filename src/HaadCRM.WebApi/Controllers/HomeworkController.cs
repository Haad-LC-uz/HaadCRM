using HaadCRM.Service.DTOs.HomeworkDTOs.Homework;
using HaadCRM.Service.Services.HomeworkServices;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeworkController(IHomeWorkService homeWorkService) : ControllerBase
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] HomeworkCreateModel homework)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeWorkService.CreateAsync(homework)
        });
    }
}
