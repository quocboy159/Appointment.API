using Contracts;
using MassTransit;

namespace Appointment.Infrastructure.Bus.Consumers
{
    public class AppointmentConsumer: IConsumer<AppointmentCreated>
    {
        public Task Consume(ConsumeContext<AppointmentCreated> context)
        {
            var data = context.Message;
            //TODO:
            return Task.CompletedTask;
        }
    }
}
