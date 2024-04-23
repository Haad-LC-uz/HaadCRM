using HaadCRM.Domain.Enums;
using HaadCRM.Service.Services.Assets;
using HaadCRM.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

public class AssetController(IAssetService assetService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] IFormFile file, FileType type)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await assetService.UploadAsync(file, type)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await assetService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await assetService.GetByIdAsync(id)
        });
    }
}
