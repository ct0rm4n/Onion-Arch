using Application.Repositories;
using Domain.Entities.Abstarct;
using Domain.Enums;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestrutura.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class,IEntity
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();

        }


        //Find Comand

        public async Task<T> FindAsync(params object[] values)
        {
            return await _dbSet.FindAsync(values);
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await GetAllAsIQueryable().FirstOrDefaultAsync(exp);
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> expression)
        {
            return await GetActivesAsIQueryable().Where(expression).ToListAsync();
        }

        public IQueryable<T> GetAllAsIQueryable()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<object> Select(Expression<Func<T, object>> expression)
        {
            return await _dbSet.Select(expression).ToListAsync();
        }


        //Modify Commands
        public async Task<T>  AddAsync(T entity)
        {
            entity.Status = Status.Inserted;
            entity.InsertedDate = DateTime.Now;
            await _appDbContext.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
            
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
                await AddAsync(entity);
        }


        public async Task UpdateAsync(T entity)
        {
            entity.Status = Status.Modified;
            entity.LastModifiedDate = DateTime.Now;
            _appDbContext.Entry(entity);
            _appDbContext.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
                await UpdateAsync(entity);
        }

        public async Task Destroy(T entity)
        {
            _appDbContext.Remove(entity);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task  DestroyRange(IEnumerable<T> entities)
        {
           _appDbContext.RemoveRange(entities);
            await _appDbContext.SaveChangesAsync();

        }

        public IQueryable<T> GetActivesAsIQueryable()
        {
            return _dbSet.AsNoTracking().Where(x => x.Status != Status.Deleted);
        }

        public async Task DeleteAsync(T entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            entity.Status = Status.Deleted;
            _appDbContext.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                await DeleteAsync(entity);
        }
    }
}