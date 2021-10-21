using DapperASPNetCore.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperASPNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeesController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeRepo.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeRepo.GetEmployee(id);
                if (employee == null)
                    return NotFound();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
