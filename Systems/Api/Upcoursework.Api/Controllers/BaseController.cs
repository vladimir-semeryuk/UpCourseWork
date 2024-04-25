using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Upcoursework.Api.Controllers;
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
}
