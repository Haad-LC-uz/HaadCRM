using FluentValidation;
using HaadCRM.Service.DTOs.UserDTOs.Users;
using HaadCRM.Service.Services.Users;
using HaadCRM.WebApi.Extensions;
using HaadCRM.WebApi.Models;
using HaadCRM.WebApi.Validators;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController(
    IUserService userService, 
    UserCreateModelValidator createModelValidator,
    UserUpdateModelValidator updateModelValidator) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] UserCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);

        var createdUser = await userService.CreateAsync(createModel);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = createdUser
        });
    }


    [HttpPut("api/[controller]/{id}")]
    public async ValueTask<IActionResult> UpdateAsync(long id, [FromBody] UserUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);

        var updatedUser = await userService.UpdateAsync(id, updateModel);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = updatedUser
        });
    }

    [HttpDelete("api/[controller]/{id}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result = await userService.DeleteAsync(id);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        });
    }

    [HttpGet("api/[controller]")]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        var users = await userService.GetAllAsync();
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = users
        });
    }

    [HttpGet("api/[controller]/{id}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var user = await userService.GetByIdAsync(id);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = user
        });
    }

    [HttpGet("login")]
    public async ValueTask<IActionResult> LoginAsync(string phone, string password)
    {
        var result = await userService.LoginAsync(phone, password);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = result
        });
    }

    [HttpGet("send-code")]
    public async ValueTask<IActionResult> SendCodeAsync(string phone)
    {
        var result = await userService.SendCodeAsync(phone);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = result
        });
    }

    [HttpGet("confirm-code")]
    public async ValueTask<IActionResult> ConfirmAsync(string phone, string code)
    {
        var result = await userService.ConfirmCodeAsync(phone, code);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = result
        });
    }

    [HttpPatch("reset-password")]
    public async ValueTask<IActionResult> ResetPasswordAsync(string phone, string newPassword)
    {
        var result = await userService.ResetPasswordAsync(phone, newPassword);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = result
        });
    }

    [HttpPatch("change-password")]
    public async ValueTask<IActionResult> ChangePasswordAsync(string oldPassword, string newPassword)
    {
        var result = await userService.ChangePasswordAsync(UserPhone, oldPassword, newPassword);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = result
        });
    }
}
