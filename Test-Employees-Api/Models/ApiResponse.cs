namespace Test_Employees_Api.Models
{
    public class ApiResponse
    {
        public string status { get; set; }
        public string message { get; set; }

    }

    public class ApiResponseId : ApiResponse
    {
        public Employee data { get; set; }
    }

    public class ApiResponseAll : ApiResponse
    {
        public List<Employee> data { get; set; }
    }
}
