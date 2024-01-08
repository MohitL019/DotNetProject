using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public bool ShowFooter { get; set; } = true;
        public IEnumerable<Employee> Employees {  get; set; }
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();

        }
        protected int SelectedEmployeesCount { get; set; } = 0;
        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }

        protected async Task EmployeeDeleted()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
        /*private void LoadEmployee()
        {
            System.Threading.Thread.Sleep(3000);
            Employee e1 = new Employee {
                EmployeeId = 1,
                FirstName = "Mohit",
                LastName = "Lokhande",
                Email = "mohit@gmail.com",
                DateOfBirth = new DateTime(2001,08,19),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/Mohit.jfif"
            };

            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Malhar",
                LastName = "Patil",
                Email = "malhar@gmail.com",
                DateOfBirth = new DateTime(1999, 12, 23),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/Mohit.jfif"
            };
            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Amey",
                LastName = "Bhosale",
                Email = "amey@gmail.com",
                DateOfBirth = new DateTime(2001, 5, 19),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/Mohit.jfif"
            };
            Employee e4 = new Employee
            {
                EmployeeId = 1,
                FirstName = "Mohit",
                LastName = "Lokhande",
                Email = "mohit@gmail.com",
                DateOfBirth = new DateTime(2001, 08, 19),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/Mohit.jfif"
            };


            Employees = new List<Employee> { e1 , e2 , e3 , e4};

            Employees = Employees.OrderBy(e => e.EmployeeId);
        }*/
    }
}
