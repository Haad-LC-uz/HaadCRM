using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.HomeworkDTOs.Homework;
using HaadCRM.Service.Services.HomeworkServices;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

public class HomeworkController(IHomeWorkService homeWorkService) : BaseController
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
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] HomeworkUpdateModel homework)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeWorkService.UpdateAsync(id, homework)
        });
    }
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeWorkService.DeleteAsync(id)
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
            Data = await homeWorkService.GetAllAsync(@params, filter, search)
        });
    }
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await homeWorkService.GetByIdAsync(id)
        });
    }
}
