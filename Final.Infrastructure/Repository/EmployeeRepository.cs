using Final.Core.Entities;
using Final.Core.RepositoryInterfaces;
using Final.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Final.Core.Models.Request;

namespace Final.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly FinalDbContext _dbContext;
        public EmployeeRepository(FinalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> AddAsync(Employee entity)
        {
            _dbContext.Set<Employee>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        //----------------------------------------------------------
        public async Task DeleteAsync(Employee entity)
        {
            _dbContext.Set<Employee>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Employee>().FindAsync(id);
        }
        //------------------------------------------------

        public Employee GetEntityById(int id)
        {
            return _dbContext.Set<Employee>().Find(id);
        }

        public async Task<IEnumerable<Employee>> ListAllAsync()
        {
            return await _dbContext.Set<Employee>().ToListAsync();
        }

        public Task<IEnumerable<Employee>> ListAsync(Expression<Func<Employee, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Interaction>> ShowInteractions(int id)
        {
            var interactions = await _dbContext.Interactions.Where(i => i.EmployeeId == id).ToListAsync();
            return interactions;
        }

        public Task<Employee> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> UpdateEmployee(int id, EmployeeRegisterRequestModel Employee)
        {
            var local = _dbContext.Set<Employee>().Local.FirstOrDefault(c => c.Id == id);
            if (local != null) _dbContext.Entry(local).State = EntityState.Detached;
            var entity = new Employee { Id = id, Name = Employee.Name, Password = Employee.Password, Designation = Employee.Designation };
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }


    }
}
