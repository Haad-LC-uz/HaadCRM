﻿using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using HaadCRM.Service.DTOs.LessonsDTOs.LessonFiles;
using HaadCRM.Service.Services.LessonFiles;

namespace HaadCRM.WebApi.Controllers;

public class LessonFilesController(ILessonFilesService lessonFilesService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] LessonFileCreateModel lessonFile)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonFilesService.CreateAsync(lessonFile)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] LessonFileUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonFilesService.UpdateAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonFilesService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonFilesService.GetByIdAsync(id)
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonFilesService.GetAllAsync()
        });
    }
}