using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
    public string UserPhone => HttpContext?.User?.FindFirst("Phone")?.Value;
    public long GetUserId => Convert.ToInt64(HttpContext?.User?.FindFirst("Id")?.Value);
}
