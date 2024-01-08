using EmployeeManagement.Models;

namespace EmployeeManagement.API.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> GetEmployeeByEmail(string email);

        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id);
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);

    }
}
