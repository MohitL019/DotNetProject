using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using MohitProject.Component;

namespace EmployeeManagement.Web.Components.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }
        
        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }

        [Inject] 
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected ConfirmBase DeleteConfirmation { get; set; }
        protected void  Delete_Click()
        {
            DeleteConfirmation.Show();
            //NavigationManager.NavigateTo("/", true);
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }

        }
        /*protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            //NavigationManager.NavigateTo("/", true);
        }*/
    }
}
