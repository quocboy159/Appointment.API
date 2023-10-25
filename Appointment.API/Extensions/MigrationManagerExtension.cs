using Appointment.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Extensions
{
    public static class MigrationManagerExtension
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using var appContext = scope.ServiceProvider.GetRequiredService<AppointmentDbContext>();
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return webApp;
        }
    }
}
