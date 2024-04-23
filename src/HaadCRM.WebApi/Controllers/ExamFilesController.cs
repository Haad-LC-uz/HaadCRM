using HaadCRM.Service.DTOs.ExamDTOs.ExamFiles;
using HaadCRM.Service.Services.ExamFiles;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers
{
    public class ExamFilesController(IExamFileService examFileService) : BaseController
    {
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromBody] ExamFileCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examFileService.CreateAsync(createModel)
            });
        }

        [HttpPut("{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id, [FromBody] ExamFileUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examFileService.UpdateAsync(id, updateModel)
            });
        }

        [HttpDelete("{id:long}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examFileService.DeleteAsync(id)
            });
        }

        [HttpGet("{id:long}")]
        public async ValueTask<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examFileService.GetByIdAsync(id)
            });
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await examFileService.GetAllAsync()
            });
        }
    }
}
