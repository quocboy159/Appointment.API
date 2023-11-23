using Appointment.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Appointment.Infrastructure.Repositories
{
    public class AppoimentRepository : GenericRepository<Data.Entities.Appointment>, IAppoimentRepository
    {
        public AppoimentRepository(AppointmentDbContext context) : base(context)
        {
        }

        public async Task TestConcurrency()
        {
            var item1 = await FirstOrDefaultAsync(x => x.Id == 1);
            item1.Name = "1";

            // Change the person's name in the database to simulate a concurrency conflict
            await DbContext.Database.ExecuteSqlRawAsync(
                 "UPDATE  public.\"Appointment\" SET \"Name\" = '2' WHERE \"Id\" = 1");

            try
            {
                // Attempt to save changes to the database
                DbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }
    }
}
