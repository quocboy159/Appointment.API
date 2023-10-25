using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace PublisherTest.Controllers
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
        private readonly ISendEndpointProvider _bus;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISendEndpointProvider bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            Uri uri = new Uri("rabbitmq://localhost/appointment-created");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(new AppointmentCreated { Id = 1, Name = "quoc" });
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