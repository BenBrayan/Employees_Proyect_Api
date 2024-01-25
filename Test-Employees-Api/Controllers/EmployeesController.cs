using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Employees_Api.Models;
using Test_Employees_Api.Services;

namespace Test_Employees_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService= employeeService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllEmployees() => Ok( await _employeeService.GetAllEmployeesAnnualSalary());
       

        [HttpGet]
        [Route("Id")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeAnnualSalaryById(id);
            if(employee == null)
                return NotFound();


            return Ok(employee);
        }
    }
}
