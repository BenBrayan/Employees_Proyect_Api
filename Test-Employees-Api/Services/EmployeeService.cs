using System.Text.Json;
using Test_Employees_Api.Models;

namespace Test_Employees_Api.Services
{
    public interface IEmployeeService
    {
        public Task<Employee> GetEmployeeAnnualSalaryById(int id);
        public Task<IEnumerable<Employee>> GetAllEmployeesAnnualSalary();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IExternalApiService _externalApi;
        public EmployeeService(IExternalApiService externalApi)
        {
            _externalApi = externalApi;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAnnualSalary()
        {
            //Se consume la api externa y nos retorna las lista de empleados
            List<Employee> employees = await _externalApi.GetAllEmployeesExternalApi();

            //Se recorre la lista de empleados de la api externa donde se multiplica su salario por 12 meses para saber cuanto gana al año
            employees.ForEach(x => x.employee_annual_salary = x.employee_salary * 12);   

            return employees;
        }
        
        public async Task<Employee> GetEmployeeAnnualSalaryById(int id)
        {
            //Se consume la api externa y nos retorna su empleado filtrado
            Employee employee = await _externalApi.GetEmployeeByIdExternalApi(id);

            //Se modifica la propiedad del empleado de la api externa donde se multiplica su salario por 12 meses para saber cuanto gana al año
            employee.employee_annual_salary = employee.employee_salary * 12;

            return employee;
        }
        
    }
}
