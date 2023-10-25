using Appointment.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Appointment.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppointmentDbContext DbContext;

        public GenericRepository(AppointmentDbContext context)
        {
            DbContext = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await DbContext.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            return await Task.FromResult(DbContext.Set<T>().Remove(entity).Entity);
        }

        public async Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
            return await Task.FromResult(entities);
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsNoTracking();
        }

        public async Task<T?> GetByIdAsync(params object?[]? keyValues)
        {
            return await DbContext.Set<T>().FindAsync(keyValues);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await Task.FromResult(DbContext.Set<T>().Update(entity).Entity);
        }

        public async Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().UpdateRange(entities);
            return await Task.FromResult(entities);
        }
    }
}
