using MassTransit;

namespace Contracts
{
    //[ExcludeFromTopology]
    //[EntityName("cw.appointment.update.queue")]
    public class AppointmentCreated
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
