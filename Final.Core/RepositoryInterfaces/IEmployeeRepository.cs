using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Final.Core.Models.Request;

namespace Final.Core.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {

        Task<Employee> UpdateEmployee(int id, EmployeeRegisterRequestModel Employee);
        Task<IEnumerable<Interaction>> ShowInteractions(int id);
        Task<Employee> GetByIdAsync(int Id); // return one record under certain class on corresponding Id



        //Creating
        Task<Employee> AddAsync(Employee entity);

        //Updating
        Task<Employee> UpdateAsync(Employee entity);

        //Delete
        Task DeleteAsync(Employee entity);

        Employee GetEntityById(int Id);
        //show all
        Task<IEnumerable<Employee>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<Employee>> ListAsync(Expression<Func<Employee, bool>> filter);
    }

}
