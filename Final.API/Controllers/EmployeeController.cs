using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.Threading.Tasks;
using Final.Core.ServiceInterfaces;
using Final.Core.Entities;
using Final.Core.Models.Request;

namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> ListAllEmployees()
        {
            var Employees = await _EmployeeService.ListAll();
            if (!Employees.Any())
            {
                return NotFound("didnt find any Employee, please add first");
            }
            return Ok(Employees);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddEmployee(EmployeeRegisterRequestModel Employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check data");

            }
            var registeredEmployee = await _EmployeeService.AddEmployee(Employee);
            return Ok(registeredEmployee);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getEmployeebyid(int id)
        {
            var Employee = await _EmployeeService.GetEmployeeById(id);
            if (Employee == null)
            {
                return NotFound("not found target Employee with id:" + id);
            }
            return Ok(Employee);
        }



        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var Employee = await _EmployeeService.GetEmployeeById(id);
            await _EmployeeService.DeleteEmployeeById(id);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeRegisterRequestModel Employee)
        {
            await _EmployeeService.UpdateEmployee(id, Employee);
            return Ok();

        }

        [HttpGet]
        [Route("interactions")]
        public async Task<IActionResult> ShowInteractions(int id)
        {
            var interactions = await _EmployeeService.ShowInteractions(id);

            return Ok(interactions);
        }

    }
}
