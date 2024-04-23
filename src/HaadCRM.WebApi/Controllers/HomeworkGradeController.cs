using HaadCRM.Service.Services.HomeworkGrades;
using Microsoft.AspNetCore.Mvc;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeworkGradeController(IHomeworkGradeService homeworkGradeService) : ControllerBase
{
}
