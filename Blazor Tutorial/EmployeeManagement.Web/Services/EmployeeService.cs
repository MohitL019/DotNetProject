using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync<Employee>("api/employees", newEmployee);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the content of the response into an Employee object
                Employee createdEmployeeResult = await response.Content.ReadFromJsonAsync<Employee>();
                return createdEmployeeResult;
            }
            else
            {
                // Log the HTTP status code and response content for debugging
                Console.WriteLine($"HTTP Status Code: {response.StatusCode}");

                string errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error Content: {errorContent}");
                // Handle the error case here, for example, throw an exception or return null
                return null;
            }
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employees/{id}");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/getEmployee/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> UpdateEmployee( Employee updatedEmployee)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync<Employee>("api/employees", updatedEmployee);
            //return await httpClient.PutAsJsonAsync<Employee, Employee>()
            if (response.IsSuccessStatusCode)
            {
                // Deserialize the content of the response into an Employee object
                Employee updatedEmployeeResult = await response.Content.ReadFromJsonAsync<Employee>();
                return updatedEmployeeResult;
            }
            else
            {
                // Handle the error case here, for example, throw an exception or return null
                return null;
            }
        }
    }
}
