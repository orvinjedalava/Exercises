using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogReportController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LogReportController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException("${nameof(IConfiguration)} not initialized.");
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string logType)
        {
            return Ok();
        }
    }
}
