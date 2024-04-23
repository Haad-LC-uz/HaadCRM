using HaadCRM.Service.DTOs.ExamDTOs.Exams;
using HaadCRM.Service.DTOs.UserDTOs.UserRoles;
using HaadCRM.Service.Services.Exams.Exams;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers
{
    public class ExamsController(IExamService examService) : BaseController
    {
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromBody] ExamCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examService.CreateAsync(createModel)
            });
        }

        [HttpPut("{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id, [FromBody] ExamUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examService.UpdateAsync(id, updateModel)
            });
        }

        [HttpDelete("{id:long}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examService.DeleteAsync(id)
            });
        }

        [HttpGet("{id:long}")]
        public async ValueTask<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examService.GetByIdAsync(id)
            });
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examService.GetAllAsync()
            });
        }
    }
}
