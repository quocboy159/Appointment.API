namespace Appointment.Infrastructure.Settings
{
    internal class RabbitMqSettings
    {
        public required string Uri { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
