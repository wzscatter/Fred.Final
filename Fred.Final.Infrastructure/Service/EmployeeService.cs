using Final.Core.Entities;
using Final.Core.ServiceInterfaces;
using Final.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final.Infrastructure.Repository;
using Final.Core.Models.Request;
using MovieShop.Core.Exceptions;

namespace Final.Infrastructure.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeService(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public async Task<bool> AddEmployee(EmployeeRegisterRequestModel Employee)
        {
            var c = new Employee
            {
                Name = Employee.Name,
                Password = Employee.Password,
                Designation = Employee.Designation,
                
            };
            var createdEmployee = _EmployeeRepository.AddAsync(c);

            if (createdEmployee != null && createdEmployee.Id > 0)
            {
                return true;
            }

            return false;
        }

        public async Task DeleteEmployeeById(int id)
        {
            var res = _EmployeeRepository.GetByIdAsync(id).Result;
            if (res == null)
            {
                Console.WriteLine("not found Employee with Id:" + id);
            }
            else
            {
                await _EmployeeRepository.DeleteAsync(res);
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _EmployeeRepository.GetByIdAsync(id);
        }


        public Task<IEnumerable<Employee>> ListAll()
        {
            return _EmployeeRepository.ListAllAsync();
        }

        public async Task UpdateEmployee(int id, EmployeeRegisterRequestModel Employee)
        {
            await _EmployeeRepository.UpdateEmployee(id, Employee);

        }

        public Task<IEnumerable<Interaction>> ShowInteractions(int id)
        {
            return _EmployeeRepository.ShowInteractions(id);
        }
    }
}
