using Contracts;
using MassTransit;

namespace Appointment.Infrastructure.Bus.Consumers
{
    public class AppointmentConsumer: IConsumer<AppointmentCreated>
    {
        public Task Consume(ConsumeContext<AppointmentCreated> context)
        {
            var data = context.Message;
            var redeliveryCount = context.Headers.Get<int>("MT-Redelivery-Count", 0);

            if (redeliveryCount < 3)
            {
                context.Defer(TimeSpan.FromSeconds(30));
            }
            //TODO:
            return Task.CompletedTask;
        }
    }
}
