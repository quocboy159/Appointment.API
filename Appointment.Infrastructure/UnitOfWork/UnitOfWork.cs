using Appointment.Infrastructure.Entities;

namespace Appointment.Infrastructure.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppointmentDbContext _dbContext;

        public UnitOfWork(AppointmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
            => _dbContext.SaveChanges();

        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();

        public void Rollback()
            => _dbContext.Dispose();

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
