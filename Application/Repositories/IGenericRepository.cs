using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //Find Command
        Task<T> FindAsync(params object[] values);

        //Linq 
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);

        //Query and List Commands
        IQueryable<T> GetAllAsIQueryable();
        IQueryable<T> GetActivesAsIQueryable();
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> expression);
        Task<object> Select(Expression<Func<T, object>> expression);

        //Modify Commands
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task Destroy(T entity);
        Task DestroyRange(IEnumerable<T> entities);

    }
}
