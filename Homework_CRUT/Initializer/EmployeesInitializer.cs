using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_CRUT.Initializer
{
    public class EmployeesInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var employees = new List<Employee>()
            {
                new Employee{Name = "Lionel", Surname = "Messi", Age = 34, Salary = 25000, PositionId = 1},
                new Employee{Name = "Cristiano", Surname = "Ronaldo", Age = 35, Salary = 21000, PositionId = 2},
                new Employee{Name = "Mariush", Surname = "Levandowski", Age = 30, Salary = 20000, PositionId = 2},
                new Employee{Name = "Luca", Surname = "Modrich", Age = 33, Salary = 18000, PositionId = 3}
            };

            var positions = new List<Position>()
            {
                new Position{Title = "CEO", Employees = (ICollection<Employee>)employees.FirstOrDefault(x=>x.Surname.Equals("Messi")), },
                new Position{Title = "Manager", Employees = (ICollection<Employee>)employees.FirstOrDefault(x=>x.Surname.Equals("Ronaldo")), },
                new Position{Title = "Manager", Employees = (ICollection<Employee>)employees.FirstOrDefault(x=>x.Surname.Equals("Messi")), },
                new Position{Title = "Agent", Employees = (ICollection<Employee>)employees.FirstOrDefault(x=>x.Surname.Equals("Messi")), }
            };

        }
    }
}
