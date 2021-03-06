using Final.Core.Entities;
using Final.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.ServiceInterfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeById(int id);
        Task UpdateEmployee(int id, EmployeeRegisterRequestModel Employee);
        Task DeleteEmployeeById(int id);
        Task<bool> AddEmployee(EmployeeRegisterRequestModel Employee);
        Task<IEnumerable<Employee>> ListAll();
       
        Task<IEnumerable<Interaction>> ShowInteractions(int id);
    }
}
