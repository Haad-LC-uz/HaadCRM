﻿using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.Courses;
using HaadCRM.Service.Services.Courses;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

public class CoursesController(ICourseService courseService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] CourseCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.CreateAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] CourseUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.UpdateAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.GetByIdAsync(id)
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAsync(
        [FromQuery] PaginationParams @params,
        [FromQuery] Filter filter,
        [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.GetAllAsync(@params, filter, search)
        });
    }
}
