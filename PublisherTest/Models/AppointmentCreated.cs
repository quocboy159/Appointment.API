using MassTransit;

namespace Contracts
{
    [ExcludeFromTopology]
    public class AppointmentCreated
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
