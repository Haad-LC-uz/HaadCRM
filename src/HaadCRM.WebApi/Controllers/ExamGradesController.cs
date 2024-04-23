using HaadCRM.Service.DTOs.ExamDTOs.ExamGrades;
using HaadCRM.Service.Services.ExamGrades;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers
{
    public class ExamGradesController(IExamGradeService examGradeService) : BaseController
    {
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromBody] ExamGradeCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examGradeService.CreateAsync(createModel)
            });
        }

        [HttpPut("{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id, [FromBody] ExamGradeUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examGradeService.UpdateAsync(id, updateModel)
            });
        }

        [HttpDelete("{id:long}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examGradeService.DeleteAsync(id)
            });
        }

        [HttpGet("{id:long}")]
        public async ValueTask<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examGradeService.GetByIdAsync(id)
            });
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examGradeService.GetAllAsync()
            });
        }
    }
}
