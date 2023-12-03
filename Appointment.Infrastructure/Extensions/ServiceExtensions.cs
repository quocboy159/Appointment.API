using Appointment.Infrastructure.Bus.Consumers;
using Appointment.Infrastructure.Entities;
using Appointment.Infrastructure.Repositories;
using Appointment.Infrastructure.Settings;
using Appointment.Infrastructure.UnitOfWork;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Appointment.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppointmentDbContext>(opts => opts.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IAppoimentRepository, AppoimentRepository>();

            AddMasstransit(services, configuration);
        }

        private static void AddMasstransit(IServiceCollection services, IConfiguration configuration)
        {
            var uri = configuration.GetSection(nameof(RabbitMqSettings))[nameof(RabbitMqSettings.Uri)];
            var userName = configuration.GetSection(nameof(RabbitMqSettings))[nameof(RabbitMqSettings.UserName)];
            var password = configuration.GetSection(nameof(RabbitMqSettings))[nameof(RabbitMqSettings.Password)];
            services.AddMassTransit(mt =>
            {
                mt.SetKebabCaseEndpointNameFormatter();

                mt.AddConsumer<AppointmentConsumer>();

                mt.UsingRabbitMq((context, config) =>
                {
                    config.Host(uri, "/", c =>
                    {
                        c.Username(userName);
                        c.Password(password);
                    });

                    config.ConfigureEndpoints(context);

                    config.ReceiveEndpoint("appointment-created", (c) =>
                    {
                        c.ConfigureConsumer<AppointmentConsumer>(context);
                    });
                });

            });
        }
    }
}
