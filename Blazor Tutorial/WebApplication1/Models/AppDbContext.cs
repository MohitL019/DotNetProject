using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Mohit",
                LastName = "Lokhande",
                Email = "mohit@gmail.com",
                DateOfBirth = new DateTime(2001, 08, 19),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/Mohit.jfif"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Malhar",
                LastName = "Patil",
                Email = "malhar@gmail.com",
                DateOfBirth = new DateTime(1999, 12, 23),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/Mohit.jfif"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Amey",
                LastName = "Bhosale",
                Email = "amey@gmail.com",
                DateOfBirth = new DateTime(2001, 5, 19),
                Gender = Gender.Male,
                DepartmentId = 3,
                PhotoPath = "images/Mohit.jfif"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Shubham",
                LastName = "Suryawanshi",
                Email = "shubham@gmail.com",
                DateOfBirth = new DateTime(2001, 1, 16),
                Gender = Gender.Male,
                DepartmentId = 4,
                PhotoPath = "images/Mohit.jfif"
            });
        }
    }
}
