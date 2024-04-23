using HaadCRM.Service.Services.HomeworkServices;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeworkController(IHomeWorkService homeWorkService) : ControllerBase
{
}
