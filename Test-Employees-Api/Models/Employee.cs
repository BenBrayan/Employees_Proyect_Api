using System.ComponentModel.DataAnnotations;

namespace Test_Employees_Api.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_annual_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }
}
