using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using Shared.Enums;
using Shared.Services.Interfaces;

namespace LogsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogReportController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogService _logService;

        public LogReportController(IConfiguration configuration, ILogService logService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(IConfiguration));
            _logService = logService ?? throw new ArgumentNullException(nameof(logService));
        }

        [HttpGet("Demo")]
        public IActionResult Get([FromQuery] string? logType)
        {
            try
            {
                LogType myLogType = string.IsNullOrWhiteSpace(logType) ?
                    LogType.HttpRequest
                    : Enum.Parse<LogType>(logType);

                string? httpRequestFile = _configuration.GetSection("Logs")?["HttpRequests"]?.ToString();

                if (httpRequestFile == null)
                    return NotFound();

                using StreamReader reader = new StreamReader(httpRequestFile);

                string text = reader.ReadToEnd();

                LogReport report = _logService.GenerateLogReport(text, myLogType);

                return Ok(report);
            }
            catch(Exception ex)
            {
                return Problem(
                    detail: ex.Message,
                    title: "Server error");
            }
        }
    }
}
