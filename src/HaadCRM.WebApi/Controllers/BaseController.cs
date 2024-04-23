using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HaadCRM.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public abstract class BaseController : ControllerBase { }
