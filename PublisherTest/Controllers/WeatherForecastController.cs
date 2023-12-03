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
        public async Task<IActionResult> Get()
        {
            Uri uri = new Uri("exchange:cw.appointment.fanout.exchange");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(new AppointmentCreated { Id = 1, Name = "quoc" }, x =>
            {
                x.Headers.Set("operation", "appointment.update");
            });
           return Ok();
        }
    }
}