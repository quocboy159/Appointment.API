using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Appointment.Infrastructure.Entities
{
    public class AppointmentDbContext: DbContext
    {

        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options)
         : base(options)
        { }

        public DbSet<Data.Entities.Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
