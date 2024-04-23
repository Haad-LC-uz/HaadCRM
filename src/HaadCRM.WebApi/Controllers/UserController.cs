using HaadCRM.Service.Services.Users;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
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
            var result = await userService.ChangePasswordAsync(oldPassword, newPassword);
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = result
            });
        }
    }
}
