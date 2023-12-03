using MassTransit;

namespace Contracts
{
    [EntityName("appointment-created")]

    public class AppointmentCreated
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
