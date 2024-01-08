//using EmployeeManagement.Web.Components;
//using EmployeeManagement.Web.Models;
//using EmployeeManagement.Web.Services;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using EmployeeManagement.Web.Data;

//var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("EmployeeManagementWebContextConnection") ?? throw new InvalidOperationException("Connection string 'EmployeeManagementWebContextConnection' not found.");

//builder.Services.AddDbContext<EmployeeManagementWebContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<EmployeeManagementWebContext>();

//// Add services to the container.
//builder.Services.AddRazorComponents()
//    .AddInteractiveServerComponents();

///*
//builder.Services.AddRazorPages()
//        .AddRazorPagesOptions(options =>
//        {
//            options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "Identity/Account/Login");
//        });
//*/


//builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client => {
//    client.BaseAddress = new Uri("http://localhost:5000/");
//});
//builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client => {
//    client.BaseAddress = new Uri("http://localhost:5000/");
//});
//builder.Services.AddAutoMapper(typeof(EmployeeProfile));
//builder.Services.AddAuthentication("Identity.Application")
//    .AddCookie();

//var app = builder.Build();

////builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error", createScopeForErrors: true);
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseStaticFiles();
//app.UseAntiforgery();

//app.MapRazorComponents<App>()
//    .AddInteractiveServerRenderMode();

////app.MapRazorPages();
//app.UseAuthentication();
//app.UseAuthorization();
//app.Run();


using EmployeeManagement.Web.Components;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Web.Data;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EmployeeManagementWebContextConnection") ?? throw new InvalidOperationException("Connection string 'EmployeeManagementWebContextConnection' not found.");

builder.Services.AddDbContext<EmployeeManagementWebContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<EmployeeManagementWebContext>();


builder.Services.AddMudServices();

//---------------------------------------
builder.Services.AddRazorPages();
/*
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});*/

/*builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});*/

//-----------------------------------------------------------

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
});

builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
});

builder.Services.AddAutoMapper(typeof(EmployeeProfile));

builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
//app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();
app.UseEndpoints(endpoints =>
{
    // Other endpoint configurations...

    endpoints.MapAreaControllerRoute(
        name: "Identity",
        areaName: "Identity",
        pattern: "Identity/{controller=Account}/{action=Login}/{id?}");
});

app.MapRazorPages();

app.Run();