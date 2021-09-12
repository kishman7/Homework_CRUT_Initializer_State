using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_CRUT.Initializer
{
    public class EmployeesInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var positions = new List<Position>()
            {
                new Position{Title = "Forward", },
                new Position{Title = "Midfielder", },
                new Position{Title = "Forward", },
                new Position{Title = "Defender",  }
            };

            var tasks = new List<Task>()
            {
                new Task{Title = "Score goals", Priority = 1, },
                new Task{Title = "Create attacks", Priority = 2, },
                new Task{Title = "Score goals", Priority = 1, },
                new Task{Title = "Keep the defense", Priority = 3, }
            };

            var employees = new List<Employee>()
            {
                new Employee{Name = "Lionel", Surname = "Messi", Age = 34, Salary = 25000, Position = positions.FirstOrDefault(x=> x.Title == "Forward")},
                new Employee{Name = "Cristiano", Surname = "Ronaldo", Age = 35, Salary = 21000, Position = positions.FirstOrDefault(x=> x.Title == "Midfielder")},
                new Employee{Name = "Mariush", Surname = "Levandowski", Age = 30, Salary = 20000, Position = positions.FirstOrDefault(x=> x.Title == "Forward")},
                new Employee{Name = "Luca", Surname = "Modrich", Age = 33, Salary = 18000, Position = positions.FirstOrDefault(x=> x.Title == "Defender")}
            };

            //заповнюємо таблицю TaskEmployees
            employees[0].Tasks.Add(tasks.FirstOrDefault(x => x.Title == "Score goals"));
            employees[1].Tasks.Add(tasks.FirstOrDefault(x => x.Title == "Create attacks"));
            employees[2].Tasks.Add(tasks.FirstOrDefault(x => x.Title == "Score goals"));
            employees[3].Tasks.Add(tasks.FirstOrDefault(x => x.Title == "Keep the defense"));


            //додаємо ствоерені List в контекст
            context.Positions.AddRange(positions);
            context.Employees.AddRange(employees);
            context.Tasks.AddRange(tasks);

            context.SaveChanges();

            base.Seed(context);

        }
    }
}
