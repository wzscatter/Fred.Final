using Final.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final.Infrastructure.Data;
using System.Linq;
using System.Linq.Expressions;
namespace Final.Infrastructure.Repository
{
    public class EFRepository<T> : IAsyncRepository<T> where T : class
    {
        //protected readonly FinalDbContext _dbContext;
        //public EFRepository(FinalDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //public virtual async Task<T> AddAsync(T entity)
        //{
        //    _dbContext.Set<T>().Add(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //}

        //public virtual async Task DeleteAsync(T entity)
        //{
        //    _dbContext.Set<T>().Remove(entity);
            
        //    await _dbContext.SaveChangesAsync();
        //}


        //public virtual async Task<T> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}


        //public virtual async Task<IEnumerable<T>> ListAllAsync()
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}

        //public virtual async Task<T> UpdateAsync(T entity)

        //{
        //    throw new NotImplementedException();
        //}

        //public virtual T GetEntityById(int id)
        //{
        //    return _dbContext.Set<T>().Find(id);
        //}

        //public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}
    }
}
