using HaadCRM.Service.Services.HomeworkFiles;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeworkFileController(IHomeworkFilesService homeworkFilesService) : ControllerBase
{
}
