using Microsoft.AspNetCore.Mvc;
using Moq;
using Test_Employees_Api.Controllers;
using Test_Employees_Api.Models;
using Test_Employees_Api.Services;

namespace Test_Employees_Api.Tests
{
    public class EmployeeTesting
    {
        private readonly EmployeesController _controller;
        private readonly Mock<IEmployeeService> _mockService;

        public EmployeeTesting()
        {
            _mockService = new Mock<IEmployeeService>();
            _controller = new EmployeesController(_mockService.Object);
        }

        [Fact]
        public async Task Get_Ok()
        {
            // Arrange
            _mockService.Setup(x => x.GetAllEmployeesAnnualSalary()).ReturnsAsync(new List<Employee>());

            // Act
            var result = await _controller.GetAllEmployees();


            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById_Ok()
        {
            // Arrange
            int id = 1;
            _mockService.Setup(x => x.GetEmployeeAnnualSalaryById(id)).ReturnsAsync(new Employee());

            // Act
            var result = await _controller.GetEmployeeById(id);


            // Assert
            Assert.IsType<OkObjectResult>(result);
            
        }

        [Fact]
        public async Task GetById_Exits()
        {
            // Arrange
            int id = 1;

            var employeeSimulator = new Employee ();
            employeeSimulator.id = 1;
            employeeSimulator.employee_name = "Tiger Nixon";
            employeeSimulator.employee_salary = 320800;
            employeeSimulator.employee_annual_salary = 3849600;
            employeeSimulator.employee_age = 61;

            _mockService.Setup(x => x.GetEmployeeAnnualSalaryById(id)).ReturnsAsync(employeeSimulator);

            // Act
            var result = await _controller.GetEmployeeById(id) as OkObjectResult;


            // Assert
            var employee = Assert.IsType<Employee>(result?.Value);
            Assert.True(employee != null);
            Assert.Equal(employee?.id, id);

        }


    }
}