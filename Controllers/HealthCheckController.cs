using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRAnalyticsPrescriptiveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        [Route("Check")]
        public IActionResult Check()
        {
            return Ok("Hii...System is up...");
        }
    }
}
