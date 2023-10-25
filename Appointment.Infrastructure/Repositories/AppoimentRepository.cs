using Appointment.Infrastructure.Entities;

namespace Appointment.Infrastructure.Repositories
{
    public class AppoimentRepository : GenericRepository<Data.Entities.Appointment>, IAppoimentRepository
    {
        public AppoimentRepository(AppointmentDbContext context) : base(context)
        {
        }
    }
}
