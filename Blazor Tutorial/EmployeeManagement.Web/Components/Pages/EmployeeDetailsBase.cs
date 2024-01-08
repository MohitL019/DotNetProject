using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Reflection.Metadata;

namespace EmployeeManagement.Web.Components.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        protected string Coordinates { get; set; }

        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;
        public string Display { get; set; } = string.Empty;

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            if (int.TryParse(Id, out int id))
            {
                Employee = await EmployeeService.GetEmployee(id);
            }
            else
            {
                // Handle invalid Id (e.g., log, set default value, or display an error)
            }
        }
        protected void Button_Click()
        {
            if(ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
                Display = "none";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
                Display = string.Empty;
            }
        }

        /*protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X = {e.ClientX} Y = {e.ClientY}";

        }*/
    }
}
