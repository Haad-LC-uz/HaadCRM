﻿using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using HaadCRM.Service.DTOs.StudentDTOs.Students;
using HaadCRM.Service.Services.Students.Students;

namespace HaadCRM.WebApi.Controllers;

public class StudentsController(IStudentService studentService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] StudentCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await studentService.CreateAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] StudentUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await studentService.UpdateAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await studentService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await studentService.GetByIdAsync(id)
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await studentService.GetAllAsync()
        });
    }
}
