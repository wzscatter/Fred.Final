using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        ////we need CRUD

        ////Reading
        //Task<T> GetByIdAsync(int Id); // return one record under certain class on corresponding Id

        

        ////Creating
        //Task<T> AddAsync(T entity);

        ////Updating
        //Task<T> UpdateAsync(T entity);

        ////Delete
        //Task DeleteAsync(T entity);

        //T GetEntityById(int Id);
        ////show all
        //Task<IEnumerable<T>> ListAllAsync(); // return all records under certain class
        //Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);


    }
}
