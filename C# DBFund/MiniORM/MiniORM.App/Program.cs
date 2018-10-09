namespace MiniORM.App
{
    using System.Linq;
    using Data;
    using Data.Entities;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var connectionString = @"Server=DESKTOP-AE56UDL\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Mega",
                LastName = "Manqk",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = false,
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}