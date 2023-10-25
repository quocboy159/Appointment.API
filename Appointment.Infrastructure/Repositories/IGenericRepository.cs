using System.Linq.Expressions;

namespace Appointment.Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities);
        Task<T> DeleteAsync(T entity);
        Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities);
        Task<T?> GetByIdAsync(params object?[]? keyValues);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
    }
}
