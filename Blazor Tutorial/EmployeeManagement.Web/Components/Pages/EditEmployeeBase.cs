using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MohitProject.Component;
using System.Net;

namespace EmployeeManagement.Web.Components.Pages
{
    public class EditEmployeeBase : ComponentBase
    {

        [CascadingParameter]
        public Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        public string DepartmentId { get; set; }

        [Inject]
        public IMapper Mapper {  get; set; }
        public string PageHeaderText { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await authenticationStateTask;
            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                string returnUrl = WebUtility.UrlEncode($"/editemployee/{Id}");
                NavigationManager.NavigateTo($"/Identity/Account/Login?returnUrl={returnUrl}");
            }
            int.TryParse(Id, out int employeeId);

            if (employeeId != 0)
            {
                PageHeaderText = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Create Employee";
               /* Employee = new Employee
                {
                    DepartmentId = 2,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/Mohit.jfif"
                };*/
            }

            Departments = (await DepartmentService.GetDepartments()).ToList();
            //DepartmentId = Employee.DepartmentId.ToString();

            Mapper.Map(Employee, EditEmployeeModel);


            /* EditEmployeeModel.EmployeeId = Employee.EmployeeId;
             EditEmployeeModel.FirstName = Employee.FirstName;
             EditEmployeeModel.LastName = Employee.LastName;
             EditEmployeeModel.Email = Employee.Email;
             EditEmployeeModel.ConfirmEmail = Employee.Email;
             EditEmployeeModel.DateOfBirth = Employee.DateOfBirth;
             EditEmployeeModel.Gender = Employee.Gender;
             EditEmployeeModel.PhotoPath = Employee.PhotoPath;

             EditEmployeeModel.Department = Employee.Department;*/
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
        }

        protected async Task HandleValidSubmit()
        {


            Mapper.Map(EditEmployeeModel, Employee);

            Employee result = null;
            if(Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }

            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
        protected ConfirmBase DeleteConfirmation { get; set; }
        protected async Task Delete_Click()
        {
            /* await EmployeeService.DeleteEmployee(Employee.EmployeeId);
             NavigationManager.NavigateTo("/");*/
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                NavigationManager.NavigateTo("/");
            }
        }

        

    }
}
