using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LogsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            ICollection<string> testResult = HttpContext.Request.Headers["User-Agent"];

            int count = testResult.Count;

            var encodedUrl = HttpContext.Request.GetEncodedUrl();
            var displayUrl = HttpContext.Request.GetDisplayUrl();
            string relativePath = UriHelper.GetEncodedPathAndQuery(HttpContext.Request);
            string httpProtocol = HttpContext.Request.Protocol;
            string httpMethod = HttpContext.Request.Method;
            string httpRequest = HttpContext.Request.ToString();
            DateTime timestamp = DateTime.ParseExact("10/Jul/2018:22:21:28 +0200", "dd/MMM/yyyy:HH:mm:ss zzzz", null);

            //Request.Headers["User-Agent"];
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
