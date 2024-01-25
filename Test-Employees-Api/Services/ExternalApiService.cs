using System.Net.Http;
using System.Text.Json;
using Test_Employees_Api.Models;

namespace Test_Employees_Api.Services
{
    public interface IExternalApiService
    {
        public Task<List<Employee>> GetAllEmployeesExternalApi();

        public Task<Employee> GetEmployeeByIdExternalApi(int id);
    }

    public class ExternalApiService: IExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ExternalApi");
        }
        public async Task<List<Employee>> GetAllEmployeesExternalApi()
        {
            try
            {
                //URL de empleados
                var response = await _httpClient.GetAsync($"v1/employees");

                //Léctura del contenido
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                //Se transforma el formato Json y se tipa la respuesta donde se retorna la data de los empleados
                var apiResponse = JsonSerializer.Deserialize<ApiResponseAll>(content);

                return apiResponse.data;
            }
            catch (HttpRequestException e)
            {
                // Manejar excepciones relacionadas con la solicitud HTTP
                throw new InvalidOperationException("Error al consumir la api externa", e);
            }
        }

        public async Task<Employee> GetEmployeeByIdExternalApi(int id)
        {
            try
            {
                //URL de empleado filtrado por Id
                var response = await _httpClient.GetAsync($"v1/employee/{id}");

                //Léctura del contenido
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                //Se transforma el formato Json y se tipa la respuesta donde se retorna la data del empleado
                var apiResponse = JsonSerializer.Deserialize<ApiResponseId>(content);

                return apiResponse.data;
            }
            catch (HttpRequestException e)
            {
                // Manejar excepciones relacionadas con la solicitud HTTP
                throw new InvalidOperationException("Error al consumir la api externa", e);
            }
        }
    }
}
